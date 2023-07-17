using Microsoft.AspNetCore.Mvc;
using TicketingSystem.Entities.Data.Common;
using TicketingSystem.Entities.Models;
using TicketingSystem.Web.Models.Projects;

namespace TicketingSystem.Web.Areas.Administration.Controllers
{
    public class ProjectController : BaseController
    {
        private IRepository _repo;

        public ProjectController(IRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var model = new CreateProjectRequest()
            {
            };

            return View("CreateProjectForm", model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(
            CreateProjectRequest request)
        {
            if (request is null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            if (!ModelState.IsValid)
            {
                return View(request);
            }

            var project = new Project()
            {
                Name = request.Name,
                Description = request.Description
            };

            await _repo.AddAsync(project);
            await _repo.SaveChangesAsync();

            return RedirectToAction("List", "Project");
        }

        public async Task<IActionResult> Delete(
           [FromRoute]
            Guid id)
        {
            await _repo.DeleteAsync<Project>(id);
            await _repo.SaveChangesAsync();

            return RedirectToAction("List", "Project");
        }
    }
}
