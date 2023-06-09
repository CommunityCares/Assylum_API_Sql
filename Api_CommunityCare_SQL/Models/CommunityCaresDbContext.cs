using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Api_CommunityCare_SQL.Models;

public partial class CommunityCaresDbContext : DbContext
{
    public CommunityCaresDbContext()
    {
    }

    public CommunityCaresDbContext(DbContextOptions<CommunityCaresDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Admin> Admins { get; set; }

    public virtual DbSet<Assylum> Assylums { get; set; }

    public virtual DbSet<Campaign> Campaigns { get; set; }

    public virtual DbSet<Collect> Collects { get; set; }

    public virtual DbSet<Donation> Donations { get; set; }

    public virtual DbSet<Donor> Donor { get; set; }

    public virtual DbSet<Image> Images { get; set; }

    public virtual DbSet<Person> People { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=MSI\\SQLEXPRESS;Database=CommunityCaresDB;User=sa;Password=univalle;Trusted_Connection=True;Encrypt=False;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Admin>(entity =>
        {
            entity.ToTable("Admin");

            entity.Property(e => e.Id).ValueGeneratedNever();

            //entity.HasOne(d => d.IdNavigation).WithOne(p => p.Admin)
            //    .HasForeignKey<Admin>(d => d.Id)
            //    .OnDelete(DeleteBehavior.ClientSetNull)
            //    .HasConstraintName("FK_Admin_Person");

            //entity.HasOne(d => d.IdAssylumNavigation).WithMany(p => p.Admins)
            //    .HasForeignKey(d => d.IdAssylum)
            //    .OnDelete(DeleteBehavior.ClientSetNull)
            //    .HasConstraintName("FK_Admin_Assylum");
        });

        modelBuilder.Entity<Assylum>(entity =>
        {
            entity.ToTable("Assylum");

            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.Address)
                .HasMaxLength(150)
                .IsUnicode(false);
            entity.Property(e => e.BussinessEmail)
                .HasMaxLength(150)
                .IsUnicode(false);
            entity.Property(e => e.CellphoneNumber)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Latitude).HasColumnName("latitude");
            entity.Property(e => e.Longitude).HasColumnName("longitude");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Nit)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Region)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.RegisterDate).HasColumnType("datetime");
            entity.Property(e => e.RepresentativeName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Status).HasColumnName("status");
        });

        modelBuilder.Entity<Campaign>(entity =>
        {
            entity.ToTable("Campaign");

            entity.Property(e => e.CloseDate).HasColumnType("datetime");
            entity.Property(e => e.InitialDate).HasColumnType("datetime");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.RegisterDate).HasColumnType("datetime");
            entity.Property(e => e.Requirement)
                .HasMaxLength(50)
                .IsUnicode(false);

            //entity.HasOne(d => d.IdAssylumNavigation).WithMany(p => p.Campaigns)
            //    .HasForeignKey(d => d.IdAssylum)
            //    .OnDelete(DeleteBehavior.ClientSetNull)
            //    .HasConstraintName("FK_Campaign_Assylum");
        });

        modelBuilder.Entity<Collect>(entity =>
        {
            entity.ToTable("Collect");

            entity.Property(e => e.Date)
                .HasColumnType("datetime")
                .HasColumnName("date");
            entity.Property(e => e.IdCampaign).HasColumnName("idCampaign");

            //entity.HasOne(d => d.IdCampaignNavigation).WithMany(p => p.Collects)
            //    .HasForeignKey(d => d.IdCampaign)
            //    .OnDelete(DeleteBehavior.ClientSetNull)
            //    .HasConstraintName("FK_Collect_Campaign");
        });

        modelBuilder.Entity<Donation>(entity =>
        {
            entity.ToTable("Donation");

            entity.Property(e => e.DescriptionItems)
                .HasMaxLength(150)
                .IsUnicode(false);
            entity.Property(e => e.DescriptionMonto).HasColumnType("decimal(10, 0)");
            entity.Property(e => e.Hour)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.IsAnonymus)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.IsReceived)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.RegisterDate).HasColumnType("datetime");
            entity.Property(e => e.Status).HasColumnName("status");

            //entity.HasOne(d => d.IdCampaignNavigation).WithMany(p => p.Donations)
            //    .HasForeignKey(d => d.IdCampaign)
            //    .OnDelete(DeleteBehavior.ClientSetNull)
            //    .HasConstraintName("FK_Donation_Campaign");

            //entity.HasOne(d => d.IdDonnorsNavigation).WithMany(p => p.Donations)
            //    .HasForeignKey(d => d.IdDonnors)
            //    .OnDelete(DeleteBehavior.ClientSetNull)
            //    .HasConstraintName("FK_Donation_Donors");
        });

        modelBuilder.Entity<Donor>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Address)
                .HasMaxLength(150)
                .IsUnicode(false);
            entity.Property(e => e.Region)
                .HasMaxLength(50)
                .IsUnicode(false);

            //entity.HasOne(d => d.IdNavigation).WithOne(p => p.Donor)
            //    .HasForeignKey<Donor>(d => d.Id)
            //    .OnDelete(DeleteBehavior.ClientSetNull)
            //    .HasConstraintName("FK_Donors_Person");
        });

        modelBuilder.Entity<Image>(entity =>
        {
            entity.Property(e => e.Nombre)
                .HasMaxLength(70)
                .IsUnicode(false);
            entity.Property(e => e.Url)
                .HasMaxLength(200)
                .IsUnicode(false);

            //entity.HasOne(d => d.IdCampaignNavigation).WithMany(p => p.Images)
            //    .HasForeignKey(d => d.IdCampaign)
            //    .HasConstraintName("FK_Images_Campaign");
        });

        modelBuilder.Entity<Person>(entity =>
        {
            entity.ToTable("Person");

            entity.Property(e => e.Ci)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.LastName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(60)
                .IsUnicode(false);
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.RegisterDate).HasColumnType("datetime");
            entity.Property(e => e.SecondLastName)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.ToTable("User");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Email)
                .HasMaxLength(150)
                .IsUnicode(false);
            entity.Property(e => e.Password).IsUnicode(false);
            entity.Property(e => e.Role)
                .HasMaxLength(50)
                .IsUnicode(false);

            //entity.HasOne(d => d.IdNavigation).WithOne(p => p.User)
            //    .HasForeignKey<User>(d => d.Id)
            //    .OnDelete(DeleteBehavior.ClientSetNull)
            //    .HasConstraintName("FK_User_Person");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
