using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarpetStoreAndManagement.Data.Configuration
{
    internal class IdentityRoleConfiguration : IEntityTypeConfiguration<IdentityRole>
    {
        public void Configure(EntityTypeBuilder<IdentityRole> builder)
        {
            builder.HasData(CreateRoles());
        }

        private List<IdentityRole> CreateRoles()
        {
            var roles = new List<IdentityRole>();
            string adminRoleId = "dc68c20c-33c1-4737-9e5e-16b8384e8977";
            string userRoleId = "2148ea66-d73d-4636-9cc7-22bfaa9796ba";

            var adminRole = new IdentityRole
            {
                Name = "Admin",
                NormalizedName = "ADMIN",
                Id = adminRoleId,
                ConcurrencyStamp = adminRoleId
            };

            var userRole = new IdentityRole
            {
                Name = "User",
                NormalizedName = "USER",
                Id = userRoleId,
                ConcurrencyStamp = userRoleId

            };

            roles.Add(adminRole);
            roles.Add(userRole);

            return roles;
        }
    }
}
