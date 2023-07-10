using TicketingSystem.Web.Models.Users;

namespace TicketingSystem.Web.Models.RegisterRequest
{
    public class RegisterRequestViewModel
    {
        public Guid Id { get; set; }

        public Guid UserId { get; set; }

        public UserViewModel User { get; set; }

        public DateTime CreatedOn { get; set; }
    }
}
