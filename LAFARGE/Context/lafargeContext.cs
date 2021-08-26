using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using LAFARGE.Models;

#nullable disable

namespace LAFARGE.Context
{
    public partial class lafargeContext : DbContext
    {
        public lafargeContext()
        {
        }

        public lafargeContext(DbContextOptions<lafargeContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Chauffeur> Chauffeurs { get; set; }
        public virtual DbSet<Client> Clients { get; set; }
        public virtual DbSet<Commande> Commandes { get; set; }
        public virtual DbSet<HistoriqueCheck> HistoriqueChecks { get; set; }
        public virtual DbSet<Operateur> Operateurs { get; set; }
        public virtual DbSet<Quality> Qualities { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=.\\sqlexpress;Initial Catalog=lafarge;Integrated security=true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Chauffeur>(entity =>
            {
                entity.HasKey(e => e.CinChauffeur)
                    .HasName("PK__Chauffeu__59D130B594567158");

                entity.ToTable("Chauffeur");

                entity.Property(e => e.CinChauffeur)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("cinChauffeur");

                entity.Property(e => e.AdresseChauffeur)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasColumnName("adresseChauffeur");

                entity.Property(e => e.FullnameChauffeur)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasColumnName("fullnameChauffeur");

                entity.Property(e => e.NumeroChauffeur)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasColumnName("numeroChauffeur");
            });

            modelBuilder.Entity<Client>(entity =>
            {
                entity.HasKey(e => e.CodeClient)
                    .HasName("PK__Client__428FAD02AD260F3F");

                entity.ToTable("Client");

                entity.Property(e => e.CodeClient).HasColumnName("codeClient");

                entity.Property(e => e.AdresseClient)
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("adresseClient");

                entity.Property(e => e.NomClient)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("nomClient");

                entity.Property(e => e.NumeroClient)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("numeroClient");

                entity.Property(e => e.SituationFinanciere)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("situationFinanciere");

                entity.Property(e => e.SoldeClient).HasColumnName("soldeClient");
            });

            modelBuilder.Entity<Commande>(entity =>
            {
                entity.HasKey(e => e.BonCommande)
                    .HasName("PK__Commande__519B53B2E702D332");

                entity.ToTable("Commande");

                entity.Property(e => e.BonCommande).HasColumnName("bonCommande");

                entity.Property(e => e.CinChauffeur)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("cinChauffeur");

                entity.Property(e => e.CinOperateur)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("cinOperateur");

                entity.Property(e => e.CodeClient).HasColumnName("codeClient");

                entity.Property(e => e.HeureChargement)
                    .HasColumnType("datetime")
                    .HasColumnName("heureChargement");

                entity.Property(e => e.HeureLivraison)
                    .HasColumnType("datetime")
                    .HasColumnName("heureLivraison");

                entity.Property(e => e.IdQuality).HasColumnName("idQuality");

                entity.Property(e => e.Matricule)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Unite)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Verification).HasColumnName("verification");

                entity.HasOne(d => d.CinChauffeurNavigation)
                    .WithMany(p => p.Commandes)
                    .HasForeignKey(d => d.CinChauffeur)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Commande__cinCha__6383C8BA");

                entity.HasOne(d => d.CinOperateurNavigation)
                    .WithMany(p => p.Commandes)
                    .HasForeignKey(d => d.CinOperateur)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Commande__cinOpe__60A75C0F");

                entity.HasOne(d => d.CodeClientNavigation)
                    .WithMany(p => p.Commandes)
                    .HasForeignKey(d => d.CodeClient)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Commande__codeCl__619B8048");

                entity.HasOne(d => d.IdQualityNavigation)
                    .WithMany(p => p.Commandes)
                    .HasForeignKey(d => d.IdQuality)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Commande__idQual__628FA481");
            });

            modelBuilder.Entity<HistoriqueCheck>(entity =>
            {
                entity.HasKey(e => new { e.CodeClient, e.CheckClient })
                    .HasName("pk_historique");

                entity.ToTable("historiqueCheck");

                entity.Property(e => e.CodeClient).HasColumnName("codeClient");

                entity.Property(e => e.CheckClient)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("checkClient");

                entity.HasOne(d => d.CodeClientNavigation)
                    .WithMany(p => p.HistoriqueChecks)
                    .HasForeignKey(d => d.CodeClient)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__historiqu__codeC__3B75D760");
            });

            modelBuilder.Entity<Operateur>(entity =>
            {
                entity.HasKey(e => e.CinOperateur)
                    .HasName("PK__Operateu__3D89605FDABF6491");

                entity.ToTable("Operateur");

                entity.Property(e => e.CinOperateur)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("cinOperateur");

                entity.Property(e => e.AdresseOperateur)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasColumnName("adresseOperateur");

                entity.Property(e => e.FullnameOperateur)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasColumnName("fullnameOperateur");

                entity.Property(e => e.NumeroOperateur)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasColumnName("numeroOperateur");

                entity.Property(e => e.PasswordOperateur)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("passwordOperateur");
            });

            modelBuilder.Entity<Quality>(entity =>
            {
                entity.HasKey(e => e.IdQuality)
                    .HasName("PK__quality__6935EF4C18868DF4");

                entity.ToTable("quality");

                entity.Property(e => e.IdQuality).HasColumnName("idQuality");

                entity.Property(e => e.NameQuality)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nameQuality");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
