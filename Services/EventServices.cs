using System;
using System.Collections.Generic;
using System.Linq;
using PROG_3B_ST10255309.Models;

namespace PROG_3B_ST10255309.Services
{
    public class EventServices
    {
        private static Queue<Events> eventQueue = new Queue<Events>();

        private static Dictionary<int, Events> eventDictionary = new Dictionary<int, Events>();

        private static SortedDictionary<DateTime, List<Events>> eventDate = new SortedDictionary<DateTime, List<Events>>();

        private static Dictionary<string, List<Events>> eventsCategory = new Dictionary<string, List<Events>>();

        private static HashSet <string> identifyCategory = new HashSet<string>();

        private static HashSet<DateTime> identifyDate = new HashSet<DateTime>();

        private static int nextId = 1;

        // Defining of the events
        private static readonly List<string> allEvents = new List<string>()
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
        public void AddEvent(Events newEvent)
        {
            newEvent.Id = nextId++;
            newEvent.Date = DateTime.Now;

            eventQueue.Enqueue(newEvent);

            eventDictionary[newEvent.Id] = newEvent;

            if (!eventDate.ContainsKey(newEvent.Date.Date))
            {
                eventDate[newEvent.Date.Date] = new List<Events>();
            }
            eventDate[newEvent.Date.Date].Add(newEvent);

            if (!eventsCategory.ContainsKey(newEvent.Category))
            {
                eventsCategory[newEvent.Category] = new List<Events>();
            }
            eventsCategory[newEvent.Category].Add(newEvent);

            identifyCategory.Add(newEvent.Category);
            identifyDate.Add(newEvent.Date.Date);
        }

        //Retrieving all events
        public Queue<Events> GetEventQueue()
        {
            return new Queue<Events>(eventQueue);
        }
    }
}
