using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MurexBreakfast.Api.Models;

namespace MurexBreakfast.Api.Data
{
    public static class DbSeeder
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            SeedUsers(modelBuilder);
            SeeRoles(modelBuilder);
            SeedUserRoles(modelBuilder);
        }

        private static void SeedUsers(ModelBuilder modelBuilder)
        {
            var passwordHasher = new PasswordHasher<AppUser>();

            var adminUser  = new AppUser {
                Id = "1",
                FirstName = "Murendeni",
                LastName = "Nevondo",
                UserName = "MurendeniN",
                NormalizedUserName = "MurendeniN".ToUpper(),
                Email = "murendeni727@gmail.com",
                NormalizedEmail = "mnevondo727@gmail.com".ToUpper(),
                PhoneNumber = "0790983041",
                EmailConfirmed = true
            };

            adminUser.PasswordHash = passwordHasher.HashPassword(adminUser, "$ummer@2022");

            modelBuilder.Entity<AppUser>().HasData(adminUser);
        }

        private static void SeeRoles(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<IdentityRole>().HasData(
                new IdentityRole
                {
                    Id = "admin_role",
                    Name = "admin",
                    NormalizedName = "admin".ToUpper(),
                });
        }

        private static void SeedUserRoles(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                RoleId = "admin_role",
                UserId = "1"
            });
        }
    }
}
