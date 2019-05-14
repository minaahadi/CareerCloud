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
    [Table("Company_Jobs")]
    public class CompanyJobPoco : IPoco
    {
        [DataMember]
        [Key]
        public Guid Id { get; set; }
        [DataMember]
        public Guid Company { get; set; }
        [DataMember]
        [Column("Profile_Created")]
        public DateTime ProfileCreated { get; set; }
        [DataMember]
        [Column("Is_Inactive")]
        public bool IsInactive { get; set; }
        [DataMember]
        [Column("Is_Company_Hidden")]
        public bool IsCompanyHidden { get; set; }
        [DataMember]
        [Column("Time_Stamp")]
        public byte[] TimeStamp { get; set; }
        public virtual CompanyProfilePoco CompanyProfile { get; set; }
        public virtual ICollection<CompanyJobSkillPoco> CompanyJobSkills { get; set; }
        public virtual ICollection<CompanyJobDescriptionPoco> CompanyJobDescriptions { get; set; }
        public virtual  ICollection<CompanyJobEducationPoco> CompanyJobEducations { get; set; }

    }
}
