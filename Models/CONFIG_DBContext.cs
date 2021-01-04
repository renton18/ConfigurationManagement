using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace ConfigurationManagement.Models
{
    public partial class CONFIG_DBContext : DbContext
    {
        public CONFIG_DBContext()
        {
        }

        public CONFIG_DBContext(DbContextOptions<CONFIG_DBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<MAccount> MAccounts { get; set; }
        public virtual DbSet<MConfigurationManagement> MConfigurationManagements { get; set; }
        public virtual DbSet<MNetwork> MNetworks { get; set; }
        public virtual DbSet<VConfigAccount> VConfigAccounts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=H\\SQLEXPRESS;Database=CONFIG_DB;Trusted_Connection=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Japanese_CI_AS");

            modelBuilder.Entity<MAccount>(entity =>
            {
                entity.HasComment("アカウント");

                entity.Property(e => e.AccountSeq).HasComment("SEQ");

                entity.Property(e => e.AccountType)
                    .HasDefaultValueSql("((0))")
                    .HasComment("アカウント種類");

                entity.Property(e => e.ConfigurationManagementSeq).HasComment("構成管理Seq");

                entity.Property(e => e.CreateDt).HasComment("作成日");

                entity.Property(e => e.CreateId)
                    .IsUnicode(false)
                    .HasComment("作成ID");

                entity.Property(e => e.CreateTer)
                    .IsUnicode(false)
                    .HasComment("作成端末");

                entity.Property(e => e.DatabaseName)
                    .IsUnicode(false)
                    .HasComment("DB名");

                entity.Property(e => e.Id)
                    .IsUnicode(false)
                    .HasComment("ID");

                entity.Property(e => e.Pass)
                    .IsUnicode(false)
                    .HasComment("パスワード");

                entity.Property(e => e.UpdateDt).HasComment("更新日");

                entity.Property(e => e.UpdateId)
                    .IsUnicode(false)
                    .HasComment("更新ID");

                entity.Property(e => e.UpdateTer)
                    .IsUnicode(false)
                    .HasComment("更新端末");

                entity.HasOne(d => d.ConfigurationManagementSeqNavigation)
                    .WithMany(p => p.MAccounts)
                    .HasForeignKey(d => d.ConfigurationManagementSeq)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MConfigurationManagement_MAccountb");
            });

            modelBuilder.Entity<MConfigurationManagement>(entity =>
            {
                entity.HasComment("構成管理メイン");

                entity.Property(e => e.ConfigurationManagementSeq).HasComment("SEQ");

                entity.Property(e => e.Cpu)
                    .IsUnicode(false)
                    .HasComment("CPU");

                entity.Property(e => e.CreateDt).HasComment("作成日");

                entity.Property(e => e.CreateId)
                    .IsUnicode(false)
                    .HasComment("作成ID");

                entity.Property(e => e.CreateTer)
                    .IsUnicode(false)
                    .HasComment("作成端末");

                entity.Property(e => e.Host)
                    .IsUnicode(false)
                    .HasComment("ホスト名");

                entity.Property(e => e.HostDetail)
                    .IsUnicode(false)
                    .HasComment("ホスト情報");

                entity.Property(e => e.HostType).HasComment("アカウント種類");

                entity.Property(e => e.JissibiE).HasComment("終了日");

                entity.Property(e => e.JissibiS).HasComment("開始日");

                entity.Property(e => e.Memory)
                    .IsUnicode(false)
                    .HasComment("メモリ");

                entity.Property(e => e.Os)
                    .IsUnicode(false)
                    .HasComment("OS");

                entity.Property(e => e.ParentHost)
                    .IsUnicode(false)
                    .HasComment("親ホスト");

                entity.Property(e => e.Place)
                    .IsUnicode(false)
                    .HasComment("設置場所");

                entity.Property(e => e.Share1)
                    .IsUnicode(false)
                    .HasComment("共有フォルダ1");

                entity.Property(e => e.Share2)
                    .IsUnicode(false)
                    .HasComment("共有フォルダ2");

                entity.Property(e => e.Share3)
                    .IsUnicode(false)
                    .HasComment("共有フォルダ3");

                entity.Property(e => e.Share4)
                    .IsUnicode(false)
                    .HasComment("共有フォルダ4");

                entity.Property(e => e.UpdateDt).HasComment("更新日");

                entity.Property(e => e.UpdateId)
                    .IsUnicode(false)
                    .HasComment("更新ID");

                entity.Property(e => e.UpdateTer)
                    .IsUnicode(false)
                    .HasComment("更新端末");

                entity.Property(e => e.UserName)
                    .IsUnicode(false)
                    .HasComment("使用者");

                entity.Property(e => e.WebUrl)
                    .IsUnicode(false)
                    .HasComment("WebURL");
            });

            modelBuilder.Entity<MNetwork>(entity =>
            {
                entity.HasComment("ネットワーク設定");

                entity.Property(e => e.Seq).HasComment("SEQ");

                entity.Property(e => e.ConfigurationManagementSeq).HasComment("構成管理Seq");

                entity.Property(e => e.CreateDt).HasComment("作成日");

                entity.Property(e => e.CreateId)
                    .IsUnicode(false)
                    .HasComment("作成ID");

                entity.Property(e => e.CreateTer)
                    .IsUnicode(false)
                    .HasComment("作成端末");

                entity.Property(e => e.DefaultGetway)
                    .IsUnicode(false)
                    .HasComment("デフォルトゲートウェイ");

                entity.Property(e => e.Dns1)
                    .IsUnicode(false)
                    .HasComment("DNS1");

                entity.Property(e => e.Dns2)
                    .IsUnicode(false)
                    .HasComment("DNS2");

                entity.Property(e => e.IpAddress)
                    .IsUnicode(false)
                    .HasComment("IPアドレス");

                entity.Property(e => e.Remark)
                    .IsUnicode(false)
                    .HasComment("備考");

                entity.Property(e => e.SubnetMask)
                    .IsUnicode(false)
                    .HasComment("サブネットマスク");

                entity.Property(e => e.UpdateDt).HasComment("更新日");

                entity.Property(e => e.UpdateId)
                    .IsUnicode(false)
                    .HasComment("更新ID");

                entity.Property(e => e.UpdateTer)
                    .IsUnicode(false)
                    .HasComment("更新端末");

                entity.HasOne(d => d.ConfigurationManagementSeqNavigation)
                    .WithMany(p => p.MNetworks)
                    .HasForeignKey(d => d.ConfigurationManagementSeq)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MConfigurationManagement_MNetwork");
            });

            modelBuilder.Entity<VConfigAccount>(entity =>
            {
                entity.ToView("V_ConfigAccount");

                entity.Property(e => e.AccountId).IsUnicode(false);

                entity.Property(e => e.Cpu).IsUnicode(false);

                entity.Property(e => e.CreateId).IsUnicode(false);

                entity.Property(e => e.CreateTer).IsUnicode(false);

                entity.Property(e => e.DatabaseName).IsUnicode(false);

                entity.Property(e => e.Host).IsUnicode(false);

                entity.Property(e => e.HostDetail).IsUnicode(false);

                entity.Property(e => e.Memory).IsUnicode(false);

                entity.Property(e => e.Os).IsUnicode(false);

                entity.Property(e => e.ParentHost).IsUnicode(false);

                entity.Property(e => e.Pass).IsUnicode(false);

                entity.Property(e => e.Place).IsUnicode(false);

                entity.Property(e => e.Share1).IsUnicode(false);

                entity.Property(e => e.Share2).IsUnicode(false);

                entity.Property(e => e.Share3).IsUnicode(false);

                entity.Property(e => e.Share4).IsUnicode(false);

                entity.Property(e => e.UpdateId).IsUnicode(false);

                entity.Property(e => e.UpdateTer).IsUnicode(false);

                entity.Property(e => e.UserName).IsUnicode(false);

                entity.Property(e => e.WebUrl).IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
