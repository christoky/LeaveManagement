using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace LeaveManagement.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);

            builder.Entity<IdentityRole>().HasData(
                new IdentityRole { Id = "a4e66228-6894-40e3-8b02-b18e2e0f3300", Name = "Employee", NormalizedName = "EMPLOYEE" },
                new IdentityRole { Id = "50670bd3-5090-4c0e-8203-a27defd1fde8", Name = "Supervisor", NormalizedName = "SUPERVISOR" },
                new IdentityRole { Id = "a74e4ce2-4dae-4a04-bfc6-3cc6e32aff6d", Name = "Administrator", NormalizedName = "ADMINISTRATOR" }
            );

            var hasher = new PasswordHasher<ApplicationUser>();

            builder.Entity<ApplicationUser>().HasData(new ApplicationUser
            {
                    Id = "d1b8c9e5-9c3a-4f0e-8b2a-1a2b3c4d5e6f",
                    Email = "admin@localhost.com",
                    NormalizedEmail = "ADMIN@LOCALHOST.COM",
                    UserName = "admin@localhost.com",
                    NormalizedUserName = "ADMIN@LOCALHOST.COM",
                    PasswordHash = hasher.HashPassword(null, "P@ssword1"),
                    EmailConfirmed = true,
                    FirstName = "Default",
                    LastName = "Admin",
                    DateOfBirth = new DateOnly(1983,05,01)
                }
            );

            builder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
                    {
                        RoleId = "a74e4ce2-4dae-4a04-bfc6-3cc6e32aff6d", // Administrator role
                        UserId = "d1b8c9e5-9c3a-4f0e-8b2a-1a2b3c4d5e6f"  // admin user
                    }
                );
        }

        public DbSet<LeaveType> LeaveTypes { get; set; }
    }
}
