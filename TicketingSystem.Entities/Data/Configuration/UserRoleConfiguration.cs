using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace TicketingSystem.Entities.Data.Configuration
{
    public class UserRoleConfiguration : IEntityTypeConfiguration<IdentityUserRole<Guid>>
    {
        public void Configure(EntityTypeBuilder<IdentityUserRole<Guid>> builder)
        {
            builder.HasData(SeedUserRole());
        }

        private List<IdentityUserRole<Guid>> SeedUserRole()
        {
            var result = new List<IdentityUserRole<Guid>>();

            var userRole = new IdentityUserRole<Guid>()
            {
                UserId = Guid.Parse("62448744-4356-44dc-a005-0bfb6ba9e8b2"),
                RoleId = Guid.Parse("7062d4a3-203f-4375-aaef-4918dcfcef04")
            };
            result.Add(userRole);

            userRole = new IdentityUserRole<Guid>()
            {
                UserId = Guid.Parse("1456c79b-7080-4586-8467-900a3cb033fe"),
                RoleId = Guid.Parse("0378ef66-3332-4860-ad38-773ed8c0594a")
            };
            result.Add(userRole);


            return result;
        }
    }
}
