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
    [Table("Company_Job_Educations")]
    public class CompanyJobEducationPoco : IPoco
    {
        [DataMember]
        [Key]
        public Guid Id { get; set; }
        [DataMember]
        public Guid Job { get; set; }
        [DataMember]
        public string Major { get; set; }
        [DataMember]
        public Int16 Importance { get; set; }
        [DataMember]
        [Column("Time_Stamp")]
        public byte[] TimeStamp { get; set; }
        public virtual CompanyJobPoco CompanyJob { get; set; }
    }
}
