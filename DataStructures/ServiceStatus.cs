namespace PROG_3B_ST10255309.DataStructures
{
    public class ServiceStatus
    {
        //Adjacency List for the graph
        private Dictionary<string, List<string>> adjList;

        public ServiceStatus()
        {
            adjList = new Dictionary<string, List<string>>();
            BuildGraph();
        }

        //Method to show how the reports status progresses
        private void BuildGraph()
        {
            //First starts at "Submitted" then once it progresses it moves to "In Progress"
            adjList["Submitted"] = new List<string> { "In Progress" };
            //"In Progress" then progresses to "Completed"
            adjList["In Progress"] = new List<string> { "Completed" };
            //"Completed' is final progression
            adjList["Completed"] = new List<string>();
        }

        //Method to progress and get the next progression
        public List<string> GetNextStatus(string currentStatus)
        {
            if(adjList.ContainsKey(currentStatus))
            {
                return adjList[currentStatus];
            }
            return new List<string>();
        }

        //Method to validate each progression
        public bool ValidProgress(string start, string next)
        {
            if (adjList.ContainsKey(start))
            {
                return adjList[start].Contains(next);
            }
            return false;
        }

        //Method to get all the statuses
        public List<string> GetStatus()
        {
            return new List<string> { "Submitted", "In Progress", "Completed" };
        }

        //Method to get the % completed
        public int GetPercentage(string status)
        {
            return status switch
            {
                "Submitted" => 10,
                "In Progress" => 50,
                "Completed" => 100,
                _ => 0
            };
        }
    }
}
// ELIP(2020).How to create Status Chart. [online] Stack Overflow. Available at: https://stackoverflow.com/questions/62567627/how-to-create-status-chart [Accessed 10 Nov. 2025].
// GeeksforGeeks (2025). Graph and its representations. [online] GeeksforGeeks. Available at: https://www.geeksforgeeks.org/dsa/graph-and-its-representations/ [Accessed 10 Nov. 2025].