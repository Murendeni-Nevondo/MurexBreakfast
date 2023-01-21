using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MurexBreakfast.Api.Models;

namespace MurexBreakfast.Api.Data
{
    public class MurexBreakfastContext : IdentityDbContext<AppUser>
    {
        public MurexBreakfastContext(DbContextOptions<MurexBreakfastContext> options) 
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Seed();
        }
        public DbSet<AppUser> AppUsers { get; set; } = null!; // TODO: Check if this code must be removed
        public DbSet<Breakfast> Breakfasts { get; set; } = null!;
        public DbSet<UserProfile> UserProfiles { get; set; } = null!;
    }
}
