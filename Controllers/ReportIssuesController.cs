using Microsoft.AspNetCore.Mvc;
using PROG_3B_ST10255309.Models;
using PROG_3B_ST10255309.Services;
using System.IO;
using System.Threading.Tasks;

namespace PROG_3B_ST10255309.Controllers
{
    public class ReportIssuesController : Controller
    {
        private static ServiceRequest _servicereq = new ServiceRequest();

        [HttpGet]
        public IActionResult Reports()
        {
            return View();
        }

        //Method to capture users report issues and their media attatchment
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SubmitReport(Report report)
        {
            if (!ModelState.IsValid)
            {
                TempData["ErrorMessage"] = "Please fill out all required fields.";
                return View("Reports", report);
            }

            if (report.MediaAttachment != null && report.MediaAttachment.Length > 0)
            {
                var fileName = Path.GetFileName(report.MediaAttachment.FileName);
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/uploads", fileName);

                //Ensure the uploads folder exists
                if (!Directory.Exists(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/uploads")))
                    Directory.CreateDirectory(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/uploads"));

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await report.MediaAttachment.CopyToAsync(stream);
                }
            }

            //Adding the completed report
            _servicereq.AddRequest(report);

            TempData["SuccessModel"] = true;
            return RedirectToAction("Reports");
        }

    }
}
//Dash, D. (2015). How To Upload Image And Save Image In Project Folder In MVC. [online] C-sharpcorner.com. Available at: https://www.c-sharpcorner.com/blogs/how-to-upload-image-and-save-image-in-project-folder-in-mvc1 [Accessed 9 Sep. 2025].