using TicketingSystem.Entities.Enums.Tickets;
using TicketingSystem.Web.Models.Messages;
using TicketingSystem.Web.Models.Projects;
using TicketingSystem.Web.Models.Users;

namespace TicketingSystem.Web.Models.Tickets
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

        public UserViewModel Sender { get; set; }

        public ProjectViewModel Project { get; set; }

        public byte[]? Files { get; set; }

        public ICollection<MessageViewModel> Messages { get; set; }
    }
}
