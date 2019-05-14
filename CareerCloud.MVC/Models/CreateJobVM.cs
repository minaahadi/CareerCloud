using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CareerCloud.MVC.Models
{
    public class CreateJobVM
    {
        [Key]
        public Guid CompanyId { get; set; }
        public Guid JobId { get; set; }
        public string JobName { get; set; }
        public string JobDescriptions { get; set; }
        public DateTime ProfileCreated { get; set; }
        public bool IsInactive { get; set; }
        public bool IsCompanyHidden { get; set; }
    }
}