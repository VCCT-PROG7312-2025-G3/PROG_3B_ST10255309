using Microsoft.AspNetCore.Mvc;
using PROG_3B_ST10255309.Models;

namespace PROG_3B_ST10255309.Controllers
{
    public class FeedbackController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Questions()
        {
            return View();
        }

        //Method to capture users feedback
        [HttpPost]
        public IActionResult SubmitFeedback(UserFeedback feedback)
        {
            if (!ModelState.IsValid)
            {
                TempData["ErrorMessage"] = "Please fill out this field to submit a form.";
                return View(feedback);
            }
            
            FeedbackStorage.AddFeedback(feedback);
            TempData["SuccessMessage"] = "Thank you for your feedback!";
            return RedirectToAction("Questions");


        }
    }
}
