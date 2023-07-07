using TicketingSystem.Web.Models.Tickets;

namespace TicketingSystem.Web.Models.Projects
{
    public class ProjectViewModel
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string? Description { get; set; }

        public ICollection<TicketViewModel> Tickets { get; set; }
    }
}
