using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace TicketingSystem.Web.Areas.Мaintenance.Controllers
{
    [Area("Maintenance")]
    [Route("/Maintenance/[controller]/[Action]/{id?}")]
    [Authorize(Roles = "Maintenance")]
    public class BaseController : Controller
    {
    }
}
