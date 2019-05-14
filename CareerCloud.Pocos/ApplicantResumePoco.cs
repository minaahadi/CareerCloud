using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace CareerCloud.Pocos
{
    [DataContract]
    [Table("Applicant_Resumes")]
    public class ApplicantResumePoco : IPoco
    {
        [DataMember]
        [Key]
        public Guid Id { get; set; }
        [DataMember]
        [ForeignKey("ApplicantProfile")]
        public Guid Applicant { get; set; }
        [DataMember]
        public string Resume { get; set; }
        [DataMember]
        [Column("Last_Updated")]
        public DateTime? LastUpdated { get; set; }
        public virtual  ApplicantProfilePoco ApplicantProfile { get; set; }

    }
}
