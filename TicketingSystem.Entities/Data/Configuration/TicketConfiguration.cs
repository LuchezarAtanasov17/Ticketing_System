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
    internal class TicketConfiguration : IEntityTypeConfiguration<Ticket>
    {
        public void Configure(EntityTypeBuilder<Ticket> builder)
        {
            builder.HasData(SeedTickets());
        }

        private List<Ticket> SeedTickets()
        {
            var tickets = new List<Ticket>();

            var ticket = new Ticket()
            {
                Id = Guid.Parse("ad90a67e-02be-4f9a-9fa8-74d5abcc2b4b"),
                SenderId = Guid.Parse("62448744-4356-44dc-a005-0bfb6ba9e8b2"),
                ProjectId = Guid.Parse("8c97398e-09d8-4823-a82d-343619758e81"),
                Title = "Login issue.",
                Description = "The app doesn't recognize my identity, when I try to log in.",
                ReleaseDate = DateTime.Parse("23-04-2022"),
                State = Enums.Tickets.States.Draft,
                Type = Enums.Tickets.Types.BugReport,
            };
            tickets.Add(ticket);

            ticket = new Ticket()
            {
                Id = Guid.Parse("543ff3e3-5ac4-45ca-8cd4-f8d942548c7e"),
                SenderId = Guid.Parse("1456c79b-7080-4586-8467-900a3cb033fe"),
                ProjectId = Guid.Parse("8c97398e-09d8-4823-a82d-343619758e81"),
                Title = "Help for account activity.",
                Description = "I need help with finding my login activity.",
                ReleaseDate = DateTime.Parse("23-06-2023"),
                State = Enums.Tickets.States.New,
                Type = Enums.Tickets.Types.AssistanceRequest,
            };
            tickets.Add(ticket);

            ticket = new Ticket()
            {
                Id = Guid.Parse("d385bf53-6e41-4ea3-8c7f-729c6893466f"),
                SenderId = Guid.Parse("1456c79b-7080-4586-8467-900a3cb033fe"),
                ProjectId = Guid.Parse("0c1b871b-4ed5-4299-aec4-d59054b07c54"),
                Title = "A user-friendly request.",
                Description = "It would be nice, when deleting any kind of data, a window to pop up for reassurance of my action.",
                ReleaseDate = DateTime.Parse("23-11-2022"),
                State = Enums.Tickets.States.New,
                Type = Enums.Tickets.Types.FeatureRequest,
            };
            tickets.Add(ticket);

            return tickets;
        }
    }
}
