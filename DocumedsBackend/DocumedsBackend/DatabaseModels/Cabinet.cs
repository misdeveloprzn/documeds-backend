using System;
using System.Collections.Generic;

namespace DocumedsBackend
{
    public partial class Cabinet
    {
        public int Id { get; set; }
        public int IdFilial { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }

        public virtual Filial IdFilialNavigation { get; set; } = null!;
    }
}
