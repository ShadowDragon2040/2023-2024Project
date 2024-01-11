using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Webárúház_Nagy_Project.Models
{
    public partial class project_databaseContext : DbContext
    {
        public project_databaseContext()
        {
        }

        public project_databaseContext(DbContextOptions<project_databaseContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Felhasznalok> Felhasznalok { get; set; } = null!;
        public virtual DbSet<Hozzaszolasok> Hozzaszolasok { get; set; } = null!;
        public virtual DbSet<Orszagok> Orszagok { get; set; } = null!;
        public virtual DbSet<Szamlazasok> Szamlazasok { get; set; } = null!;
        public virtual DbSet<Szinek> Szinek { get; set; } = null!;
        public virtual DbSet<Szinkapcsolo> Szinkapcsolo { get; set; } = null!;
        public virtual DbSet<Tagek> Tagek { get; set; } = null!;
        public virtual DbSet<Tagkapcsolo> Tagkapcsolo { get; set; } = null!;
        public virtual DbSet<Termekek> Termekek { get; set; } = null!;
        public virtual DbSet<Varosok> Varosok { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseMySQL("SERVER=localhost;PORT=3306;DATABASE=project_database;USER=root;PASSWORD=;SSL MODE=none;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Felhasznalok>(entity =>
            {
                entity.HasKey(e => e.FelhasznaloId)
                .HasName("PRIMARY");

                entity.ToTable("felhasznalok");

                entity.HasIndex(e => new { e.OrszagKodId, e.VarosNevId }, "OrszágKodId");

                entity.HasIndex(e => e.VarosNevId, "VarosNevId");

                entity.Property(e => e.Email).HasMaxLength(128);

                entity.Property(e => e.Hash)
                    .HasMaxLength(128)
                    .HasColumnName("HASH");

                entity.Property(e => e.Hazszam).HasColumnType("int(11)");

                entity.Property(e => e.IranyitoSzam).HasMaxLength(128);

                entity.Property(e => e.Jog).HasColumnType("int(11)");

                entity.Property(e => e.LoginNev).HasMaxLength(128);

                entity.Property(e => e.Nev).HasMaxLength(128);

                entity.Property(e => e.OrszagKodId).HasColumnType("int(11)");

                entity.Property(e => e.ProfilKep).HasMaxLength(128);

                entity.Property(e => e.Salt)
                    .HasMaxLength(128)
                    .HasColumnName("SALT");

                entity.Property(e => e.UtcaNev).HasMaxLength(128);

                entity.Property(e => e.VarosNevId).HasColumnType("int(11)");

                entity.HasOne(d => d.OrszagKod)
                    .WithMany(p => p.Felhasznalok)
                    .HasForeignKey(d => d.OrszagKodId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("felhasznalok_ibfk_1");

                entity.HasOne(d => d.VarosNev)
                    .WithMany(p => p.Felhasznalok)
                    .HasForeignKey(d => d.VarosNevId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("felhasznalok_ibfk_2");
            });

            modelBuilder.Entity<Hozzaszolasok>(entity =>
            {
                entity.HasKey(e => e.HozzaszolasId)
                .HasName("PRIMARY");
                
                entity.ToTable("hozzaszolasok");

                entity.HasIndex(e => new { e.FelhasznaloId, e.TermekId }, "FelhasznaloId");

                entity.HasIndex(e => e.TermekId, "hozzaszolas_ibfk_1");

                entity.Property(e => e.HozzaszolasId).HasColumnType("int(11)");

                entity.Property(e => e.Leiras).HasMaxLength(255);

                entity.HasOne(d => d.Felhasznalok)
                    .WithMany(p => p.Hozzaszolasok)
                    .HasForeignKey(d => d.FelhasznaloId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("hozzaszolasok_ibfk_2");

                entity.HasOne(d => d.Termekek)
                    .WithMany(p => p.Hozzaszolasok)
                    .HasForeignKey(d => d.TermekId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("hozzaszolasok_ibfk_1");
            });

            modelBuilder.Entity<Orszagok>(entity =>
            {
                entity.HasKey(e => e.OrszagId)
                    .HasName("PRIMARY");

                entity.ToTable("orszagok");

                entity.Property(e => e.OrszagId).HasColumnType("int(11)");

                entity.Property(e => e.OrszagKod).HasMaxLength(128);
            });

            modelBuilder.Entity<Szamlazasok>(entity =>
            {
                entity.HasKey(e => e.SzamlazasId)
                .HasName("PRIMARY");

                entity.ToTable("szamlazas");

                entity.HasIndex(e => new { e.FelhasznaloId, e.TermekId }, "FelhasznaloId");

                entity.HasIndex(e => e.TermekId, "szamlazas_ibfk_1");

                entity.Property(e => e.SzamlazasId).HasColumnType("int(11)");

                entity.Property(e => e.VasarlasIdopontja).HasColumnType("date");

                entity.HasOne(d => d.Felhasznalok)
                    .WithMany(p => p.Szamlazasok)
                    .HasForeignKey(d => d.FelhasznaloId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("szamlazas_ibfk_2");

                entity.HasOne(d => d.Termekek)
                    .WithMany(p => p.Szamlazasok)
                    .HasForeignKey(d => d.TermekId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("szamlazas_ibfk_1");
            });

            modelBuilder.Entity<Szinek>(entity =>
            {
                entity.HasKey(e => e.SzinId)
                    .HasName("PRIMARY");

                entity.ToTable("szinek");

                entity.Property(e => e.SzinId).HasColumnType("int(11)");

                entity.Property(e => e.SzinHex).HasMaxLength(128);
            });

            modelBuilder.Entity<Szinkapcsolo>(entity =>
            {
                entity.HasKey(e => e.Id)
                .HasName("PRIMARY");
                
                entity.ToTable("szinkapcsolo");

                entity.HasIndex(e => e.SzinKapcsoloId, "SzinKapcsoloId");

                entity.HasIndex(e => e.TermekSzinKapcsoloId, "TermekSzinKapcsoloId");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.SzinKapcsoloId).HasColumnType("int(11)");

                entity.Property(e => e.TermekSzinKapcsoloId).HasColumnType("int(11)");

                entity.HasOne(d => d.SzinKapcsolo)
                    .WithMany(p => p.Szinkapcsolo)
                    .HasForeignKey(d => d.SzinKapcsoloId)
                    .HasConstraintName("szinkapcsolo_ibfk_1");
            });

            modelBuilder.Entity<Tagek>(entity =>
            {
                entity.HasKey(e => e.TagId)
                    .HasName("PRIMARY");

                entity.ToTable("tagek");

                entity.Property(e => e.TagId).HasColumnType("int(11)");

                entity.Property(e => e.TagNev).HasMaxLength(128);
            });

            modelBuilder.Entity<Tagkapcsolo>(entity =>
            {
                entity.HasKey(e => e.Id)
                .HasName("PRIMARY");

                entity.ToTable("tagkapcsolo");

                entity.HasIndex(e => e.TagKapcsoloId, "TagKapcsoloId");

                entity.HasIndex(e => e.TermekTagKapcsoloId, "TermekTagKapcsoloId");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.TagKapcsoloId).HasColumnType("int(11)");

                entity.Property(e => e.TermekTagKapcsoloId).HasColumnType("int(11)");

                entity.HasOne(d => d.TagKapcsolo)
                    .WithMany(p => p.Tagkapcsolo)
                    .HasForeignKey(d => d.TagKapcsoloId)
                    .HasConstraintName("tagkapcsolo_ibfk_1");
            });

            modelBuilder.Entity<Termekek>(entity =>
            {
                entity.HasKey(e => e.TermekekId)
                .HasName("PRIMARY");

                entity.ToTable("termekek");

                entity.HasIndex(e => e.SzinId, "SzinValasztek");

                entity.HasIndex(e => e.TagId, "TagId");

                entity.Property(e => e.Ar).HasColumnType("int(11)");

                entity.Property(e => e.Keputvonal).HasMaxLength(128);

                entity.Property(e => e.Leiras).HasMaxLength(255);

                entity.Property(e => e.Menyiseg).HasColumnType("int(11)");

                entity.Property(e => e.SzinId).HasColumnType("int(11)");

                entity.Property(e => e.TagId).HasColumnType("int(11)");

                entity.Property(e => e.TermekNev).HasMaxLength(128);
            });

            modelBuilder.Entity<Varosok>(entity =>
            {
                entity.HasKey(e => e.VarosId)
                    .HasName("PRIMARY");

                entity.ToTable("varosok");

                entity.Property(e => e.VarosId).HasColumnType("int(11)");

                entity.Property(e => e.VarosNev).HasMaxLength(128);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
