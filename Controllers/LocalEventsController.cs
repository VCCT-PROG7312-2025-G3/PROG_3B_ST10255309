using Microsoft.AspNetCore.Mvc;

namespace PROG_3B_ST10255309.Controllers
{
    public class LocalEventsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Events()
        {
            {
                return View();
            }
        }
    }
}