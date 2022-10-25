using System;
using System.Collections.Generic;

namespace DocumedsBackend
{
    public partial class PositionCategory
    {
        public int Id { get; set; }
        public string? Value { get; set; }
        public int IdOrg { get; set; }

        public virtual ClientOrganization IdOrgNavigation { get; set; } = null!;
    }
}
