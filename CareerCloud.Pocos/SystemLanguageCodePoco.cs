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
    [Table("System_Language_Codes")]
    public class SystemLanguageCodePoco
    {
        [DataMember]
        [Key]
        public string LanguageID { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        [Column("Native_Name")]
        public string NativeName { get; set; }
        public ICollection<CompanyDescriptionPoco> CompanyDescriptions { get; set; }
    }
}
