using System;
using System.Collections.Generic;

namespace DocumedsBackend
{
	public partial class AppointmentType
    {
        public AppointmentType()
        {
            Appointments = new HashSet<Appointment>();
        }

        public int Id { get; set; }
        public int IdOrg { get; set; }
        public string? Value { get; set; }

        public virtual ICollection<Appointment> Appointments { get; set; }
    }
}
