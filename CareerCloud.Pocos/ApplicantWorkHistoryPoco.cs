using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace CareerCloud.Pocos
{
    [DataContract]
    [Table("Applicant_Work_History")]
    public class ApplicantWorkHistoryPoco : IPoco
    {
        [DataMember]
        [Key]
        public Guid Id { get; set; }
        [DataMember]
        [ForeignKey("ApplicantProfile")]
        public Guid Applicant { get; set; }
        [DataMember]
        [Column("Company_Name")]
        public string CompanyName { get; set; }
        [DataMember]
        [ForeignKey("SystemCountryCode")]
        [Column("Country_Code")]
        public string CountryCode { get; set; }
        [DataMember]
        public string Location { get; set; }
        [DataMember]
        [Column("Job_Title")]
        public string JobTitle { get; set; }
        [DataMember]
        [Column("Job_Description")]
        public string JobDescription { get; set; }
        [DataMember]
        [Column("Start_Month")]
        public Int16 StartMonth { get; set; }
        [DataMember]
        [Column("Start_Year")]
        public int StartYear { get; set; }
        [DataMember]
        [Column("End_Month")]
        public Int16 EndMonth { get; set; }
        [DataMember]
        [Column("End_Year")]
        public int EndYear { get; set; }
        [DataMember]
        [Column("Time_Stamp")]
        public byte[] TimeStamp { get; set; }
        public virtual SystemCountryCodePoco SystemCountryCode { get; set; }
        public virtual ApplicantProfilePoco ApplicantProfile { get; set; }

    }
}
