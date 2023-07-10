using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TicketingSystem.Entities.Data.Common;
using TicketingSystem.Entities.Models;
using TicketingSystem.Web.Models.RegisterRequest;

namespace TicketingSystem.Web.Areas.Administration.Controllers
{
    public class RegisterRequestController : BaseController
    {
        private IRepository _repo;

        public RegisterRequestController(IRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> List()
        {
            var requests = await _repo
                .All<RegisterRequest>()
                .Where(x=>x.User.IsApproved == false)
                .Select(x=>new RegisterRequestViewModel
                {
                    Id = x.Id,
                    UserId = x.UserId,
                    CreatedOn= x.CreatedOn,
                    User = new Models.Users.UserViewModel()
                    {
                        FirstName= x.User.FirstName, 
                        LastName= x.User.LastName,
                        Email= x.User.Email,
                        Id=x.Id,
                        UserName= x.User.UserName,
                    },
                })
                .ToListAsync();

            return View(requests);
        }

        [HttpGet]
        public async Task<IActionResult> Decline(
            [FromRoute]
            Guid id)
        {
            var request = await _repo.GetByIdAsync<RegisterRequest>(id);
            await _repo.DeleteAsync<RegisterRequest>(id);

            await _repo.DeleteAsync<User>(request.UserId);

            await _repo.SaveChangesAsync();

            return RedirectToAction(nameof(List));
        }

        [HttpGet]
        public async Task<IActionResult> Approve(
            [FromRoute]
            Guid id)
        {
            var request = await _repo.GetByIdAsync<RegisterRequest>(id);
            await _repo.DeleteAsync<RegisterRequest>(id);

            var user = await _repo.GetByIdAsync<User>(request.UserId);
            user.IsApproved = true;

            await _repo.SaveChangesAsync();

            return RedirectToAction(nameof(List));
        }

    }
}
