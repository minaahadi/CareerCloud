using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace CareerCloud.Pocos
{
    [DataContract]
    [Table("Applicant_Skills")]
    public class ApplicantSkillPoco : IPoco 
    {
        [DataMember]
        [Key]
        public Guid Id { get; set; }
        [DataMember]
        [ForeignKey("ApplicantProfile")]
        public Guid Applicant { get; set; }
        [DataMember]
        public string Skill { get; set; }
        [DataMember]
        [Column("Skill_Level")]
        public string SkillLevel { get; set; }
        [DataMember]
        [Column("Start_Month")]
        public byte StartMonth { get; set; }
        [DataMember]
        [Column("Start_Year")]
        public int StartYear { get; set; }
        [DataMember]
        [Column("End_Month")]
        public byte EndMonth { get; set; }
        [DataMember]
        [Column("End_Year")]
        public int EndYear { get; set; }
        [DataMember]
        [Column("Time_Stamp")]
        public byte[] TimeStamp { get; set; }
        public virtual ApplicantProfilePoco ApplicantProfile {get; set;}
    }
}
