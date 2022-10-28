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

        public virtual DbSet<Appointment> Appointments { get; set; } = null!;
        public virtual DbSet<AppointmentStatusType> AppointmentStatusTypes { get; set; } = null!;
        public virtual DbSet<AppointmentType> AppointmentTypes { get; set; } = null!;
        public virtual DbSet<Cabinet> Cabinets { get; set; } = null!;
        public virtual DbSet<ClientOrganization> ClientOrganizations { get; set; } = null!;
        public virtual DbSet<ClientOrganizationEmail> ClientOrganizationEmails { get; set; } = null!;
        public virtual DbSet<ClientOrganizationPhone> ClientOrganizationPhones { get; set; } = null!;
        public virtual DbSet<ContractorOrganization> ContractorOrganizations { get; set; } = null!;
        public virtual DbSet<Department> Departments { get; set; } = null!;
        public virtual DbSet<Doctor> Doctors { get; set; } = null!;
        public virtual DbSet<DoctorPosition> DoctorPositions { get; set; } = null!;
        public virtual DbSet<Filial> Filials { get; set; } = null!;
        public virtual DbSet<FilialEmail> FilialEmails { get; set; } = null!;
        public virtual DbSet<FilialPhone> FilialPhones { get; set; } = null!;
        public virtual DbSet<MedicalCase> MedicalCases { get; set; } = null!;
        public virtual DbSet<Patient> Patients { get; set; } = null!;
        public virtual DbSet<PatientTag> PatientTags { get; set; } = null!;
        public virtual DbSet<PositionCategory> PositionCategories { get; set; } = null!;
        public virtual DbSet<PositionType> PositionTypes { get; set; } = null!;
        public virtual DbSet<Schedule> Schedules { get; set; } = null!;
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
            modelBuilder.Entity<Appointment>(entity =>
            {
                entity.ToTable("appointment");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.DateTimeFrom).HasColumnName("date_time_from");

                entity.Property(e => e.DateTimeTo).HasColumnName("date_time_to");

                entity.Property(e => e.IdAppointmentStatus).HasColumnName("id_appointment_status");

                entity.Property(e => e.IdAppointmentType).HasColumnName("id_appointment_type");

                entity.Property(e => e.IdMedicalCase).HasColumnName("id_medical_case");

                entity.Property(e => e.IdPatient).HasColumnName("id_patient");

                entity.Property(e => e.IdSchedule).HasColumnName("id_schedule");

                entity.HasOne(d => d.IdAppointmentStatusNavigation)
                    .WithMany(p => p.Appointments)
                    .HasForeignKey(d => d.IdAppointmentStatus)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("appointment_fk2");

                entity.HasOne(d => d.IdAppointmentTypeNavigation)
                    .WithMany(p => p.Appointments)
                    .HasForeignKey(d => d.IdAppointmentType)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("appointment_fk3");

                entity.HasOne(d => d.IdPatientNavigation)
                    .WithMany(p => p.Appointments)
                    .HasForeignKey(d => d.IdPatient)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("appointment_fk1");

                entity.HasOne(d => d.IdScheduleNavigation)
                    .WithMany(p => p.Appointments)
                    .HasForeignKey(d => d.IdSchedule)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("appointment_fk");
            });

            modelBuilder.Entity<AppointmentStatusType>(entity =>
            {
                entity.ToTable("appointment_status_type");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.IdOrg).HasColumnName("id_org");

                entity.Property(e => e.Value)
                    .HasMaxLength(100)
                    .HasColumnName("value");
            });

            modelBuilder.Entity<AppointmentType>(entity =>
            {
                entity.ToTable("appointment_type");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.IdOrg).HasColumnName("id_org");

                entity.Property(e => e.Value)
                    .HasMaxLength(100)
                    .HasColumnName("value");
            });

            modelBuilder.Entity<Cabinet>(entity =>
            {
                entity.ToTable("cabinet");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Description)
                    .HasMaxLength(250)
                    .HasColumnName("description");

                entity.Property(e => e.IdFilial).HasColumnName("id_filial");

                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .HasColumnName("name");

                entity.HasOne(d => d.IdFilialNavigation)
                    .WithMany(p => p.Cabinets)
                    .HasForeignKey(d => d.IdFilial)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("cabinet_fk");
            });

            modelBuilder.Entity<ClientOrganization>(entity =>
            {
                entity.ToTable("client_organization");

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

                entity.Property(e => e.FactAddress)
                    .HasMaxLength(300)
                    .HasColumnName("fact_address");

                entity.Property(e => e.FullName)
                    .HasMaxLength(100)
                    .HasColumnName("full_name");

                entity.Property(e => e.HourClose).HasColumnName("hour_close");

                entity.Property(e => e.HourOpen).HasColumnName("hour_open");

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

                entity.Property(e => e.MinuteClose).HasColumnName("minute_close");

                entity.Property(e => e.MinuteOpen).HasColumnName("minute_open");

                entity.Property(e => e.Ogrn)
                    .HasMaxLength(30)
                    .HasColumnName("ogrn");

                entity.Property(e => e.RsAccount)
                    .HasMaxLength(50)
                    .HasColumnName("rs_account");

                entity.Property(e => e.ShortName)
                    .HasMaxLength(200)
                    .HasColumnName("short_name");

                entity.Property(e => e.Website)
                    .HasMaxLength(100)
                    .HasColumnName("website");
            });

            modelBuilder.Entity<ClientOrganizationEmail>(entity =>
            {
                entity.ToTable("client_organization_email");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .HasColumnName("email");

                entity.Property(e => e.IdOrg).HasColumnName("id_org");

                entity.Property(e => e.Note)
                    .HasMaxLength(100)
                    .HasColumnName("note");

                entity.HasOne(d => d.IdOrgNavigation)
                    .WithMany(p => p.ClientOrganizationEmails)
                    .HasForeignKey(d => d.IdOrg)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("client_organization_email_fk");
            });

            modelBuilder.Entity<ClientOrganizationPhone>(entity =>
            {
                entity.ToTable("client_organization_phone");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.IdOrg).HasColumnName("id_org");

                entity.Property(e => e.Note)
                    .HasMaxLength(100)
                    .HasColumnName("note");

                entity.Property(e => e.Phone)
                    .HasMaxLength(12)
                    .HasColumnName("phone");

                entity.HasOne(d => d.IdOrgNavigation)
                    .WithMany(p => p.ClientOrganizationPhones)
                    .HasForeignKey(d => d.IdOrg)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("client_organization_phone_fk");
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

            modelBuilder.Entity<Department>(entity =>
            {
                entity.ToTable("department");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Description)
                    .HasMaxLength(200)
                    .HasColumnName("description");

                entity.Property(e => e.IdFilial).HasColumnName("id_filial");

                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .HasColumnName("name");

                entity.HasOne(d => d.IdFilialNavigation)
                    .WithMany(p => p.Departments)
                    .HasForeignKey(d => d.IdFilial)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("department_fk");
            });

            modelBuilder.Entity<Doctor>(entity =>
            {
                entity.ToTable("doctor");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.BirthDate).HasColumnName("birth_date");

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
                    .WithMany(p => p.Doctors)
                    .HasForeignKey(d => d.IdOrg)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("doctor_fk1");
            });

            modelBuilder.Entity<DoctorPosition>(entity =>
            {
                entity.ToTable("doctor_position");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.DateEnd).HasColumnName("date_end");

                entity.Property(e => e.DateStart).HasColumnName("date_start");

                entity.Property(e => e.IdCategory).HasColumnName("id_category");

                entity.Property(e => e.IdDepartment).HasColumnName("id_department");

                entity.Property(e => e.IdDoctor).HasColumnName("id_doctor");

                entity.Property(e => e.IdOrg).HasColumnName("id_org");

                entity.Property(e => e.IdPosition).HasColumnName("id_position");

                entity.Property(e => e.IsMainFunction)
                    .HasColumnName("is_main_function")
                    .HasDefaultValueSql("1");

                entity.HasOne(d => d.IdCategoryNavigation)
                    .WithMany(p => p.DoctorPositions)
                    .HasForeignKey(d => d.IdCategory)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("doctor_position_fk2");

                entity.HasOne(d => d.IdDepartmentNavigation)
                    .WithMany(p => p.DoctorPositions)
                    .HasForeignKey(d => d.IdDepartment)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("doctor_position_fk3");

                entity.HasOne(d => d.IdDoctorNavigation)
                    .WithMany(p => p.DoctorPositions)
                    .HasForeignKey(d => d.IdDoctor)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("doctor_position_fk");

                entity.HasOne(d => d.IdPositionNavigation)
                    .WithMany(p => p.DoctorPositions)
                    .HasForeignKey(d => d.IdPosition)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("doctor_position_fk1");
            });

            modelBuilder.Entity<Filial>(entity =>
            {
                entity.ToTable("filial");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Address)
                    .HasMaxLength(500)
                    .HasColumnName("address");

                entity.Property(e => e.IdOrg).HasColumnName("id_org");

                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .HasColumnName("name");

                entity.HasOne(d => d.IdOrgNavigation)
                    .WithMany(p => p.Filials)
                    .HasForeignKey(d => d.IdOrg)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("filial_fk");
            });

            modelBuilder.Entity<FilialEmail>(entity =>
            {
                entity.ToTable("filial_email");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .HasColumnName("email");

                entity.Property(e => e.IdFilial).HasColumnName("id_filial");

                entity.Property(e => e.Note)
                    .HasMaxLength(100)
                    .HasColumnName("note");
            });

            modelBuilder.Entity<FilialPhone>(entity =>
            {
                entity.ToTable("filial_phone");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.IdFilial).HasColumnName("id_filial");

                entity.Property(e => e.Note)
                    .HasMaxLength(100)
                    .HasColumnName("note");

                entity.Property(e => e.Phone)
                    .HasMaxLength(12)
                    .HasColumnName("phone");
            });

            modelBuilder.Entity<MedicalCase>(entity =>
            {
                entity.ToTable("medical_case");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.DateTimeEnd).HasColumnName("date_time_end");

                entity.Property(e => e.DateTimeStart).HasColumnName("date_time_start");

                entity.Property(e => e.IdDoctorPositionCreated).HasColumnName("id_doctor_position_created");

                entity.Property(e => e.IdOrg).HasColumnName("id_org");

                entity.Property(e => e.IdPatient).HasColumnName("id_patient");

                entity.Property(e => e.IdUserCreated).HasColumnName("id_user_created");

                entity.Property(e => e.IsAmbulatory).HasColumnName("is_ambulatory");

                entity.Property(e => e.Value)
                    .HasMaxLength(100)
                    .HasColumnName("value");
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

            modelBuilder.Entity<PositionCategory>(entity =>
            {
                entity.ToTable("position_category");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.IdOrg).HasColumnName("id_org");

                entity.Property(e => e.Value)
                    .HasMaxLength(100)
                    .HasColumnName("value");

                entity.HasOne(d => d.IdOrgNavigation)
                    .WithMany(p => p.PositionCategories)
                    .HasForeignKey(d => d.IdOrg)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("position_category_fk");
            });

            modelBuilder.Entity<PositionType>(entity =>
            {
                entity.ToTable("position_type");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Description)
                    .HasMaxLength(250)
                    .HasColumnName("description");

                entity.Property(e => e.IdOrg).HasColumnName("id_org");

                entity.Property(e => e.Value)
                    .HasMaxLength(100)
                    .HasColumnName("value");

                entity.HasOne(d => d.IdOrgNavigation)
                    .WithMany(p => p.PositionTypes)
                    .HasForeignKey(d => d.IdOrg)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("position_type_fk");
            });

            modelBuilder.Entity<Schedule>(entity =>
            {
                entity.ToTable("schedule");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.DateTimeFrom).HasColumnName("date_time_from");

                entity.Property(e => e.DateTimeTo).HasColumnName("date_time_to");

                entity.Property(e => e.IdCabinet).HasColumnName("id_cabinet");

                entity.Property(e => e.IdDoctorPosition).HasColumnName("id_doctor_position");

                entity.Property(e => e.IdOrg).HasColumnName("id_org");

                entity.HasOne(d => d.IdCabinetNavigation)
                    .WithMany(p => p.Schedules)
                    .HasForeignKey(d => d.IdCabinet)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("schedule_fk2");

                entity.HasOne(d => d.IdDoctorPositionNavigation)
                    .WithMany(p => p.Schedules)
                    .HasForeignKey(d => d.IdDoctorPosition)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("schedule_fk1");

                entity.HasOne(d => d.IdOrgNavigation)
                    .WithMany(p => p.Schedules)
                    .HasForeignKey(d => d.IdOrg)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("schedule_fk");
            });

            modelBuilder.Entity<TagType>(entity =>
            {
                entity.ToTable("tag_type");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.IdOrg).HasColumnName("id_org");

                entity.Property(e => e.Value)
                    .HasMaxLength(50)
                    .HasColumnName("value");

                entity.HasOne(d => d.IdOrgNavigation)
                    .WithMany(p => p.TagTypes)
                    .HasForeignKey(d => d.IdOrg)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("tag_type_fk");
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
