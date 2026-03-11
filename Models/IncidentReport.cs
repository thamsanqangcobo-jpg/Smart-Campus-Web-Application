using System;
using System.ComponentModel.DataAnnotations;

namespace SmartCampusPortal.Models
{
    public class IncidentReport
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Incident Type is required.")]
        public string IncidentType { get; set; }

        [Required(ErrorMessage = "Description is required.")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Location is required.")]
        public string Location { get; set; }

        public DateTime ReportDate { get; set; } = DateTime.Now; 
        public string Status { get; set; } = "Pending"; 
    }
}

