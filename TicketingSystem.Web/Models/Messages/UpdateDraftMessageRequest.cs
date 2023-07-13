namespace TicketingSystem.Web.Models.Messages
{
    public class UpdateDraftMessageRequest
    {
        public Guid MessageId { get; set; }

        public Guid TicketId { get; set; }

        public string Content { get; set; }
    }
}
