using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using MurexBreakfast.Api.Data;
using MurexBreakfast.Api.Models;
using MurexBreakfast.Api.Services.Authentication;
using MurexBreakfast.Api.Services.User;
using System.Text;

namespace MurexBreakfast.Api.Extensions
{
    public static class ServicesExtensions
    {
        public static void ConfigureDatabaseConnection(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<MurexBreakfastContext>(options =>
            {
                options.UseNpgsql(configuration.GetConnectionString("DefaultConnection"));
            });
        }

        public static void ConfigureIdentityCore(this IServiceCollection services)
        {
            services.AddIdentityCore<AppUser>(o =>
            {
                o.Password.RequireDigit = true;
                o.Password.RequireLowercase = false;
                o.Password.RequireUppercase = false;
                o.Password.RequireNonAlphanumeric = false;
                o.User.RequireUniqueEmail = true;
            })
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<MurexBreakfastContext>()
                .AddDefaultTokenProviders();
        }

        public static void ConfigureJwt(this IServiceCollection services, IConfiguration configuration)
        {
            var jwtSettings = configuration.GetSection("JwtSettings");

            services.AddAuthentication(o =>
            {
                o.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                o.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(o =>
            {
                o.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
                {
                    ValidateAudience = true,
                    ValidateIssuer = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = jwtSettings.GetSection("ValidIssuer").Value,
                    ValidAudience = jwtSettings.GetSection("ValidAudiance").Value,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.GetSection("Secret").Value))
                };
            });
        }

        public static void AddUserService(this IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();
        }

        public static void AddAuthService(this IServiceCollection services)
        {
            services.AddScoped<IAuthService, AuthService>();
        }
    }
}
