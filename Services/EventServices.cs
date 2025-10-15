using PROG_3B_ST10255309.Models;
using System;
using System.Collections.Generic;

namespace PROG_3B_ST10255309.Services
{
    public class EventServices
    {
        //Queue that manages the events
        private static Queue<Event> eventQueue = new Queue<Event>();

        // Dictionary that organizes events by their Id
        private static Dictionary<int, Event> eventDictionary = new Dictionary<int, Event>();

        // SortedDictionary that organizes events by their Date
        private static SortedDictionary<DateTime, List<Event>> eventDate = new SortedDictionary<DateTime, List<Event>>();

        // Dictionary that organizes events by their Category
        private static Dictionary<string, List<Event>> eventsCategory = new Dictionary<string, List<Event>>();

        // HashSet to store unique categories and dates
        private static HashSet <string> identifyCategory = new HashSet<string>();

        // HashSet to store unique dates
        private static HashSet<DateTime> identifyDate = new HashSet<DateTime>();

        private static int nextId = 1;

        // Defining all possible categories
        private static readonly List<string> allCategories = new List<string>()
        {
            "Sports",
            "Music",
            "Arts & Culture",
            "Community",
            "Education",
            "Health & Wellness",
            "Technology",
            "Entertainment",
            "Government",
            "Business",
            "Other"
        };

        //Adding a event to the data structures
        public void AddEvent(Event newEvent)
        {
            newEvent.Id = nextId++;
            // Adding an event to the queue
            eventQueue.Enqueue(newEvent);
            // Adding an event to the dictionary
            eventDictionary[newEvent.Id] = newEvent;
            // Adding an event to the sorted dictionary using date
            if (!eventDate.ContainsKey(newEvent.Date.Date))
            {
                eventDate[newEvent.Date.Date] = new List<Event>();
            }
            eventDate[newEvent.Date.Date].Add(newEvent);
            // Adding an event to the dictionary using category
            if (!eventsCategory.ContainsKey(newEvent.Category))
            {
                eventsCategory[newEvent.Category] = new List<Event>();
            }
            eventsCategory[newEvent.Category].Add(newEvent);
            // Adding to HashSet for unique categories and dates
            identifyCategory.Add(newEvent.Category);
            identifyDate.Add(newEvent.Date.Date);
        }

        //Retrieving all events
        public Queue<Event> GetEventQueue()
        {
            return new Queue<Event>(eventQueue);
        }

        //Retrieving events to display
        public List<Event> GetAllEvents()
        {
            return eventQueue.ToList();
        }

        //Retrieving event by ID
        public Event GetEventById(int id)
        {
            return eventDictionary.ContainsKey(id) ? eventDictionary[id] : null;
        }

        //Retrieving events by date
        public List<Event> GetEventsByDate(DateTime date)
        {
            return eventDate.ContainsKey(date.Date) ? eventDate[date.Date] : new List<Event>();
        }

        //Retrieving events by category
        public List<Event> GetEventsByCategory(string category)
        {
            return eventsCategory.ContainsKey(category) ? eventsCategory[category] : new List<Event>();
        }

        //Search events by date range
        public List<Event> SearchByDate(DateTime? startDate, DateTime? endDate)
        {
            var allEvents = GetAllEvents();
            // Filtering the search based on a date range
            if (startDate.HasValue && endDate.HasValue)
            {
                return allEvents.Where(e => e.Date.Date >= startDate.Value.Date && e.Date.Date <= endDate.Value.Date).ToList();
            }
            else if (startDate.HasValue)
            {
                return allEvents.Where(e => e.Date.Date >= startDate.Value.Date).ToList();
            }
            else if (endDate.HasValue)
            {
                return allEvents.Where(e => e.Date.Date <= endDate.Value.Date).ToList();
            }

            return allEvents;   
        }

        //Search events
        public List<Event> SearchEvents(string category, DateTime? startDate, DateTime? endDate)
        {
            var events = GetAllEvents();
            // Filtering the search based on category
            if (!string.IsNullOrEmpty(category) && category != "All")
            {
                events = events.Where(e => e.Category == category).ToList();
            }
            // Filtering the search based on a date range
            if (startDate.HasValue)
            {
                events = events.Where(e => e.Date.Date >= startDate.Value.Date).ToList();
            }

            if (endDate.HasValue)
            {
                events = events.Where(e => e.Date.Date <= endDate.Value.Date).ToList();
            }

            return events;
        }

        //Sorting events
        public List<Event> SortEvents(string sortBy, List<Event> events)
        {
            // Allowing the user to sort the events with the default being by date ascending
            return sortBy switch
            {
                "date_asc" => events.OrderBy(e => e.Date).ToList(),
                "date_desc" => events.OrderByDescending(e => e.Date).ToList(),
                "name_asc" => events.OrderBy(e => e.Name).ToList(),
                "name_desc" => events.OrderByDescending(e => e.Name).ToList(),
                "category_asc" => events.OrderBy(e => e.Category).ToList(),
                "category_desc" => events.OrderByDescending(e => e.Category).ToList(),
                _ => events.OrderBy(e => e.Date).ToList(),
            };
        }

        //Get all unique categories
        public HashSet<string> GetUniqueCategories()
        {
            return new HashSet<string>(identifyCategory);
        }

        //Get all unique dates
        public HashSet<DateTime> GetUniqueDates()
        {
            return new HashSet<DateTime>(identifyDate);
        }

        //Get predefined categories
        public List<string> GetAllPredefinedCategories()
        {
            return allCategories;
        }

        //Get total number of events
        public int GetTotalEvents()
        {
            return eventQueue.Count;
        }
    }
}
// GeeksforGeeks (2019). C# Queue with Examples. [online] GeeksforGeeks. Available at: https://www.geeksforgeeks.org/c-sharp/c-sharp-queue-with-examples/. [Accessed 13 October 2025]
// Dictionary Class (System.Collections.Generic) (2024). [online] Microsoft.com. Available at: https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.dictionary-2?view=net-9.0 [Accessed 13 Oct. 2025].
// SortedDictionary Class (System.Collections.Generic) (2025). [online] Microsoft.com. Available at: https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.sorteddictionary-2?view=net-9.0 [Accessed 13 Oct. 2025].
// HashSet Class (System.Collections.Generic) (2025). [online] Microsoft.com. Available at: https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.hashset-1?view=net-9.0 [Accessed 13 Oct. 2025].