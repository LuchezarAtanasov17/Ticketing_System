using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace TicketingSystem.Entities.Models
{
    public class User : IdentityUser<Guid>
    {
        [Required]
        [StringLength(30)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(30)]
        public string LastName { get; set; }

        public bool IsApproved { get; set; }

        public RegisterRequest? RegisterRequest { get; set; }

        public ICollection<Message> Messages { get; set; } = new HashSet<Message>();
    }
}
