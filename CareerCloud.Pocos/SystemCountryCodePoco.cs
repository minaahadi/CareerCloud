using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace CareerCloud.Pocos
{
    [DataContract]
    [Table("System_Country_Codes")]
    public class SystemCountryCodePoco
    {
        [DataMember]
        [Key]
        public string Code { get; set; }
        [DataMember]
        [Display(Name="Country")]
        public string Name { get; set; }
       
        public virtual ICollection<ApplicantProfilePoco>ApplicantProfile { get; set; }
        public virtual ICollection<ApplicantWorkHistoryPoco>ApplicantWorkHistory { get; set; }

    }
}
