using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LeaveManagement.Data.Configurations
{
    public class IdentityUserRoleConfiguration : IEntityTypeConfiguration<IdentityUserRole<string>>
    {
        public void Configure(EntityTypeBuilder<IdentityUserRole<string>> builder)
        {
            builder.HasData(new IdentityUserRole<string>
            {
                RoleId = "a74e4ce2-4dae-4a04-bfc6-3cc6e32aff6d", // Administrator role
                UserId = "d1b8c9e5-9c3a-4f0e-8b2a-1a2b3c4d5e6f"  // admin user
            });
        }
    }
}
