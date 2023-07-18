using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Security.Claims;
using TicketingSystem.Entities.Data.Common;
using TicketingSystem.Entities.Enums.Tickets;
using TicketingSystem.Entities.Models;
using TicketingSystem.Web.Models.Messages;
using TicketingSystem.Web.Models.Projects;
using TicketingSystem.Web.Models.Tickets;
using TicketingSystem.Web.Models.Users;

namespace TicketingSystem.Web.Areas.Maintenance.Controllers
{
    public class TicketController : BaseController
    {
        private IRepository _repo;

        public TicketController(IRepository repo) 
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> List()
        {
            var tickets = await _repo.All<Ticket>()
                .Where(x=>x.SenderId != Guid.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value))
                .Select(p => new TicketViewModel()
                {
                    Id = p.Id,
                    Description = p.Description,
                    Type = p.Type,
                    State = p.State,
                    Title = p.Title,
                    SenderId = p.SenderId,
                    ProjectId = p.ProjectId,
                    Files = p.Files,
                    ReleaseDate = p.ReleaseDate,
                    Sender = new UserViewModel()
                    {
                        UserName = p.Sender.UserName,
                        Email = p.Sender.Email,
                        Id = p.Id,
                        FirstName = p.Sender.FirstName,
                        LastName = p.Sender.LastName,
                    }
                })
                .ToListAsync();

            return View("List", tickets);
        }

        [HttpGet]
        public async Task<IActionResult> Get(
           [FromRoute]
            Guid id)
        {
            var entityProject = await _repo.GetByIdAsync<Ticket>(id);
            var enitityUser = await _repo.GetByIdAsync<User>(entityProject.SenderId);
            var entityMessages = await _repo
                .All<Message>()
                .Where(x=>x.TicketId == id)
                .Select(x => new MessageViewModel()
                {
                    Id = x.Id,
                    AuthorId = x.AuthorId,
                    Content = x.Content,
                    PublishedOn = x.PublishedOn,
                    State = x.State,
                    Files = x.Files,
                    Author = new UserViewModel()
                    {
                        Id = x.Author.Id,
                        Email = x.Author.Email,
                        FirstName = x.Author.FirstName,
                        LastName = x.Author.LastName,
                        UserName = x.Author.UserName,
                    }
                })
                .ToListAsync();

            UserViewModel userViewModel = new UserViewModel()
            {
                Email = enitityUser.Email,
                FirstName = enitityUser.FirstName,
                LastName = enitityUser.LastName,
                Id = entityProject.Id,
                UserName = enitityUser.UserName,
            };

            TicketViewModel ticket = new TicketViewModel()
            {
                Id = entityProject.Id,
                Description = entityProject.Description,
                Type = entityProject.Type,
                State = entityProject.State,
                Title = entityProject.Title,
                SenderId = entityProject.SenderId,
                ProjectId = entityProject.ProjectId,
                Files = entityProject.Files,
                ReleaseDate = entityProject.ReleaseDate,
                Sender = userViewModel,
                Messages = entityMessages
            };

            return View("Details", ticket);
        }

        [HttpGet]
        public async Task<IActionResult> Create(Guid id)
        {
            var project = await _repo.GetByIdAsync<Project>(id);

            var model = new CreateTicketRequest()
            {
                ProjectId = id,
                Project = new ProjectViewModel()
                {
                    Id = project.Id,
                    Name = project.Name,
                    Description = project.Description,
                },
                States = Enum.GetValues<States>().ToList(),
                Types = Enum.GetValues<Types>().ToList(),
            };

            return View("CreateTicketForm", model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(
            Guid projectId,
            CreateTicketRequest request)
        {
            if (request is null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            if (!ModelState.IsValid)
            {
                return View(request);
            }

            request.SenderId = Guid.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
            request.State = States.New;
            request.ReleaseDate = DateTime.UtcNow;

            var ticket = new Ticket()
            {
                ReleaseDate = request.ReleaseDate,
                Description = request.Description,
                Files = request.Files,
                ProjectId = request.ProjectId,
                SenderId = request.SenderId,
                Title = request.Title,
                State = request.State,
                Type = request.Type,
            };

            await _repo.AddAsync(ticket);
            await _repo.SaveChangesAsync();

            return RedirectToAction("Get", "Project", new { id = projectId });
        }

        [HttpGet]
        public async Task<IActionResult> Update(
            [FromRoute]
            Guid id)
        {
            var ticket = await _repo.GetByIdAsync<Ticket>(id);

            var model = new UpdateTicketViewModel()
            {
                Id = id,
                Type = ticket.Type,
                States = Enum.GetValues<States>().ToList(),
                State= ticket.State,
                Types = Enum.GetValues<Types>().ToList(),
            };

            return View("Update", model);
        }

        [HttpPost]
        public async Task<IActionResult> Update(Guid id, UpdateTicketViewModel request)
        {
            if (!ModelState.IsValid)
            {
                return View(request);
            }

            var entityTicket = await _repo.GetByIdAsync<Ticket>(id);

            entityTicket.State = request.State;
            entityTicket.Type= request.Type;

            await _repo.SaveChangesAsync();
            
            return RedirectToAction(nameof(Get), new { Id = id });
        }

        public async Task<IActionResult> Delete(
           [FromRoute]
            Guid id)
        {
            await _repo.DeleteAsync<Ticket>(id);
            await _repo.SaveChangesAsync();

            return RedirectToAction(nameof(List));
        }
    }
}
