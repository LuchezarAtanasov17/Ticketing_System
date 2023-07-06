using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using TicketingSystem.Entities.Enums.Tickets;
using TicketingSystem.Entities.Models;

namespace TicketingSystem.Web.Models
{
    public class TicketViewModel
    {
        public Guid Id { get; set; }

        public Guid SenderId { get; set; }

        public Guid ProjectId { get; set; }

        public DateTime ReleaseDate { get; set; }

        public string Title { get; set; }

        public string? Description { get; set; }

        public Types Type { get; set; }

        public States State { get; set; }

        public User Sender { get; set; }

        public Project Project { get; set; }

        public byte[]? Files { get; set; }

        public ICollection<Message> Messages { get; set; }
    }
}
