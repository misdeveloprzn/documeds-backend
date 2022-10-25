using System;
using System.Collections.Generic;

namespace DocumedsBackend
{
    public partial class MedicalCase
    {
        public int Id { get; set; }
        public int IdOrg { get; set; }
        public int IdUserCreated { get; set; }
        public int IdDoctorPositionCreated { get; set; }
        public int IdPatient { get; set; }
        public int IsAmbulatory { get; set; }
        public DateTime DateTimeStart { get; set; }
        public DateTime? DateTimeEnd { get; set; }
        public string Value { get; set; } = null!;
    }
}
