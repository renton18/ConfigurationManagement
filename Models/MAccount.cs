using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace ConfigurationManagement.Models
{
    [Table("M_Account")]
    public partial class MAccount
    {
        [Key]
        public long AccountSeq { get; set; }
        public int? AccountType { get; set; }
        [StringLength(30)]
        public string Id { get; set; }
        [StringLength(30)]
        public string Pass { get; set; }
        [StringLength(30)]
        public string DatabaseName { get; set; }
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
        [InverseProperty(nameof(MConfigurationManagement.MAccounts))]
        public virtual MConfigurationManagement ConfigurationManagementSeqNavigation { get; set; }
    }
}
