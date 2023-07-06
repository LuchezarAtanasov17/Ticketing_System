using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using TicketingSystem.Entities.Models;
using TicketingSystem.Entities.Enums.Messages;

namespace TicketingSystem.Web.Models
{
    public class MessageViewModel
    {
        public Guid Id { get; set; }

        public Guid AuthorId { get; set; }

        public DateTime PublishedOn { get; set; }

        public string State { get; set; }

        public string Content { get; set; }

        public User Author { get; set; }

        public byte[]? Files { get; set; }
    }
}
