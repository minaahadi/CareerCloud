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
    [Table("Company_Jobs_Descriptions")]
    public class CompanyJobDescriptionPoco : IPoco
    {
        [DataMember]
        [Key]
        public Guid Id { get; set; }
        [DataMember]
        public Guid Job { get; set; }
        [DataMember]
        [Column("Job_Name")]
        public string JobName { get; set; }
        [DataMember]
        [Column("Job_Descriptions")]
        public string JobDescriptions { get; set; }
        [DataMember]
        [Column("Time_Stamp")]
        public byte[] TimeStamp { get; set; }
        public virtual CompanyJobPoco CompanyJob { get; set; } 
    }
}
