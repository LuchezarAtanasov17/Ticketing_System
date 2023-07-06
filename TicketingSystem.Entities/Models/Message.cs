using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        public DateTime PublishedOn { get; set; }

        [Required]
        public States State { get; set; }

        [Required]
        [StringLength(600)]
        public string Content { get; set; }

        [ForeignKey(nameof(AuthorId))]
        public User Author { get; set; }
        
        public byte[]? Files { get; set; }

    }
}
