using TicketingSystem.Entities.Enums.Tickets;

namespace TicketingSystem.Web.Models.Tickets
{
    public class UpdateTicketViewModel
    {
        public Guid Id { get; set; }

        public List<Types>? Types { get; set; }

        public Types Type { get; set; }

        public List<States>? States { get; set; }

        public States State { get; set; }
    }
}
