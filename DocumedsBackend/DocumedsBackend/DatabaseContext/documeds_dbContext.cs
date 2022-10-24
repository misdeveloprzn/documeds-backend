using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DocumedsBackend
{
    public partial class documeds_dbContext : DbContext
    {
        public documeds_dbContext()
        {
        }

        public documeds_dbContext(DbContextOptions<documeds_dbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ClientOrganization> ClientOrganizations { get; set; } = null!;
        public virtual DbSet<ContractorOrganization> ContractorOrganizations { get; set; } = null!;
        public virtual DbSet<Patient> Patients { get; set; } = null!;
        public virtual DbSet<PatientTag> PatientTags { get; set; } = null!;
        public virtual DbSet<TagType> TagTypes { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseNpgsql("Host=192.168.0.157;Port=5432;Database=documeds_db;Username=root;Password=123456;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ClientOrganization>(entity =>
            {
                entity.ToTable("client_organization");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.FullName)
                    .HasMaxLength(100)
                    .HasColumnName("full_name");

                entity.Property(e => e.ShortName)
                    .HasMaxLength(200)
                    .HasColumnName("short_name");
            });

            modelBuilder.Entity<ContractorOrganization>(entity =>
            {
                entity.ToTable("contractor_organization");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.BankAddress)
                    .HasMaxLength(300)
                    .HasColumnName("bank_address");

                entity.Property(e => e.BankName)
                    .HasMaxLength(150)
                    .HasColumnName("bank_name");

                entity.Property(e => e.Bik)
                    .HasMaxLength(50)
                    .HasColumnName("bik");

                entity.Property(e => e.DateEnd).HasColumnName("date_end");

                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .HasColumnName("email");

                entity.Property(e => e.FactAddress)
                    .HasMaxLength(300)
                    .HasColumnName("fact_address");

                entity.Property(e => e.FullName)
                    .HasMaxLength(300)
                    .HasColumnName("full_name");

                entity.Property(e => e.IdOrg).HasColumnName("id_org");

                entity.Property(e => e.Inn)
                    .HasMaxLength(30)
                    .HasColumnName("inn");

                entity.Property(e => e.JurAddress)
                    .HasMaxLength(300)
                    .HasColumnName("jur_address");

                entity.Property(e => e.KorrAccount)
                    .HasMaxLength(50)
                    .HasColumnName("korr_account");

                entity.Property(e => e.Kpp)
                    .HasMaxLength(30)
                    .HasColumnName("kpp");

                entity.Property(e => e.Ogrn)
                    .HasMaxLength(30)
                    .HasColumnName("ogrn");

                entity.Property(e => e.Phone)
                    .HasMaxLength(12)
                    .HasColumnName("phone");

                entity.Property(e => e.RsAccount)
                    .HasMaxLength(50)
                    .HasColumnName("rs_account");

                entity.Property(e => e.ShortName)
                    .HasMaxLength(150)
                    .HasColumnName("short_name");

                entity.Property(e => e.Website)
                    .HasMaxLength(100)
                    .HasColumnName("website");

                entity.HasOne(d => d.IdOrgNavigation)
                    .WithMany(p => p.ContractorOrganizations)
                    .HasForeignKey(d => d.IdOrg)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("contractor_organization_fk");
            });

            modelBuilder.Entity<Patient>(entity =>
            {
                entity.ToTable("patient");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.BirthDate).HasColumnName("birth_date");

                entity.Property(e => e.DateEnd).HasColumnName("date_end");

                entity.Property(e => e.DateStart).HasColumnName("date_start");

                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .HasColumnName("email");

                entity.Property(e => e.FirstName)
                    .HasMaxLength(50)
                    .HasColumnName("first_name");

                entity.Property(e => e.Gender).HasColumnName("gender");

                entity.Property(e => e.IdOrg).HasColumnName("id_org");

                entity.Property(e => e.LastName)
                    .HasMaxLength(50)
                    .HasColumnName("last_name");

                entity.Property(e => e.Note)
                    .HasMaxLength(200)
                    .HasColumnName("note");

                entity.Property(e => e.PassportDateFrom).HasColumnName("passport_date_from");

                entity.Property(e => e.PassportIssuer)
                    .HasMaxLength(100)
                    .HasColumnName("passport_issuer");

                entity.Property(e => e.PassportIssuerCode)
                    .HasMaxLength(10)
                    .HasColumnName("passport_issuer_code");

                entity.Property(e => e.PassportNumber)
                    .HasMaxLength(15)
                    .HasColumnName("passport_number");

                entity.Property(e => e.PassportSeries)
                    .HasMaxLength(10)
                    .HasColumnName("passport_series");

                entity.Property(e => e.Patronymic)
                    .HasMaxLength(50)
                    .HasColumnName("patronymic");

                entity.Property(e => e.Phone)
                    .HasMaxLength(12)
                    .HasColumnName("phone");

                entity.Property(e => e.RegisterAddress)
                    .HasMaxLength(300)
                    .HasColumnName("register_address");

                entity.Property(e => e.ResidenceAddress)
                    .HasMaxLength(300)
                    .HasColumnName("residence_address");

                entity.Property(e => e.Snils)
                    .HasMaxLength(14)
                    .HasColumnName("snils");

                entity.HasOne(d => d.IdOrgNavigation)
                    .WithMany(p => p.Patients)
                    .HasForeignKey(d => d.IdOrg)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("patient_fk");
            });

            modelBuilder.Entity<PatientTag>(entity =>
            {
                entity.ToTable("patient_tag");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.IdPatient).HasColumnName("id_patient");

                entity.Property(e => e.IdTag).HasColumnName("id_tag");

                entity.HasOne(d => d.IdPatientNavigation)
                    .WithMany(p => p.PatientTags)
                    .HasForeignKey(d => d.IdPatient)
                    .HasConstraintName("patient_tag_fk1");

                entity.HasOne(d => d.IdTagNavigation)
                    .WithMany(p => p.PatientTags)
                    .HasForeignKey(d => d.IdTag)
                    .HasConstraintName("patient_tag_fk2");
            });

            modelBuilder.Entity<TagType>(entity =>
            {
                entity.ToTable("tag_type");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Value)
                    .HasMaxLength(50)
                    .HasColumnName("value");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("user");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.IdOrg).HasColumnName("id_org");

                entity.Property(e => e.Login)
                    .HasMaxLength(100)
                    .HasColumnName("login");

                entity.Property(e => e.Password)
                    .HasMaxLength(30)
                    .HasColumnName("password");

                entity.HasOne(d => d.IdOrgNavigation)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.IdOrg)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("user_fk");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
