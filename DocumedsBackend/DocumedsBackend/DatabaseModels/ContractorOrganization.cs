using System;
using System.Collections.Generic;

namespace DocumedsBackend
{
    public partial class ContractorOrganization
    {
        public int Id { get; set; }
        public string? Inn { get; set; }
        public string? Kpp { get; set; }
        public string? Ogrn { get; set; }
        public string? FullName { get; set; }
        public string? ShortName { get; set; }
        public string? Website { get; set; }
        public DateTime? DateEnd { get; set; }
        public string? JurAddress { get; set; }
        public string? FactAddress { get; set; }
        public string? RsAccount { get; set; }
        public string? KorrAccount { get; set; }
        public string? Bik { get; set; }
        public string? BankName { get; set; }
        public string? BankAddress { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
    }
}
