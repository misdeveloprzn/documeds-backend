using DocumedsBackend;
using System;
using System.Collections.Generic;

namespace DocumedsBackend
{
	public partial class PatientAddress
    {
        public int Id { get; set; }
        public int IdPatient { get; set; }
        public int IdAddressType { get; set; }
        public string? Address { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime? DateTo { get; set; }

        public virtual Patient IdPatientNavigation { get; set; } = null!;
    }
}
