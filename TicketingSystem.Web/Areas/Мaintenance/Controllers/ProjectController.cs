using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TicketingSystem.Entities.Data.Common;
using TicketingSystem.Entities.Models;
using TicketingSystem.Web.Models.Projects;

namespace TicketingSystem.Web.Areas.Мaintenance.Controllers
{
    public class ProjectController : BaseController
    {
        private IRepository _repo;

        public ProjectController(IRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> List()
        {
            var projects = await _repo.All<Project>()
                .Select(p => new ProjectViewModel()
                {
                    Id = p.Id,
                    Name = p.Name,
                    Description = p.Description,
                })
                .ToListAsync();

            return View(projects);
        }

        [HttpGet]
        public async Task<IActionResult> Get(
            [FromRoute]
            Guid id)
        {
            var entityProject = await _repo.GetByIdAsync<Project>(id);

            ProjectViewModel project = new ProjectViewModel()
            {
                Id = entityProject.Id,
                Name = entityProject.Name,
                Description = entityProject.Description,
            };

            return View("Details", project);
        }
    }
}
