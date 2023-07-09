using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace TicketingSystem.Web.Areas.Maintenance.Controllers
{
    [Area("Maintenance")]
    [Route("/Maintenance/[controller]/[Action]/{id?}")]
    [Route("/Administrator/[controller]/[Action]/{id?}")]
    [Authorize(Roles = "Maintenance , Administrator")]
    public class BaseController : Controller
    {
    }
}
