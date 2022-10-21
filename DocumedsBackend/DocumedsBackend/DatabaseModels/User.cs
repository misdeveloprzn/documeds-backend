using System;
using System.Collections.Generic;

namespace DocumedsBackend
{
    public partial class User
    {
        public int Id { get; set; }
        public string Login { get; set; } = null!;
        public string Password { get; set; } = null!;
        public int IdOrg { get; set; }

        public virtual ClientOrganization IdOrgNavigation { get; set; } = null!;
    }
}
