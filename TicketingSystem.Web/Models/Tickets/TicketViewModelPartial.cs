﻿using TicketingSystem.Entities.Enums.Tickets;
using TicketingSystem.Web.Models.Messages;

namespace TicketingSystem.Web.Models.Tickets
{
    public class TicketViewModelPartial
    {
        public Guid TicketId { get; set; }

        public Guid TicketSenderId { get; set; }

        public States State { get; set; }

        public CreateMessageRequest? CreateMessageRequest { get; set; }

        public List<MessageViewModel>? Messages { get; set; }

        public UpdateDraftMessageRequest? UpdateDraftMessageRequest { get; set; }
    }
}
