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
    [Table("Company_Locations")]
    public class CompanyLocationPoco : IPoco
    {
        [DataMember]
        [Key]
        public Guid Id { get; set; }
        [DataMember]
        public Guid Company { get; set; }
        [DataMember]
        [Column("Country_Code")]
        public string CountryCode { get; set; }
        [DataMember]
        [Column("State_Province_Code")]
        public string Province { get; set; }
        [DataMember]
        [Column("Street_Address")]
        public string Street { get; set; }
        [DataMember]
        [Column("City_Town")]
        public string City { get; set; }
        [DataMember]
        [Column("Zip_Postal_Code")]
        public string PostalCode { get; set; }
        [DataMember]
        [Column("Time_Stamp")]
        public byte[] TimeStamp { get; set; }
        public virtual CompanyProfilePoco CompanyProfile { get; set; }
    }
}
