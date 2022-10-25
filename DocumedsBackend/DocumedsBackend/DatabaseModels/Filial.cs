using System;
using System.Collections.Generic;

namespace DocumedsBackend
{
    public partial class Filial
    {
        public Filial()
        {
            Cabinets = new HashSet<Cabinet>();
        }

        public int Id { get; set; }
        public string? Name { get; set; }
        public int IdOrg { get; set; }
        public string? Address { get; set; }

        public virtual ClientOrganization IdOrgNavigation { get; set; } = null!;
        public virtual ICollection<Cabinet> Cabinets { get; set; }
    }
}
