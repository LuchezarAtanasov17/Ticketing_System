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
    internal class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasData(SeedUsers());
        }

        private List<User> SeedUsers()
        {
            var users = new List<User>();

            var user = new User()
            {
                Id = Guid.Parse("62448744-4356-44dc-a005-0bfb6ba9e8b2"),
                UserName = "User",
                NormalizedUserName = "User".ToUpper(),
                Email = "user@mail.com",
                NormalizedEmail = "user@mail.com".ToUpper(),
                FirstName = "Ivan",
                LastName = "Ivanov"
            };
            users.Add(user);

            user = new User()
            {
                Id = Guid.Parse("1456c79b-7080-4586-8467-900a3cb033fe"),
                UserName = "User2",
                NormalizedUserName = "User2".ToUpper(),
                Email = "user2@gmail.com",
                NormalizedEmail = "user2@gmail.com".ToUpper(),
                FirstName = "Georgi",
                LastName = "Georgiev",
            };
            users.Add(user);

            return users;
        }
    }
}
