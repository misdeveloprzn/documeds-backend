using DocumedsBackend;
using System;
using System.Collections.Generic;

namespace DocumedsBackend
{
	public partial class PatientDocument
    {
        public int Id { get; set; }
        public int IdPatient { get; set; }
        public int IdDocumentType { get; set; }
        public string? Series { get; set; }
        public string? Number { get; set; }
        public string? Issuer { get; set; }
        public string? IssuerCode { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime? DateTo { get; set; }

        public virtual Patient IdPatientNavigation { get; set; } = null!;
    }
}
