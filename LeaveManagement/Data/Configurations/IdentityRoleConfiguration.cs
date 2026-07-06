using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LeaveManagement.Data.Configurations
{
    public class IdentityRoleConfiguration : IEntityTypeConfiguration<IdentityRole>
    {
        public void Configure(EntityTypeBuilder<IdentityRole> builder)
        {
            builder.HasData(
                new IdentityRole { Id = "a4e66228-6894-40e3-8b02-b18e2e0f3300", Name = "Employee", NormalizedName = "EMPLOYEE" },
                new IdentityRole { Id = "50670bd3-5090-4c0e-8203-a27defd1fde8", Name = "Supervisor", NormalizedName = "SUPERVISOR" },
                new IdentityRole { Id = "a74e4ce2-4dae-4a04-bfc6-3cc6e32aff6d", Name = "Administrator", NormalizedName = "ADMINISTRATOR" });
        }
    }
}
