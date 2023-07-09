namespace TicketingSystem.Web.Models.Users
{
    public class UpdateUserRequest
    {
        public string UserName { get; set; } = null!;

        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public string Email { get; set; } = null!;
    }
}
