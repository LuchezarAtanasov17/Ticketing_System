using System.ComponentModel.DataAnnotations;
using TicketingSystem.Entities.Models;

namespace TicketingSystem.Web.Models
{
    public class ProjectViewModel
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string? Description { get; set; }

        public ICollection<Ticket> Tickets { get; set; }
    }
}
