using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace CareerCloud.Pocos
{
    [DataContract]
    [Table("Company_Descriptions")]
    public class CompanyDescriptionPoco :IPoco
    {
        [DataMember]
        [Key]
        public Guid Id { get; set; }
        [DataMember]
        public Guid Company { get; set; }
        [DataMember]
        public string LanguageId { get; set; }
        [DataMember]
        [Column("Company_Name")]
        public string CompanyName { get; set; }
        [DataMember]
        [Column("Company_Description")]
        public string CompanyDescription { get; set; }
        [DataMember]
        [Column("Time_Stamp")]
        public byte[] TimeStamp { get; set; }

        public virtual CompanyProfilePoco CompanyProfile { get; set; }
        public virtual SystemLanguageCodePoco SystemLanguageCode { get; set; }
    }
}
