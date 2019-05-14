using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace CareerCloud.Pocos
{
    [DataContract]
    [Table("Applicant_Job_Applications")]
    public class ApplicantJobApplicationPoco : IPoco
    {
        [DataMember]
        [Key]
        public Guid Id { get; set; }
        [DataMember]
        [ForeignKey("ApplicantProfile")]
        public Guid Applicant { get; set; }
        [DataMember]
        [ForeignKey("CompanyJob")]
        public Guid Job { get; set; }
        [DataMember]
        [Column("Application_Date")]
        public DateTime ApplicationDate { get; set; }
        [DataMember]
        [Column("Time_Stamp")]
        public byte[] TimeStamp { get; set; }
        public virtual ApplicantProfilePoco ApplicantProfile { get; set; }
        public virtual  CompanyJobPoco CompanyJob { get; set; }
    }
}
