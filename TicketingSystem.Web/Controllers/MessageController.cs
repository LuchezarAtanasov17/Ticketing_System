using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using TicketingSystem.Entities.Data.Common;
using TicketingSystem.Entities.Models;
using TicketingSystem.Web.Models.Messages;
using TicketingSystem.Web.Models.Tickets;

namespace TicketingSystem.Web.Controllers
{
    [Authorize]
    public class MessageController : Controller
    {
        private IRepository _repo;

        public MessageController(IRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> List()
        {
            var projects = await _repo.All<Message>()
                .Select(p => new MessageViewModel()
                {
                    Id = p.Id,
                    AuthorId = p.AuthorId,
                    Content = p.Content,
                    PublishedOn = p.PublishedOn,
                    State = p.State,
                    TicketId = p.TicketId
                })
                .ToListAsync();

            return View(projects);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(
            TicketViewModelPartial request,
            Guid ticketId)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            var message = new Message()
            {
                TicketId = ticketId,
                AuthorId = Guid.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value),
                State = Entities.Enums.Messages.States.Published,
                Content = request.CreateMessageRequest.Content,
                PublishedOn = DateTime.UtcNow,
            };

            await _repo.AddAsync(message);
            await _repo.SaveChangesAsync();

            return RedirectToAction("Get", "Ticket", new {id = ticketId});
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateDraft(
            TicketViewModelPartial request,
            Guid ticketId)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            var message = new Message()
            {
                TicketId = ticketId,
                AuthorId = Guid.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value),
                State = Entities.Enums.Messages.States.Draft,
                Content = request.CreateMessageRequest.Content,
                PublishedOn = DateTime.UtcNow,
            };

            await _repo.AddAsync(message);
            await _repo.SaveChangesAsync();

            return RedirectToAction("Get", "Ticket", new { id = ticketId });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateDraft(
            TicketViewModelPartial request,
            Guid ticketId)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            var message = await _repo.GetByIdAsync<Message>(request.UpdateDraftMessageRequest.MessageId);
            message.Content = request.UpdateDraftMessageRequest.Content;

            await _repo.SaveChangesAsync();

            return RedirectToAction("Get", "Ticket", new { id = ticketId });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SendDraft(
            TicketViewModelPartial request,
            Guid ticketId)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            var message = await _repo.GetByIdAsync<Message>(request.UpdateDraftMessageRequest.MessageId);
            message.Content = request.UpdateDraftMessageRequest.Content;
            message.State = Entities.Enums.Messages.States.Published;

            await _repo.SaveChangesAsync();

            return RedirectToAction("Get", "Ticket", new { id = ticketId });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteDraft(
            TicketViewModelPartial request,
            Guid ticketId)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            await _repo.DeleteAsync<Message>(request.UpdateDraftMessageRequest.MessageId);
            await _repo.SaveChangesAsync();

            return RedirectToAction("Get", "Ticket", new { id = ticketId });
        }
    }
}
