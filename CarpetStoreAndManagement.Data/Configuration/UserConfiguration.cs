using CarpetStoreAndManagement.Data.Models.User;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarpetStoreAndManagement.Data.Configuration
{
    internal class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasData(CreateUser());
        }

        private User CreateUser()
        {
            string adminId = "41d1aea7-5764-4ebb-8a0d-055594610abb";
            
            var user = new User
            {
                Id = adminId,
                Email = "ivan@abv.bg",
                NormalizedEmail = "IVAN@ABV.BG",
                UserName = "Ivan",
                NormalizedUserName = "IVAN",
                PhoneNumber = "+111111111111",
                EmailConfirmed = true,
                PhoneNumberConfirmed = true,
                SecurityStamp = adminId
            };

            PasswordHasher<User> ph = new PasswordHasher<User>();
            user.PasswordHash = ph.HashPassword(user, "Cska1948!");

            return user;
        }
    }
}
