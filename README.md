Part 1 Youtube link: https://youtu.be/ze7xmu4nxFs 

Part 2 Youtube link: https://youtu.be/EA1QAQzXjFw 

The following project is developed using ASP.NET Core MVC (C#) with the purpose of creating a Municipal software system whre users can: Report issues, View upcoming events and View their status updates. At the moment the Report Issues, Local Events and Feedback page are the only pages containing information.

- Report Issues: Users can submit a report on a issue in their area. Their report contains: Location, Category, description and a media attachment.

- Local Events: Users can view upcoming events. They are able to search and filter these events.
  
- Feedback Page: Here users can provide feedback to admins by providing a feedback type and a comment. 

**HOW TO OPEN THE PROJECT**

First off you have to clone the git repository (https://github.com/Spookies658/PROG_3B_ST10255309.git). If you have not already installed Visual Studios 2022 do so, otherwise navigate to the project directory and restore the dependancies. Once you have successfully opened the project press f5 or click the Green Arrow  in the taskbar to run the application. It will begin running in your web browser.

**HOW TO NAVIGATE THE APP**
- To navigate from page to page, make use of the sidebar on the left hand side and click on any of the contents in the sidebar to visit that page.
- The home page shows an overview of the services offered.
- 
**Reporting Issues**
- The Report Issue page prompts you to fill in the following: Location; Category; Description; Upload an image. Once all these fields have been filled in and you click submit, a success model will pop up. It will confirm your report and it will ask you if you would like to leave feedback. If Yes is clicked, the program will take you to the feedback page where as pressing no will leave you in the Report Issue page.
- In the Provide Feedback page you will be able to comment on the application and submit. The feedback will be captured for review.
- To exit the application, click the X in the top right corner of the screen.

**Local Events**
- The Local Events page displays all of the current upcoming events, stating each events: Name; Date; Location; Category and a description.
- It also displays some recommended events that could be tailord to your desire.
- To search for specific events, simply select an option from the categories drop down, select a start and end date to provide a date range. Once this has been done you can simply click "Search".
- Events matching your search will appear below. To revert back to all of the events simply click "Clear".
- Whether you are searching for an event or not, you are able to filter all of the events.
- To do so click on the filter drop down to select your filter preference. To revert back simply click "Clear"
- As you continue searching for various events by categories, the Recommended section will change based on your searches and display similar events to your liking.

**Closing the running software**
- To exit the running software, simply click the "X" in the top right hand corner.

  **Data Structures Used**
  - ReportStorage.cs: LinkedList<>
  - EventServices.cs: Dictionary<int, List</Event>>, Dictionary<DateTime, List<Event>>, SortedDictionary<DateTime, List<Event>>, Queue<Event>, HashSet<string>, HashSet<DateTime>
  - RecommendationService.cs: Dictionary<string, int>, Dictionary<string, int>
