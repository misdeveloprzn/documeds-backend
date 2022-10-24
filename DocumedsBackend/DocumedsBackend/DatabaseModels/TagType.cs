using System;
using System.Collections.Generic;

namespace DocumedsBackend
{
    public partial class TagType
    {
        public TagType()
        {
            PatientTags = new HashSet<PatientTag>();
        }

        public int Id { get; set; }
        public string Value { get; set; } = null!;

        public virtual ICollection<PatientTag> PatientTags { get; set; }
    }
}
