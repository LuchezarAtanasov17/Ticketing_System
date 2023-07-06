using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketingSystem.Entities.Models;

namespace TicketingSystem.Entities.Data.Configuration
{
    internal class IdentityRoleConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.HasData(SeedIdentityRoles());
        }

        private List<Role> SeedIdentityRoles()
        {
            var roles = new List<Role>();

            Role role = new Role()
            {
                Id = Guid.Parse("7062d4a3-203f-4375-aaef-4918dcfcef04"),
                Name = "User",
                NormalizedName = "Name".ToUpper(),
                ConcurrencyStamp = "bdea90a1-4ea6-4db7-acc6-c5dd6a18bb07"
            };
            roles.Add(role);

            role = new Role()
            {
                Id = Guid.Parse("6c508509-7dd9-44c3-9597-8c14c65e661b"),
                Name = "Administrator",
                NormalizedName = "Administrator".ToUpper(),
                ConcurrencyStamp = "b6d65614-7c33-46b0-aecc-ebe78d0f9d7d"
            };
            roles.Add(role);

            role = new Role()
            {
                Id = Guid.Parse("0378ef66-3332-4860-ad38-773ed8c0594a"),
                Name = "Мaintenance",
                NormalizedName = "Мaintenance".ToUpper(),
                ConcurrencyStamp = "b832276f-ec40-4348-95c3-a49808529b84"
            };
            roles.Add(role);

            return roles;
        }
    }
}
