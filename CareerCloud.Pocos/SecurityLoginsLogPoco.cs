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
    [Table("Security_Logins_Log")]
    public class SecurityLoginsLogPoco : IPoco
    {
        [DataMember]
        [Key]
        public Guid Id { get; set; }
        [DataMember]
        public Guid Login { get; set; }
        [DataMember]
        [Column("Source_IP")]
        public string SourceIP { get; set; }
        [DataMember]
        [Column("Logon_Date")]
        public DateTime LogonDate { get; set; }
        [DataMember]
        [Column("Is_Succesful")]
        public bool IsSuccesful { get; set; }
        public virtual SecurityLoginPoco SecurityLogin { get; set; }
    }
}
