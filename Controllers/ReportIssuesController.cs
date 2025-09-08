using Microsoft.AspNetCore.Mvc;

namespace PROG_3B_ST10255309.Controllers
{
    public class ReportIssuesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Reports()
        {
            return View();
        }
    }
}
