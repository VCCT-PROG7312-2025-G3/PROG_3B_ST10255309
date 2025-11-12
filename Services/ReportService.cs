using PROG_3B_ST10255309.Models;

namespace PROG_3B_ST10255309.Services
{
    public class ReportService
    {
        //Linked list for storing reports
        private static LinkedList<Report> _reports = new LinkedList<Report>();
        private static int _nextId = 1;

        //Adding a new report to the Linked List
        public void AddingReport(Report report)
        {
            report.Id = _nextId++;
            report.DateSubmitted = DateTime.Now;
            _reports.AddLast(report);
        }

        //Fetching all the reports from the Linked List
        public LinkedList<Report> GetAllReports()
        {
            return _reports;
        }

        //Fetching report by Id
        public Report GetReportId(int id)
        {
            foreach(var report in _reports)
            {
                if(report.Id == id)
                {
                    return report;
                }
            }
            return null;
        }

        //Get the toal count of reports
        public int GetReportCount()
        {
            return _reports.Count;
        }

        //Predefined categories
        public List<string> GetCategories()
        {
            return new List<string>
            {
                "Roads",
                "Water",
                "Electricity",
                "Waste",
                "Safety",
                "Other"
            };
        }
    }
}
// BetterCoder (2012b). C# LinkedList Tutorial - 3 - Beginning the LinkedList Class. [online] YouTube. Available at: https://www.youtube.com/watch?v=DTZlz8KsSSQ&list=PL3iOx6lykrwrlVijTcZI3l8Hz_9W3Pb9F&index=3 [Accessed 9 Sep. 2025].
// BetterCoder (2012c). C# LinkedList Tutorial - 4 - The Add methods. [online] YouTube. Available at: https://www.youtube.com/watch?v=9pw8dc2Tmpg&list=PL3iOx6lykrwrlVijTcZI3l8Hz_9W3Pb9F&index=4 [Accessed 9 Sep. 2025].