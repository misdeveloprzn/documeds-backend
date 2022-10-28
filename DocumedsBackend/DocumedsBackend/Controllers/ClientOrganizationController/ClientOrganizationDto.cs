namespace DocumedsBackend.Controllers.ClientOrganizationController
{
	public class ClientOrganizationDto
	{
        public int Id { get; set; }
        public string? FullName { get; set; }
        public string? ShortName { get; set; }
        public string? Inn { get; set; }
        public string? Kpp { get; set; }
        public string? Ogrn { get; set; }
        public string? Website { get; set; }
        public string? JurAddress { get; set; }
        public string? FactAddress { get; set; }
        public string? RsAccount { get; set; }
        public string? KorrAccount { get; set; }
        public string? Bik { get; set; }
        public string? BankName { get; set; }
        public string? BankAddress { get; set; }
        public int? HourOpen { get; set; }
        public int? MinuteOpen { get; set; }
        public int? HourClose { get; set; }
        public int? MinuteClose { get; set; }
    }
}
