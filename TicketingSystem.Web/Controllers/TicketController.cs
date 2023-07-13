using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using TicketingSystem.Entities.Data.Common;
using TicketingSystem.Entities.Enums.Tickets;
using TicketingSystem.Entities.Models;
using TicketingSystem.Web.Models.Messages;
using TicketingSystem.Web.Models.Projects;
using TicketingSystem.Web.Models.Tickets;
using TicketingSystem.Web.Models.Users;

namespace TicketingSystem.Web.Controllers
{
    [Authorize]
    public class TicketController : Controller
    {
        private IRepository _repo;

        public TicketController(IRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> ListMine()
        {
            var tickets = await _repo.All<Ticket>()
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
                        Id= p.Id,
                        FirstName = p.Sender.FirstName,
                        LastName = p.Sender.LastName,
                    }
                })
                .Where(x => x.SenderId == Guid.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value))
                .ToListAsync();

            return View("ListMine", tickets);
        }

        [HttpGet]
        public async Task<IActionResult> Get(
           [FromRoute]
            Guid id)
        {
            var entityTicket = await _repo.GetByIdAsync<Ticket>(id);
            var enitityUser = await _repo.GetByIdAsync<User>(entityTicket.SenderId);
            var entityMessages = await _repo
                .All<Message>()
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
                        Id= x.Author.Id,
                        Email = x.Author.Email,
                        FirstName= x.Author.FirstName,
                        LastName= x.Author.LastName,
                        UserName= x.Author.UserName,
                    }
                })
                .ToListAsync();

            UserViewModel userViewModel = new UserViewModel()
            {
                Email = enitityUser.Email,
                FirstName = enitityUser.FirstName,
                LastName = enitityUser.LastName,
                Id = entityTicket.Id,
                UserName = enitityUser.UserName,
            };

            TicketViewModel ticket = new TicketViewModel()
            {
                Id = entityTicket.Id,
                Description = entityTicket.Description,
                Type = entityTicket.Type,
                State = entityTicket.State,
                Title = entityTicket.Title,
                SenderId = entityTicket.SenderId,
                ProjectId = entityTicket.ProjectId,
                Files = entityTicket.Files,
                ReleaseDate = entityTicket.ReleaseDate,
                Sender = userViewModel,
                Messages= entityMessages,
                CreateMessageRequest = new CreateMessageRequest()
                {
                    TicketId= id,
                }
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



        public async Task<IActionResult> DeleteMine(
           [FromRoute]
            Guid id)
        {
            await _repo.DeleteAsync<Ticket>(id);
            await _repo.SaveChangesAsync();

            return RedirectToAction(nameof(ListMine));
        }
    }
}
