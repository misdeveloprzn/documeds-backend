using System;
using System.Collections.Generic;

namespace DocumedsBackend
{
	public partial class Doctor
    {
        public Doctor()
        {
            DoctorPositions = new HashSet<DoctorPosition>();
        }

        public int Id { get; set; }
        public string? LastName { get; set; }
        public string? FirstName { get; set; }
        public string? Patronymic { get; set; }
        public DateTime? BirthDate { get; set; }
        public int? Gender { get; set; }
        public string? Snils { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public string? Note { get; set; }
        public int IdOrg { get; set; }
        public string? ResidenceAddress { get; set; }
        public string? RegisterAddress { get; set; }
        public string? PassportSeries { get; set; }
        public string? PassportNumber { get; set; }
        public string? PassportIssuer { get; set; }
        public string? PassportIssuerCode { get; set; }
        public DateTime? PassportDateFrom { get; set; }

        public virtual ClientOrganization IdOrgNavigation { get; set; } = null!;
        public virtual ICollection<DoctorPosition> DoctorPositions { get; set; }
    }
}
