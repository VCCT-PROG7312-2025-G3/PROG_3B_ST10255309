namespace PROG_3B_ST10255309.Models
{
    public class FeedbackStorage
    {
        public static List<UserFeedback> Feedbacks { get; } = new List<UserFeedback>();

        public static void AddFeedback(UserFeedback feedback)
        {
            Feedbacks.Add(feedback);
        }
    }
}
