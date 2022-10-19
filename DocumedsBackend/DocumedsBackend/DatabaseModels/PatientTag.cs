using DocumedsBackend;
using System;
using System.Collections.Generic;

namespace DocumedsBackend
{
	public partial class PatientTag
    {
        public int Id { get; set; }
        public int IdPatient { get; set; }
        public int IdTag { get; set; }

        public virtual Patient IdPatientNavigation { get; set; } = null!;
        public virtual TagType IdTagNavigation { get; set; } = null!;
    }
}
