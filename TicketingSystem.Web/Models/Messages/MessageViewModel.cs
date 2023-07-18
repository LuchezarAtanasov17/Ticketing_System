using TicketingSystem.Entities.Enums.Messages;
using TicketingSystem.Web.Models.Tickets;
using TicketingSystem.Web.Models.Users;

namespace TicketingSystem.Web.Models.Messages
{
    public class MessageViewModel
    {
        public Guid Id { get; set; }

        public Guid? AuthorId { get; set; }

        public Guid TicketId { get; set; }

        public DateTime PublishedOn { get; set; }

        public States? State { get; set; }

        public string Content { get; set; }

        public UserViewModel? Author { get; set; }

        public byte[]? Files { get; set; }
    }
}
