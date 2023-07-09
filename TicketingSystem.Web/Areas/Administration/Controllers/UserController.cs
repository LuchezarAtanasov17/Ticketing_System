using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using TicketingSystem.Entities.Data.Common;
using TicketingSystem.Entities.Models;
using TicketingSystem.Web.Models.Users;

namespace TicketingSystem.Web.Areas.Administration.Controllers
{
    public class UserController : BaseController
    {
        private IRepository _repo;

        public UserController(IRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> List()
        {
            var users = await _repo.All<User>()
                .Where(x => x.Id != Guid.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value))
                .Select(x => new UserViewModel
                {
                    Id = x.Id,
                    UserName = x.UserName,
                    Email = x.Email,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                })
                .ToListAsync();

            return View(users);
        }

        [HttpGet]
        public async Task<IActionResult> Update(
            [FromRoute]
            Guid id)
        {
            var entityUser = await _repo.GetByIdAsync<User>(id);
            
            var user = new UpdateUserRequest()
            {
                UserName = entityUser.UserName,
                FirstName = entityUser.FirstName,
                LastName = entityUser.LastName,
                Email = entityUser.Email,
            };

            return View(user);
        }

        [HttpPost]
        public async Task<IActionResult> Update(
            [FromRoute]
            Guid id,
            UpdateUserRequest request)
        {
            var entityUser = await _repo.GetByIdAsync<User>(id);

            entityUser.UserName = request.UserName;
            entityUser.Email = request.Email;
            entityUser.FirstName = request.FirstName;
            entityUser.LastName = request.LastName;

            await _repo.SaveChangesAsync();

            return RedirectToAction(nameof(List));
        }

        public async Task<IActionResult> Delete(Guid id)
        {
            await _repo.DeleteAsync<User>(id);
            await _repo.SaveChangesAsync();

            return RedirectToAction(nameof(List));
        }
    }
}
