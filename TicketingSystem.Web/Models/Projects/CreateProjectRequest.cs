﻿using TicketingSystem.Web.Models.Tickets;

namespace TicketingSystem.Web.Models.Projects
{
    public class CreateProjectRequest
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string? Description { get; set; }
    }
}