using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CareerCloud.MVC.Models
{
    public class CompanyProfileVM
    {
        public Guid Id { get; set; }
        [Display(Name = "Company Name")]
        public string CompanyName { get; set; }
        public string CompanyDescription { get; set; }
        [Display(Name = "Language")]
        public string LanguageId { get; set; }
        [Display(Name = "Website")]
        public string CompanyWebsite { get; set; }
        [Display(Name ="Contact No")]
        public string ContactPhone { get; set; }
        [Display(Name = "Contact Name")]
        public string ContactName { get; set; }

    }
}