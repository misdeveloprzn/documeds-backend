using System;
using System.Collections.Generic;

namespace DocumedsBackend
{
    public partial class ClientOrganization
    {
        public ClientOrganization()
        {
            Patients = new HashSet<Patient>();
            Users = new HashSet<User>();
        }

        public int Id { get; set; }
        public string? FullName { get; set; }
        public string? ShortName { get; set; }

        public virtual ICollection<Patient> Patients { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}
