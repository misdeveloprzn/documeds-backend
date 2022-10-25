using System;
using System.Collections.Generic;

namespace DocumedsBackend
{
    public partial class Department
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int? IdFilial { get; set; }
        public string? Description { get; set; }
    }
}
