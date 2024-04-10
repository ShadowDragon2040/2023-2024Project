using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ProjectBackend.Models;

public partial class AuthContext : DbContext
{
    public AuthContext()
    {
    }

    public AuthContext(DbContextOptions<AuthContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Aspnetrole> Aspnetrole { get; set; }

    public virtual DbSet<Aspnetuser> Aspnetuser { get; set; }

    public virtual DbSet<Efmigrationshistory> Efmigrationshistorie { get; set; }

    public virtual DbSet<Ftpfile> Ftpfile { get; set; }

    public virtual DbSet<Helyadatok> Helyadatok { get; set; }

    public virtual DbSet<Hozzaszolasok> Hozzaszolasok { get; set; }

    public virtual DbSet<Kategoriak> Kategoriak { get; set; }

    public virtual DbSet<Szamlaza> Szamlaza { get; set; }

    public virtual DbSet<Tagek> Tagek { get; set; }

    public virtual DbSet<Tagkapcsolo> Tagkapcsolo { get; set; }

    public virtual DbSet<Termekek> Termekek { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySQL("SERVER=localhost;PORT=3306;DATABASE=auth;USER=root;PASSWORD=;SSL MODE=none;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Aspnetrole>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("aspnetroles");

            entity.HasIndex(e => e.NormalizedName, "RoleNameIndex").IsUnique();

            entity.Property(e => e.ConcurrencyStamp).HasDefaultValueSql("'NULL'");
            entity.Property(e => e.Name)
                .HasMaxLength(256)
                .HasDefaultValueSql("'NULL'");
            entity.Property(e => e.NormalizedName)
                .HasMaxLength(256)
                .HasDefaultValueSql("'NULL'");
        });

        modelBuilder.Entity<Aspnetuser>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("aspnetusers");

            entity.Property(e => e.AktivalasIdopotja)
                .HasDefaultValueSql("'current_timestamp()'")
                .HasColumnType("datetime");
            entity.Property(e => e.Email)
                .HasMaxLength(256)
                .HasDefaultValueSql("'NULL'");
            entity.Property(e => e.EmailCode).HasColumnType("int(11)");
            entity.Property(e => e.PasswordHash).HasDefaultValueSql("'NULL'");
            entity.Property(e => e.ProfilKep).HasColumnType("mediumblob");
            entity.Property(e => e.UserName)
                .HasMaxLength(256)
                .HasDefaultValueSql("'NULL'");

            entity.HasMany(d => d.Roles).WithMany(p => p.Users)
                .UsingEntity<Dictionary<string, object>>(
                    "Aspnetuserrole",
                    r => r.HasOne<Aspnetrole>().WithMany()
                        .HasForeignKey("RoleId")
                        .HasConstraintName("FK_AspNetUserRoles_AspNetRoles_RoleId"),
                    l => l.HasOne<Aspnetuser>().WithMany()
                        .HasForeignKey("UserId")
                        .HasConstraintName("FK_AspNetUserRoles_AspNetUsers_UserId"),
                    j =>
                    {
                        j.HasKey("UserId", "RoleId").HasName("PRIMARY");
                        j.ToTable("aspnetuserroles");
                        j.HasIndex(new[] { "RoleId" }, "IX_AspNetUserRoles_RoleId");
                    });
        });

        modelBuilder.Entity<Efmigrationshistory>(entity =>
        {
            entity.HasKey(e => e.MigrationId).HasName("PRIMARY");

            entity.ToTable("__efmigrationshistory");

            entity.Property(e => e.MigrationId).HasMaxLength(150);
            entity.Property(e => e.ProductVersion).HasMaxLength(32);
        });

        modelBuilder.Entity<Ftpfile>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("ftpfiles");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.File)
                .HasMaxLength(255)
                .HasColumnName("file");
            entity.Property(e => e.Timestamp)
                .ValueGeneratedOnAddOrUpdate()
                .HasDefaultValueSql("'current_timestamp()'")
                .HasColumnType("datetime")
                .HasColumnName("timestamp");
        });

        modelBuilder.Entity<Helyadatok>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("helyadatok");

            entity.HasIndex(e => e.UserId, "UserId");

            entity.Property(e => e.Id).HasColumnType("int(11)");
            entity.Property(e => e.Egyeb).HasMaxLength(255);
            entity.Property(e => e.Hazszam).HasMaxLength(128);
            entity.Property(e => e.Iranyitoszam).HasMaxLength(128);
            entity.Property(e => e.OrszagNev).HasMaxLength(128);
            entity.Property(e => e.UtcaNev).HasMaxLength(128);
            entity.Property(e => e.VarosNev).HasMaxLength(128);

            entity.HasOne(d => d.User).WithMany(p => p.Helyadatoks)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("helyadatok_ibfk_1");
        });

        modelBuilder.Entity<Hozzaszolasok>(entity =>
        {
            entity.HasKey(e => e.HozzaszolasId).HasName("PRIMARY");

            entity.ToTable("hozzaszolasok");

            entity.HasIndex(e => e.TermekId, "FelhasznaloId");

            entity.HasIndex(e => e.UserId, "UserId");

            entity.HasIndex(e => e.TermekId, "hozzaszolas_ibfk_1");

            entity.Property(e => e.HozzaszolasId).HasColumnType("int(11)");
            entity.Property(e => e.Ertekeles).HasColumnType("int(11)");
            entity.Property(e => e.Leiras).HasMaxLength(255);
            entity.Property(e => e.TermekId).HasColumnType("int(11)");

            entity.HasOne(d => d.Termek).WithMany(p => p.Hozzaszolasoks)
                .HasForeignKey(d => d.TermekId)
                .HasConstraintName("hozzaszolasok_ibfk_1");

            entity.HasOne(d => d.User).WithMany(p => p.Hozzaszolasoks)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("hozzaszolasok_ibfk_2");
        });

        modelBuilder.Entity<Kategoriak>(entity =>
        {
            entity.HasKey(e => e.KategoriaId).HasName("PRIMARY");

            entity.ToTable("kategoriak");

            entity.Property(e => e.KategoriaId).HasColumnType("int(11)");
            entity.Property(e => e.KategoriaNev).HasMaxLength(128);
        });

        modelBuilder.Entity<Szamlaza>(entity =>
        {
            entity.HasKey(e => e.SzamlazasId).HasName("PRIMARY");

            entity.ToTable("szamlazas");

            entity.HasIndex(e => e.TermekId, "FelhasznaloId");

            entity.HasIndex(e => e.UserId, "UserId");

            entity.HasIndex(e => e.TermekId, "szamlazas_ibfk_1");

            entity.Property(e => e.SzamlazasId).HasColumnType("int(11)");
            entity.Property(e => e.Darab)
                .HasColumnType("int(11)")
                .HasColumnName("darab");
            entity.Property(e => e.SzinHex).HasMaxLength(32);
            entity.Property(e => e.TermekId).HasColumnType("int(11)");
            entity.Property(e => e.VasarlasIdopontja).HasColumnType("datetime");

            entity.HasOne(d => d.Termek).WithMany(p => p.Szamlazas)
                .HasForeignKey(d => d.TermekId)
                .HasConstraintName("szamlazas_ibfk_1");

            entity.HasOne(d => d.User).WithMany(p => p.Szamlazas)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("szamlazas_ibfk_2");
        });

        modelBuilder.Entity<Tagek>(entity =>
        {
            entity.HasKey(e => e.TagId).HasName("PRIMARY");

            entity.ToTable("tagek");

            entity.Property(e => e.TagId).HasColumnType("int(11)");
            entity.Property(e => e.TagNev).HasMaxLength(128);
        });

        modelBuilder.Entity<Tagkapcsolo>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("tagkapcsolo");

            entity.HasIndex(e => e.TagekId, "TagKapcsoloId");

            entity.HasIndex(e => e.TermekekId, "TermekekId");

            entity.Property(e => e.Id).HasColumnType("int(11)");
            entity.Property(e => e.TagekId).HasColumnType("int(11)");
            entity.Property(e => e.TermekekId).HasColumnType("int(11)");

            entity.HasOne(d => d.Tagek).WithMany(p => p.Tagkapcsolos)
                .HasForeignKey(d => d.TagekId)
                .HasConstraintName("tagkapcsolo_ibfk_2");

            entity.HasOne(d => d.Termekek).WithMany(p => p.Tagkapcsolos)
                .HasForeignKey(d => d.TermekekId)
                .HasConstraintName("tagkapcsolo_ibfk_3");
        });

        modelBuilder.Entity<Termekek>(entity =>
        {
            entity.HasKey(e => e.TermekId).HasName("PRIMARY");

            entity.ToTable("termekek");

            entity.HasIndex(e => e.KategoriaId, "KategoriaId");

            entity.Property(e => e.TermekId).HasColumnType("int(11)");
            entity.Property(e => e.Ar).HasColumnType("int(11)");
            entity.Property(e => e.KategoriaId).HasColumnType("int(11)");
            entity.Property(e => e.Keputvonal).HasMaxLength(128);
            entity.Property(e => e.Leiras).HasMaxLength(255);
            entity.Property(e => e.Menyiseg).HasColumnType("int(11)");
            entity.Property(e => e.TermekNev).HasMaxLength(128);

            entity.HasOne(d => d.Kategoria).WithMany(p => p.Termekeks)
                .HasForeignKey(d => d.KategoriaId)
                .HasConstraintName("termekek_ibfk_3");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
