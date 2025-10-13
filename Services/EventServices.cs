using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Logging;
using PROG_3B_ST10255309.Models;

namespace PROG_3B_ST10255309.Services
{
    public class EventServices
    {
        private static Queue<Event> eventQueue = new Queue<Event>();

        private static Dictionary<int, Event> eventDictionary = new Dictionary<int, Event>();

        private static SortedDictionary<DateTime, List<Event>> eventDate = new SortedDictionary<DateTime, List<Event>>();

        private static Dictionary<string, List<Event>> eventsCategory = new Dictionary<string, List<Event>>();

        private static HashSet <string> identifyCategory = new HashSet<string>();

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

            eventQueue.Enqueue(newEvent);

            eventDictionary[newEvent.Id] = newEvent;

            if (!eventDate.ContainsKey(newEvent.Date.Date))
            {
                eventDate[newEvent.Date.Date] = new List<Event>();
            }
            eventDate[newEvent.Date.Date].Add(newEvent);

            if (!eventsCategory.ContainsKey(newEvent.Category))
            {
                eventsCategory[newEvent.Category] = new List<Event>();
            }
            eventsCategory[newEvent.Category].Add(newEvent);

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

            if (!string.IsNullOrEmpty(category) && category != "All")
            {
                events = events.Where(e => e.Category == category).ToList();
            }

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
