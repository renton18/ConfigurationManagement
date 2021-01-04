using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace ConfigurationManagement.Models
{
    [Table("M_ConfigurationManagement")]
    public partial class MConfigurationManagement
    {
        public MConfigurationManagement()
        {
            MAccounts = new HashSet<MAccount>();
            MNetworks = new HashSet<MNetwork>();
        }

        [Key]
        public long ConfigurationManagementSeq { get; set; }
        [Column("Jissibi_S", TypeName = "date")]
        public DateTime? JissibiS { get; set; }
        [Column("Jissibi_E", TypeName = "date")]
        public DateTime? JissibiE { get; set; }
        [StringLength(100)]
        public string Host { get; set; }
        [StringLength(100)]
        public string HostDetail { get; set; }
        [StringLength(30)]
        public string UserName { get; set; }
        [StringLength(100)]
        public string Place { get; set; }
        public int? HostType { get; set; }
        [StringLength(30)]
        public string Os { get; set; }
        [StringLength(30)]
        public string Cpu { get; set; }
        [StringLength(30)]
        public string Memory { get; set; }
        [StringLength(100)]
        public string Share1 { get; set; }
        [StringLength(100)]
        public string Share2 { get; set; }
        [StringLength(100)]
        public string Share3 { get; set; }
        [StringLength(100)]
        public string Share4 { get; set; }
        [Column("WebURL")]
        [StringLength(100)]
        public string WebUrl { get; set; }
        [StringLength(100)]
        public string ParentHost { get; set; }
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

        [InverseProperty(nameof(MAccount.ConfigurationManagementSeqNavigation))]
        public virtual ICollection<MAccount> MAccounts { get; set; }
        [InverseProperty(nameof(MNetwork.ConfigurationManagementSeqNavigation))]
        public virtual ICollection<MNetwork> MNetworks { get; set; }
    }
}
