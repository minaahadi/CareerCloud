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
    [Table("Security_Logins")]
    public class SecurityLoginPoco : IPoco
    {
        [DataMember]
        [Key]
        public Guid Id { get; set; }
        [DataMember]
        public string Login { get; set; }
        [DataMember]
        public string Password { get; set; }
        [DataMember]
        [Column("Created_Date")]
        public DateTime Created { get; set; }
        [DataMember]
        [Column("Password_Update_Date")]
        public DateTime? PasswordUpdate { get; set; }
        [DataMember]
        [Column("Agreement_Accepted_Date")]
        public DateTime? AgreementAccepted { get; set; }
        [DataMember]
        [Column("Is_Locked")]
        public bool IsLocked { get; set; }
        [DataMember]
        [Column("Is_Inactive")]
        public bool IsInactive { get; set; }
        [DataMember]
        [Column("Email_Address")]
        public string EmailAddress { get; set; }
        [DataMember]
        [Column("Phone_Number")]
        public string PhoneNumber { get; set; }
        [DataMember]
        [Column("Full_Name")]
        public string FullName { get; set; }
        [DataMember]
        [Column("Force_Change_Password")]
        public bool ForceChangePassword { get; set; }
        [DataMember]
        [Column("Prefferred_Language")]
        public string PrefferredLanguage { get; set; }
        [DataMember]
        [Column("Time_Stamp")]
        public byte[] TimeStamp { get; set; }
        public virtual ICollection<SecurityLoginsRolePoco> SecurityLoginsRole { get; set; }
        public virtual ICollection<SecurityLoginsLogPoco> SecurityLoginsLog { get; set; }
        public virtual ICollection<ApplicantProfilePoco> ApplicantProfile { get; set; }
    }
}
