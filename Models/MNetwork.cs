using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace ConfigurationManagement.Models
{
    [Table("M_Network")]
    public partial class MNetwork
    {
        [Key]
        public long Seq { get; set; }
        [StringLength(15)]
        public string IpAddress { get; set; }
        [StringLength(15)]
        public string SubnetMask { get; set; }
        [StringLength(15)]
        public string DefaultGetway { get; set; }
        [StringLength(15)]
        public string Dns1 { get; set; }
        [StringLength(15)]
        public string Dns2 { get; set; }
        [StringLength(50)]
        public string Remark { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? UpdateDt { get; set; }
        [StringLength(20)]
        public string UpdateId { get; set; }
        [StringLength(30)]
        public string UpdateTer { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? CreateDt { get; set; }
        [StringLength(20)]
        public string CreateId { get; set; }
        [StringLength(30)]
        public string CreateTer { get; set; }
        public long ConfigurationManagementSeq { get; set; }

        [ForeignKey(nameof(ConfigurationManagementSeq))]
        [InverseProperty(nameof(MConfigurationManagement.MNetworks))]
        public virtual MConfigurationManagement ConfigurationManagementSeqNavigation { get; set; }
    }
}
