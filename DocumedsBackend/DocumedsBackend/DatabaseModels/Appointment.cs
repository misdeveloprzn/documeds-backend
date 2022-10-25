using System;
using System.Collections.Generic;

namespace DocumedsBackend
{
    public partial class Appointment
    {
        public int Id { get; set; }
        public int IdSchedule { get; set; }
        public int IdPatient { get; set; }
        public int IdAppointmentType { get; set; }
        public DateTime DateTimeFrom { get; set; }
        public DateTime DateTimeTo { get; set; }
        public int IdAppointmentStatus { get; set; }
        public int? IdMedicalCase { get; set; }

        public virtual AppointmentStatusType IdAppointmentStatusNavigation { get; set; } = null!;
        public virtual AppointmentType IdAppointmentTypeNavigation { get; set; } = null!;
        public virtual Patient IdPatientNavigation { get; set; } = null!;
        public virtual Schedule IdScheduleNavigation { get; set; } = null!;
    }
}
