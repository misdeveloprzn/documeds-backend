using System;
using System.Collections.Generic;

namespace DocumedsBackend
{
    public partial class ClientOrganization
    {
        public ClientOrganization()
        {
            ClientOrganizationEmails = new HashSet<ClientOrganizationEmail>();
            ClientOrganizationPhones = new HashSet<ClientOrganizationPhone>();
            ContractorOrganizations = new HashSet<ContractorOrganization>();
            Doctors = new HashSet<Doctor>();
            Filials = new HashSet<Filial>();
            Patients = new HashSet<Patient>();
            PositionCategories = new HashSet<PositionCategory>();
            PositionTypes = new HashSet<PositionType>();
            Schedules = new HashSet<Schedule>();
            TagTypes = new HashSet<TagType>();
            Users = new HashSet<User>();
        }

        public int Id { get; set; }
        public string? FullName { get; set; }
        public string? ShortName { get; set; }
        public string? Inn { get; set; }
        public string? Kpp { get; set; }
        public string? Ogrn { get; set; }
        public string? Website { get; set; }
        public string? JurAddress { get; set; }
        public string? FactAddress { get; set; }
        public string? RsAccount { get; set; }
        public string? KorrAccount { get; set; }
        public string? Bik { get; set; }
        public string? BankName { get; set; }
        public string? BankAddress { get; set; }
        public int? HourOpen { get; set; }
        public int? MinuteOpen { get; set; }
        public int? HourClose { get; set; }
        public int? MinuteClose { get; set; }

        public virtual ICollection<ClientOrganizationEmail> ClientOrganizationEmails { get; set; }
        public virtual ICollection<ClientOrganizationPhone> ClientOrganizationPhones { get; set; }
        public virtual ICollection<ContractorOrganization> ContractorOrganizations { get; set; }
        public virtual ICollection<Doctor> Doctors { get; set; }
        public virtual ICollection<Filial> Filials { get; set; }
        public virtual ICollection<Patient> Patients { get; set; }
        public virtual ICollection<PositionCategory> PositionCategories { get; set; }
        public virtual ICollection<PositionType> PositionTypes { get; set; }
        public virtual ICollection<Schedule> Schedules { get; set; }
        public virtual ICollection<TagType> TagTypes { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}
