using PROG_3B_ST10255309.Models;

namespace PROG_3B_ST10255309.Services
{
    public class RecommendationService
    {

        // Tracking user searches by category
        private static Dictionary<string, int> categoryCount = new Dictionary<string, int>();

        // Tracking user searches by month
        private static Dictionary<string, int> monthCount = new Dictionary<string, int>();

        // Method to log user searches
        public void RecordSearch(string category, DateTime? dateSearch)
        {
            if (!string.IsNullOrWhiteSpace(category) && category != "All")
            {
                // Tracking what category the user searches for
                if(categoryCount.ContainsKey(category))
                {
                    categoryCount[category]++;
                }
                else
                {
                    categoryCount[category] = 1;
                }
            }
            // Tracking the date the user searches for
            if(dateSearch.HasValue)
            {
                string month = dateSearch.Value.ToString("MMMMM yyyy");
                if (monthCount.ContainsKey(month))
                {
                    monthCount[month]++;
                }
                else
                {
                    monthCount[month] = 1;
                }
            }   
            
        }

        // Method to get the most searched category
        public string GetTopSearchedCategory()
        {
            if (categoryCount.Count == 0)
                return null;

            return categoryCount.OrderByDescending(c => c.Value).First().Key;
        }
        
        // Method to get the top 3 categories
        public List<string> GetTopCategory(int count = 3)
        {
            return categoryCount.OrderByDescending(c => c.Value).Take(count).Select(c => c.Key).ToList();
        }

        // Method to recommend events based on the most searched category
        public List<Event> GetRecommended(EventServices eventService, int max = 4)
        {
            var recommendedEvents = new List<Event>();
            // Fetch users top 3 searched categories
            var topCategory = GetTopCategory(3);

            if(topCategory.Count > 0)
            {
                // Recommending events based off of the searched categories
                foreach (var category in topCategory)
                {
                    var events = eventService.GetEventsByCategory(category).Where(e => e.Date.Date >= DateTime.Now.Date).OrderBy(e => e.Date).Take(max).ToList();
                    recommendedEvents.AddRange(events);
                }
            }
            else
            {
                // If there are no searches, recommend 2 events
                recommendedEvents = eventService.GetAllEvents().Where(e => e.Date.Date >= DateTime.Now.Date).OrderBy(e => e.Date).Take(2).ToList();
            }

            return recommendedEvents.Distinct().Take(max).ToList();
        }

        // Checking if the user has made any searches
        public bool History()
        {
            return categoryCount.Count > 0;
        }
    }
}
// Dictionary Class (System.Collections.Generic) (2024). [online] Microsoft.com. Available at: https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.dictionary-2?view=net-9.0 [Accessed 13 Oct. 2025].
// ScottClayton (2025). Building a Recommendation Engine in C# - CodeProject. [online] Codeproject.com. Available at: https://www.codeproject.com/articles/Building-a-Recommendation-Engine-in-Csharp [Accessed 15 Oct. 2025].