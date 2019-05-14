using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CareerCloud.MVC.Models
{
    public class AppliedJobVM
    {
        public Guid ApplicantId { get; set; }
        public Guid AppliedId { get; set; }
        [Display(Name ="Job Title")]
        public string JobTitle { get; set; }
        [Display(Name = "Job Description")]
        public string JobDescription { get; set; }
        [Display(Name = "Application Date")]
        public DateTime ApplicationDate { get; set; }
    }
}