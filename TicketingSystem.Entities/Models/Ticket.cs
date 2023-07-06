using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using TicketingSystem.Entities.Enums.Tickets;

namespace TicketingSystem.Entities.Models
{
    public class Ticket
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public Guid SenderId { get; set; }

        [Required]
        public Guid ProjectId { get; set; }

        [Required]
        public DateTime ReleaseDate { get; set; }

        [Required]
        [StringLength(50)]
        public string Title { get; set; }

        [StringLength(300)]
        public string? Description { get; set; }

        [Required]
        public Types Type { get; set; }

        [Required]
        public States State { get; set; }

        [ForeignKey(nameof(SenderId))]
        public User Sender { get; set; }

        [ForeignKey(nameof(ProjectId))]
        public Project Project { get; set; }

        public byte[]? Files { get; set; }

        public ICollection<Message> Messages { get; set; } = new HashSet<Message>();
    }
}
