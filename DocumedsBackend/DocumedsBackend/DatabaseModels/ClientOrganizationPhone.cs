using System;
using System.Collections.Generic;

namespace DocumedsBackend
{
    public partial class ClientOrganizationPhone
    {
        public int Id { get; set; }
        public int IdOrg { get; set; }
        public string? Phone { get; set; }
        public string? Note { get; set; }

        public virtual ClientOrganization IdOrgNavigation { get; set; } = null!;
    }
}
