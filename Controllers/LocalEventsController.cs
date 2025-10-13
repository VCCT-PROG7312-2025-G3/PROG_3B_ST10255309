using Microsoft.AspNetCore.Mvc;
using PROG_3B_ST10255309.Models;
using PROG_3B_ST10255309.Services;
using System;
using System.Linq;

namespace PROG_3B_ST10255309.Controllers
{
    public class LocalEventsController : Controller
    {
        private readonly EventServices _eventServices;

        public LocalEventsController()
        {
            _eventServices = new EventServices();

            DummyData();
        }

        //Display all events
        public IActionResult Events(string category, DateTime? startDate, DateTime? endDate)
        {
            // Get all events or search based on filters
            var events = _eventServices.SearchEvents(category, startDate, endDate);

            // Pass categories to view for dropdown
            ViewBag.Categories = _eventServices.GetAllPredefinedCategories();
            ViewBag.SelectedCategory = category;
            ViewBag.StartDate = startDate;
            ViewBag.EndDate = endDate;

            return View(events);
        }


        //Creating events
        private void DummyData()
        {
            if (_eventServices.GetTotalEvents() == 0)
            {
                _eventServices.AddEvent(new Event
                {
                    Name = "Park Clean-Up",
                    Description = "Join us for a day of cleaning up at the Rondebosch Common to keep our parks clean",
                    Date = DateTime.Now.AddDays(7),
                    Location = "Park Rd, Rondebosch",
                    Category = "Community"
                });

                _eventServices.AddEvent(new Event
                {
                    Name = "Rondebosch Market",
                    Description = "Join us at Rondebosch Park for a morning of music, coffee and shopping",
                    Date = DateTime.Now.AddDays(10),
                    Location = "Campground Rd, Rondebosch",
                    Category = "Entertainment"
                });

                _eventServices.AddEvent(new Event
                {
                    Name = "Promenade 5km run",
                    Description = "Join us for a 8am start for a fun 5km run at the Sea Point promenade",
                    Date = DateTime.Now.AddDays(5),
                    Location = "Beach Rd, Sea Point",
                    Category = "Health & Wellness"
                });

                _eventServices.AddEvent(new Event
                {
                    Name = "Art display",
                    Description = "Join us for a day of beautiful art displays at the Baxter theatre",
                    Date = DateTime.Now.AddDays(15),
                    Location = "Main rd, Rondebosch",
                    Category = "Arts & Culture"
                });

                _eventServices.AddEvent(new Event
                {
                    Name = "Cape Town Sixes",
                    Description = "Join us for a day of fun 6-a-side cricket at WPCC",
                    Date = DateTime.Now.AddDays(20),
                    Location = "65 Avenue De Mist, Rondebosch",
                    Category = "Sports"
                });

                _eventServices.AddEvent(new Event
                {
                    Name = "Tech Conference",
                    Description = "Join us for a day of tech talks and networking with industry leaders at the CTICC",
                    Date = DateTime.Now.AddDays(22),
                    Location = "1 Lower Long street, Cape Town",
                    Category = "Technology"
                });

                _eventServices.AddEvent(new Event
                {
                    Name = "Live Music at Kirstenbosch",
                    Description = "Enjoy an evening of live music at the beautiful Kirstenbosch Botanical Gardens",
                    Date = DateTime.Now.AddDays(12),
                    Location = "Rhodes Drive, Newlands",
                    Category = "Music"
                });

                _eventServices.AddEvent(new Event
                {
                    Name = "Business Networking Event",
                    Description = "Connect with local business professionals and entrepreneurs at the CTICC",
                    Date = DateTime.Now.AddDays(18),
                    Location = "1 Lower Long street, Cape Town",
                    Category = "Business"
                });

                _eventServices.AddEvent(new Event
                {
                    Name = "Emeris Open-Day",
                    Description = "Join us for a open day at Emeris",
                    Date = DateTime.Now.AddDays(8),
                    Location = "146 Campground Road, Newlands",
                    Category = "Education"
                });

                _eventServices.AddEvent(new Event
                {
                    Name = "Presidential speech",
                    Description = "Join us at 3pm to hear what Cape Town's minister has to say",
                    Date = DateTime.Now.AddDays(25),
                    Location = "UCT, Rondebosch",
                    Category = "Government"
                });

                _eventServices.AddEvent(new Event
                {
                    Name = "Beach Cleanup",
                    Description = "Join us for a morning of cleaning Blouberg beach",
                    Date = DateTime.Now.AddDays(30),
                    Location = "2 Marine Drive, Table View",
                    Category = "Community"
                });

                _eventServices.AddEvent(new Event
                {
                    Name = "Spanish Food Festival",
                    Description = "Join us for a day of food tasting and cooking demonstrations at the V&A Waterfront",
                    Date = DateTime.Now.AddDays(28),
                    Location = "V&A Waterfront, Cape Town",
                    Category = "Entertainment"
                });

                _eventServices.AddEvent(new Event
                {
                    Name = "Yoga in the Park",
                    Description = "Join us for a morning of yoga and meditation at Green Point Park",
                    Date = DateTime.Now.AddDays(14),
                    Location = "Green Point Park, Cape Town",
                    Category = "Health & Wellness"
                });

                _eventServices.AddEvent(new Event
                {
                    Name = "Coding Bootcamp",
                    Description = "Join us for an intensive coding bootcamp at the CTICC",
                    Date = DateTime.Now.AddDays(30),
                    Location = "1 Lower Long street, Cape Town",
                    Category = "Technology"
                });

                _eventServices.AddEvent(new Event
                {
                    Name = "Jazz Night",
                    Description = "Enjoy an evening of live jazz music at the Cape Town International Jazz Festival",
                    Date = DateTime.Now.AddDays(5),
                    Location = "Cape Town Stadium, Cape Town",
                    Category = "Music"
                });

                _eventServices.AddEvent(new Event
                {
                    Name = "Startup Pitch Event",
                    Description = "Watch local startups pitch their ideas to a panel of investors at the CTICC",
                    Date = DateTime.Now.AddDays(3),
                    Location = "1 Lower Long street, Cape Town",
                    Category = "Business"
                });

                _eventServices.AddEvent(new Event
                {
                    Name = "Cricket Coaching",
                    Description = "Join us at Newlands cricket ground for batting and bowling with the Proteas",
                    Date = DateTime.Now.AddDays(13),
                    Location = "146 Campground Road, Newlands, Rondebosch",
                    Category = "Sports"
                });

                
            }
        }
    }
}