using System;
using System.Collections.Generic;

namespace DocumedsBackend
{
    public partial class Schedule
    {
        public Schedule()
        {
            Appointments = new HashSet<Appointment>();
        }

        public int Id { get; set; }
        public int IdOrg { get; set; }
        public int IdDoctorPosition { get; set; }
        public int IdCabinet { get; set; }
        public DateTime DateTimeFrom { get; set; }
        public DateTime DateTimeTo { get; set; }

        public virtual Cabinet IdCabinetNavigation { get; set; } = null!;
        public virtual DoctorPosition IdDoctorPositionNavigation { get; set; } = null!;
        public virtual ClientOrganization IdOrgNavigation { get; set; } = null!;
        public virtual ICollection<Appointment> Appointments { get; set; }
    }
}
