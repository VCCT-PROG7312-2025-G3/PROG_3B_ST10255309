using System.ComponentModel.DataAnnotations;

namespace PROG_3B_ST10255309.Models
{
    public class UserFeedback
    {
        [Required]
        public string feedbackType { get; set; }
        [Required]
        public string message { get; set; }
    }
}
