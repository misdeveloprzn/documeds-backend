using System;
using System.Collections.Generic;

namespace DocumedsBackend
{
    public partial class FilialEmail
    {
        public int Id { get; set; }
        public int IdFilial { get; set; }
        public string? Email { get; set; }
        public string? Note { get; set; }
    }
}
