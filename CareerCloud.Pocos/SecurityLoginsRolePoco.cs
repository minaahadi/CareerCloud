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
    [Table("Security_Logins_Roles")]
    public class SecurityLoginsRolePoco : IPoco
    {
        [DataMember]
        [Key]
        public Guid Id { get; set; }
        [DataMember]
        public Guid Login { get; set; }
        [DataMember]
        public Guid Role { get; set; }
        [DataMember]
        [Column("Time_Stamp")]
        public byte[] TimeStamp { get; set; }
        public virtual SecurityLoginPoco  SecurityLogin{get;set;}
        public virtual  SecurityRolePoco SecurityRole { get; set; }
    }
}
