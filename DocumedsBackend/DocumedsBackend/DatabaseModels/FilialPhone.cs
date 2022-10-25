using System;
using System.Collections.Generic;

namespace DocumedsBackend
{
    public partial class FilialPhone
    {
        public int Id { get; set; }
        public int IdFilial { get; set; }
        public string? Phone { get; set; }
        public string? Note { get; set; }
    }
}
