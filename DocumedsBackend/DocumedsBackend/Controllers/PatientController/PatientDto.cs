namespace DocumedsBackend.Controllers.PatientController
{
	public class PatientDto
	{
		public int? Id { get; set; }
		public string LastName { get; set; } = null!;
		public string FirstName { get; set; } = null!;
		public string? Patronymic { get; set; }
		public DateTime? BirthDate { get; set; }
		public int Gender { get; set; }
		public string GenderStr => Gender == 0 ? "Женский" : (Gender == 1 ? "Мужской" : "Не определен");
		public string? Snils { get; set; }
		public string? Phone { get; set; }
		public string? Email { get; set; }
		public string? Note { get; set; }
		public int? IdAddressResidence { get; set; }
		public string? AddressResidence { get; set; }
		public int? IdAddressRegister { get; set; }
		public string? AddressRegister { get; set; }
		public int? IdPassport { get; set; }
		public string? PassportSeries { get; set; }
		public string? PassportNumber { get; set; }
		public string? PassportIssuer { get; set; }
		public string? PassportIssuerCode { get; set; }
		public DateTime? PassportDateFrom { get; set; }
		public List<PatientTagDto>? PatientTags { get; set; }
	}

	public class PatientTagDto
	{
		public int? IdPatientTag { get; set; }
		public string? Name { get; set; }
	}
}
