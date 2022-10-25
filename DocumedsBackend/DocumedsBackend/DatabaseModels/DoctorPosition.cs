using System;
using System.Collections.Generic;

namespace DocumedsBackend
{
    public partial class DoctorPosition
    {
        public int Id { get; set; }
        public int? IdPosition { get; set; }
        public int? IdDoctor { get; set; }
        public DateTime? DateStart { get; set; }
        public DateTime? DateEnd { get; set; }
        public int? IdDepartment { get; set; }
        public int? IdCategory { get; set; }
        public int? IsMainFunction { get; set; }
        public int IdOrg { get; set; }
    }
}
