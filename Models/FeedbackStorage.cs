namespace PROG_3B_ST10255309.Models
{
    public class FeedbackStorage
    {
        // Making use of a list to store the users feedback
        public static List<UserFeedback> Feedbacks { get; } = new List<UserFeedback>();

        // Adding the feedback to the list
        public static void AddFeedback(UserFeedback feedback)
        {
            Feedbacks.Add(feedback);
        }
    }
}
