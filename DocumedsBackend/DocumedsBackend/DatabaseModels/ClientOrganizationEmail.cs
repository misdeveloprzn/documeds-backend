using System;
using System.Collections.Generic;

namespace DocumedsBackend
{
    public partial class ClientOrganizationEmail
    {
        public int Id { get; set; }
        public int IdOrg { get; set; }
        public string? Email { get; set; }
        public string? Note { get; set; }

        public virtual ClientOrganization IdOrgNavigation { get; set; } = null!;
    }
}
