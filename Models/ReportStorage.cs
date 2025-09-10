using System.Collections.Generic;

namespace PROG_3B_ST10255309.Models
{
    public class ReportStorage
    {
        public static LinkedList<Report> Reports = new LinkedList<Report>();
        public static void AddReport(Report report)
        {
            Reports.AddLast(report);
        }


    }
}
// BetterCoder (2012b). C# LinkedList Tutorial - 3 - Beginning the LinkedList Class. [online] YouTube. Available at: https://www.youtube.com/watch?v=DTZlz8KsSSQ&list=PL3iOx6lykrwrlVijTcZI3l8Hz_9W3Pb9F&index=3 [Accessed 9 Sep. 2025].
// BetterCoder (2012c). C# LinkedList Tutorial - 4 - The Add methods. [online] YouTube. Available at: https://www.youtube.com/watch?v=9pw8dc2Tmpg&list=PL3iOx6lykrwrlVijTcZI3l8Hz_9W3Pb9F&index=4 [Accessed 9 Sep. 2025].