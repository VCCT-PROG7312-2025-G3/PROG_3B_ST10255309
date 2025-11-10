using PROG_3B_ST10255309.Models;
using PROG_3B_ST10255309.DataStructures;

namespace PROG_3B_ST10255309.Services
{
    public class ServiceRequest
    {
        // Binary Search tree for managing issue requests
        private static IssueRequest request = new IssueRequest();

        // Graph for managing status progressions
        private static ServiceStatus service = new ServiceStatus();

        // Linked list for storing all reports
        private static LinkedList<Report> reports = new LinkedList<Report>();

        private static int nextId = 1;

        // Adding a new report
        public void AddRequest(Report report)
        {
            report.Id = nextId++;
            report.DateSubmitted = DateTime.Now;
            report.Status = "Submitted";

            // Adding a report to the Linked List
            reports.AddLast(report);

            // Adding a report to the tree
            request.Insert(report);
        }

        // Searching for a report by ID
        public Report GetReportId(int id)
        {
            return request.Search(id);
        }

        // Getting all reports
        public List<Report> GetAllReports()
        {
            return request.GetOrdered();
        }

        // Getting reports by their status
        public List<Report> GetRequestsByStatus(string status)
        {
            return request.GetOrdered().Where(r => r.Status == status).ToList();
        }

        // Progressing through a reports status
        public bool UpdateStatus(int id, string nextStatus)
        {
            var request = GetReportId(id);
            if (request == null)
                return false;
            
            // Validating the progression
            if(service.ValidProgress(request.Status, nextStatus))
            {
                request.Status = nextStatus;
                return true;
            }

            return false;
        }

        // Getting the next status
        public List<string> GetNextStatuses(string current)
        {
            return service.GetNextStatus(current);
        }

        // Getting all of the statuses
        public List<string> GetAllStatuses()
        {
            return service.GetStatus();
        }

        // Getting the total reports count
        public int GetRequestCount()
        {
            return request.Count();
        }

        // Get reports by category
        public List<Report> SearchByCategory(string category)
        {
            return request.GetOrdered().Where(r => r.Category.Equals(category, StringComparison.OrdinalIgnoreCase)).ToList();
        }

        // Getting the statistics of each status
        public Dictionary<string, int> GetStatusStatistics()
        {
            var stats = new Dictionary<string, int>();
            foreach (var status in GetAllStatuses())
            {
                stats[status] = GetRequestsByStatus(status).Count;
            }
            return stats;
        }
    }
}
