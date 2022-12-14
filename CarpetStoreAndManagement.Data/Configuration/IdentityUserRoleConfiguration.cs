using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarpetStoreAndManagement.Data.Configuration
{
    internal class IdentityUserRoleConfiguration : IEntityTypeConfiguration<IdentityUserRole<string>>
    {
        public void Configure(EntityTypeBuilder<IdentityUserRole<string>> builder)
        {
            builder.HasData(AddAdminRole());
        }

        private IdentityUserRole<string> AddAdminRole()
        {
            string adminRoleId = "dc68c20c-33c1-4737-9e5e-16b8384e8977";
            string adminId = "41d1aea7-5764-4ebb-8a0d-055594610abb";

            var identityUserRole = new IdentityUserRole<string>
            {
                RoleId = adminRoleId,
                UserId = adminId
            };

            return identityUserRole;
        }
    }
}
