using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace PROG_3B_ST10255309.Models
{
    public class Report
    {
        public int Id { get; set; }

        [Required]
        public string Location { get; set; }

        [Required]
        public string Category { get; set; }

        [Required]
        public string Description { get; set; }

        public IFormFile MediaAttachment { get; set; }

        public DateTime DateSubmitted { get; set; }

        public string Status { get; set; } = "Submitted";
    }
}
