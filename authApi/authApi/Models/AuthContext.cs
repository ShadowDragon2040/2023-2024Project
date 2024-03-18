using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace authApi.Models;

public partial class AuthContext : DbContext
{
    public AuthContext()
    {
    }

    public AuthContext(DbContextOptions<AuthContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Aspnetrole> Aspnetroles { get; set; }

    public virtual DbSet<Aspnetroleclaim> Aspnetroleclaims { get; set; }

    public virtual DbSet<Aspnetuser> Aspnetusers { get; set; }

    public virtual DbSet<Aspnetuserclaim> Aspnetuserclaims { get; set; }

    public virtual DbSet<Aspnetuserlogin> Aspnetuserlogins { get; set; }

    public virtual DbSet<Aspnetusertoken> Aspnetusertokens { get; set; }

    public virtual DbSet<Efmigrationshistory> Efmigrationshistories { get; set; }

    public virtual DbSet<Helyadatok> Helyadatoks { get; set; }

    public virtual DbSet<Hozzaszolasok> Hozzaszolasoks { get; set; }

    public virtual DbSet<Kategoriak> Kategoriaks { get; set; }

    public virtual DbSet<Szamlaza> Szamlazas { get; set; }

    public virtual DbSet<Tagek> Tageks { get; set; }

    public virtual DbSet<Tagkapcsolo> Tagkapcsolos { get; set; }

    public virtual DbSet<Termekek> Termekeks { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
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

        modelBuilder.Entity<Aspnetroleclaim>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("aspnetroleclaims");

            entity.HasIndex(e => e.RoleId, "IX_AspNetRoleClaims_RoleId");

            entity.Property(e => e.Id).HasColumnType("int(11)");
            entity.Property(e => e.ClaimType).HasDefaultValueSql("'NULL'");
            entity.Property(e => e.ClaimValue).HasDefaultValueSql("'NULL'");

            entity.HasOne(d => d.Role).WithMany(p => p.Aspnetroleclaims)
                .HasForeignKey(d => d.RoleId)
                .HasConstraintName("FK_AspNetRoleClaims_AspNetRoles_RoleId");
        });

        modelBuilder.Entity<Aspnetuser>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("aspnetusers");

            entity.HasIndex(e => e.NormalizedEmail, "EmailIndex");

            entity.HasIndex(e => e.NormalizedUserName, "UserNameIndex").IsUnique();

            entity.Property(e => e.AccessFailedCount).HasColumnType("int(11)");
            entity.Property(e => e.AktivalasIdopotja)
                .HasDefaultValueSql("'current_timestamp()'")
                .HasColumnType("datetime");
            entity.Property(e => e.ConcurrencyStamp).HasDefaultValueSql("'NULL'");
            entity.Property(e => e.Email)
                .HasMaxLength(256)
                .HasDefaultValueSql("'NULL'");
            entity.Property(e => e.EmailCode).HasColumnType("int(11)");
            entity.Property(e => e.LockoutEnd)
                .HasMaxLength(6)
                .HasDefaultValueSql("'NULL'");
            entity.Property(e => e.NormalizedEmail)
                .HasMaxLength(256)
                .HasDefaultValueSql("'NULL'");
            entity.Property(e => e.NormalizedUserName)
                .HasMaxLength(256)
                .HasDefaultValueSql("'NULL'");
            entity.Property(e => e.PasswordHash).HasDefaultValueSql("'NULL'");
            entity.Property(e => e.PhoneNumber).HasDefaultValueSql("'NULL'");
            entity.Property(e => e.ProfilKep).HasColumnType("mediumblob");
            entity.Property(e => e.SecurityStamp).HasDefaultValueSql("'NULL'");
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

        modelBuilder.Entity<Aspnetuserclaim>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("aspnetuserclaims");

            entity.HasIndex(e => e.UserId, "IX_AspNetUserClaims_UserId");

            entity.Property(e => e.Id).HasColumnType("int(11)");
            entity.Property(e => e.ClaimType).HasDefaultValueSql("'NULL'");
            entity.Property(e => e.ClaimValue).HasDefaultValueSql("'NULL'");

            entity.HasOne(d => d.User).WithMany(p => p.Aspnetuserclaims)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK_AspNetUserClaims_AspNetUsers_UserId");
        });

        modelBuilder.Entity<Aspnetuserlogin>(entity =>
        {
            entity.HasKey(e => new { e.LoginProvider, e.ProviderKey }).HasName("PRIMARY");

            entity.ToTable("aspnetuserlogins");

            entity.HasIndex(e => e.UserId, "IX_AspNetUserLogins_UserId");

            entity.Property(e => e.ProviderDisplayName).HasDefaultValueSql("'NULL'");

            entity.HasOne(d => d.User).WithMany(p => p.Aspnetuserlogins)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK_AspNetUserLogins_AspNetUsers_UserId");
        });

        modelBuilder.Entity<Aspnetusertoken>(entity =>
        {
            entity.HasKey(e => new { e.UserId, e.LoginProvider, e.Name }).HasName("PRIMARY");

            entity.ToTable("aspnetusertokens");

            entity.Property(e => e.Value).HasDefaultValueSql("'NULL'");

            entity.HasOne(d => d.User).WithMany(p => p.Aspnetusertokens)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK_AspNetUserTokens_AspNetUsers_UserId");
        });

        modelBuilder.Entity<Efmigrationshistory>(entity =>
        {
            entity.HasKey(e => e.MigrationId).HasName("PRIMARY");

            entity.ToTable("__efmigrationshistory");

            entity.Property(e => e.MigrationId).HasMaxLength(150);
            entity.Property(e => e.ProductVersion).HasMaxLength(32);
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
                .OnDelete(DeleteBehavior.Restrict)
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
            entity.Property(e => e.SzinHex).HasColumnType("int(11)");
            entity.Property(e => e.TermekId).HasColumnType("int(11)");
            entity.Property(e => e.VasarlasIdopontja).HasColumnType("date");

            entity.HasOne(d => d.Termek).WithMany(p => p.Szamlazas)
                .HasForeignKey(d => d.TermekId)
                .OnDelete(DeleteBehavior.Restrict)
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

            entity.HasIndex(e => e.TagKapcsoloId, "TagKapcsoloId");

            entity.HasIndex(e => e.TermekTagKapcsoloId, "TermekTagKapcsoloId");

            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnType("int(11)");
            entity.Property(e => e.TagKapcsoloId).HasColumnType("int(11)");
            entity.Property(e => e.TermekTagKapcsoloId).HasColumnType("int(11)");

            entity.HasOne(d => d.IdNavigation).WithOne(p => p.Tagkapcsolo)
                .HasForeignKey<Tagkapcsolo>(d => d.Id)
                .HasConstraintName("tagkapcsolo_ibfk_3");

            entity.HasOne(d => d.TagKapcsolo).WithMany(p => p.Tagkapcsolos)
                .HasForeignKey(d => d.TagKapcsoloId)
                .HasConstraintName("tagkapcsolo_ibfk_2");
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
