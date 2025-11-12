using Microsoft.AspNetCore.Mvc;
using PROG_3B_ST10255309.Services;
using PROG_3B_ST10255309.Models;

namespace PROG_3B_ST10255309.Controllers
{
    public class StatusController : Controller
    {
        private static ServiceRequest _servicereq = new ServiceRequest();

        //Displaying all the issue requests 
        [HttpGet]
        public IActionResult RequestStatus()
        {
            var reports = _servicereq.GetAllReports();
            

            //Passing data to the view
            ViewBag.Statuses = _servicereq.GetAllStatuses();
            ViewBag.TotalReports = _servicereq.GetRequestCount();
            ViewBag.StatusStats = _servicereq.GetStatusStatistics();

            return View(reports);
        }

        //Filter the issue requests 
        [HttpGet]
        public IActionResult FilterStatus(string statuses)
        {
            List<Report> reports;

            //Filter by status
            if (!string.IsNullOrEmpty(statuses))
            {
                reports = _servicereq.GetRequestsByStatus(statuses);
            }
            else
            {
                reports = _servicereq.GetAllReports();
            }

            //Passing data to the view
            ViewBag.Statuses = _servicereq.GetAllStatuses();
            ViewBag.SelectedStatus = statuses;
            ViewBag.TotalReports = _servicereq.GetRequestCount();
            ViewBag.StatusStats = _servicereq.GetStatusStatistics();

            return View("RequestStatus", reports);
        }

        //Manage status updates
        [HttpGet]
        public IActionResult ManageStatuses()
        {
            var reports = _servicereq.GetAllReports();
            ViewBag.Statuses = _servicereq.GetAllStatuses();
            ViewBag.StatusStats = _servicereq.GetStatusStatistics();

            return View(reports);
        }

        //Updating the status of a report
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult UpdateStatus(int id, string newStatus)
        {
            bool updates = _servicereq.UpdateStatus(id, newStatus);

            if (updates)
            {
                TempData["SuccessMessage"] = "Status updated successfully";
            }
            else
            {
                TempData["ErrorMessage"] = "Failed to update status";
            }

            return RedirectToAction("RequestStatus");
        }
    }
}
//tdykstra (2024). Views in ASP.NET Core MVC. [online] Microsoft.com. Available at: https://learn.microsoft.com/en-us/aspnet/core/mvc/views/overview?view=aspnetcore-9.0 [Accessed 14 Oct. 2025].