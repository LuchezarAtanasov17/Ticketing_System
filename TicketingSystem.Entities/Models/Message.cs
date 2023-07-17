using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TicketingSystem.Entities.Enums.Messages;

namespace TicketingSystem.Entities.Models
{
    public class Message
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public Guid AuthorId { get; set; }

        [Required]
        public Guid TicketId { get; set; }

        [Required]
        public DateTime PublishedOn { get; set; }

        [Required]
        public States State { get; set; }

        [Required]
        [StringLength(600)]
        public string Content { get; set; }

        [ForeignKey(nameof(AuthorId))]
        public User Author { get; set; }

        [ForeignKey(nameof(TicketId))]
        public Ticket Ticket { get; set; }

        public byte[]? Files { get; set; }

    }
}
