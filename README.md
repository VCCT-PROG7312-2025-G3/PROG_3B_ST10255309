Part 1 Youtube link: https://youtu.be/ze7xmu4nxFs 

Part 2 Youtube link: https://youtu.be/EA1QAQzXjFw 

Part 3 YOutube link: 

**Municipal Services Application**

The following project is developed using ASP.NET Core MVC (C#) with the purpose of creating a Municipal software system whre users can: Report issues, View upcoming events and View their status updates. At the moment the Report Issues, Local Events and Feedback page are the only pages containing information.

- Report Issues: Users can submit a report on a issue in their area. Their report contains: Location, Category, description and a media attachment.

- Local Events: Users can view upcoming events. They are able to search and filter these events.

- Service Request Status: Users can view their submitted reports along with their status of completion.
  
- Feedback Page: Here users can provide feedback to admins by providing a feedback type and a comment. 

**HOW TO OPEN THE PROJECT**

First off you have to clone the git repository (https://github.com/Spookies658/PROG_3B_ST10255309.git). If you have not already installed Visual Studios 2022 do so, otherwise navigate to the project directory and restore the dependancies. Once you have successfully opened the project press f5 or click the Green Arrow  in the taskbar to run the application. It will begin running in your web browser.

**HOW TO NAVIGATE THE APP**
- To navigate from page to page, make use of the sidebar on the left hand side and click on any of the contents in the sidebar to visit that page.
- Once the application has been opened, it displays the home page that shows an overview of the services offered.
- The sidebar is split into 3 parts:
  - Home: This is where the home page is located.
  - Municipal Services: This heading contains the following pages: Report Issue; Local Events; Service Request Status.
  - Support: THis heading contains the following page: Provide your feedback.

**Reporting Issues**
- The Report Issue page prompts you to fill in the following: Location; Category; Description; Upload an image. Once all these fields have been filled in and you click submit, a success model will pop up. It will confirm your report and it will ask you if you would like to leave feedback. If Yes is clicked, the program will take you to the feedback page where as pressing no will leave you in the Report Issue page.
- In the Provide Feedback page you will be able to comment on the application and submit. The feedback will be captured for review.

**Local Events**
- The Local Events page displays all of the current upcoming events, stating each events: Name; Date; Location; Category and a description.
- It also displays some recommended events that could be tailord to your desire.
- To search for specific events, simply select an option from the categories drop down, select a start and end date to provide a date range. Once this has been done you can simply click "Search".
- Events matching your search will appear below. To revert back to all of the events simply click "Clear".
- Whether you are searching for an event or not, you are able to filter all of the events.
- To do so click on the filter drop down to select your filter preference. To revert back simply click "Clear"
- As you continue searching for various events by categories, the Recommended section will change based on your searches and display similar events to your liking.

**Service Request Status**
- The Service Request Sratus page displays all of the users requests made in the Report Issue page.
- It displays the total amount of requests that are either: Submitted; In Progress; Completed.
- Users will be able to filter the displayed requests by their status, in the form of: All Statuses; Submitted; In Progress; Completed.
- Below all this, will be all of the users requests. Each request displays the reports: Number; Location; Category; Description; Status. Below this information, a progress bar will display the status of their requests completion.
- As the Municipality begins to resolve the user's request, the progress bar will be updated according to reflect the status of the request.

**Managing Service Request Status**
- To update the status of a users request, admins can follow the following link to acces the Manage Request Status page while the application is running: https://localhost:7131/Status/ManageStatuses
- Once the page has opened the total number of: Submitted; In Progress; Completed; Total Request, will be displayed.
- Below this, all of the requests will be displayed with their: Number; Location; Category; Description; Status.
- Within the card of each Service request, admins will be able to update the status of the request.
- However, their is a progression flow that has to be followed. Request statuses are updated in the following order: Submitted -> In Progress -> Completed.
- If a status is updated to Completed straight from Submitted, it will not render.
- Once the following status has been selected, admins can click the "Update Status" button which will update the request's status and return to the Service Request Status page.

**Closing the running software**
- To exit the running software, simply click the "X" in the top right hand corner.
