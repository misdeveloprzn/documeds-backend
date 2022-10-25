using System;
using System.Collections.Generic;

namespace DocumedsBackend
{
	public partial class Patient
    {
        public Patient()
        {
            Appointments = new HashSet<Appointment>();
            PatientTags = new HashSet<PatientTag>();
        }

        public int Id { get; set; }
        public string LastName { get; set; } = null!;
        public string FirstName { get; set; } = null!;
        public string? Patronymic { get; set; }
        public DateTime? BirthDate { get; set; }
        public int Gender { get; set; }
        public string? Snils { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public string? Note { get; set; }
        public DateTime DateStart { get; set; }
        public DateTime? DateEnd { get; set; }
        public int IdOrg { get; set; }
        public string? ResidenceAddress { get; set; }
        public string? RegisterAddress { get; set; }
        public string? PassportSeries { get; set; }
        public string? PassportNumber { get; set; }
        public string? PassportIssuer { get; set; }
        public string? PassportIssuerCode { get; set; }
        public DateTime? PassportDateFrom { get; set; }

        public virtual ClientOrganization IdOrgNavigation { get; set; } = null!;
        public virtual ICollection<Appointment> Appointments { get; set; }
        public virtual ICollection<PatientTag> PatientTags { get; set; }
    }
}
