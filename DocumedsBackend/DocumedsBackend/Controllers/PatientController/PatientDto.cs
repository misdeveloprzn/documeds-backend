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
		public string? Snils { get; set; }
		public string? Phone { get; set; }
		public string? Email { get; set; }
		public string? Note { get; set; }
		public string? ResidenceAddress { get; set; }
		public string? RegisterAddress { get; set; }
		public string? PassportSeries { get; set; }
		public string? PassportNumber { get; set; }
		public string? PassportIssuer { get; set; }
		public string? PassportIssuerCode { get; set; }
		public DateTime? PassportDateFrom { get; set; }
		public List<PatientTagDto> PatientTags { get; set; }
	}

	public class PatientTagDto
	{
		public int? Id { get; set; }
		public int IdTag { get; set; }
		public string Name { get; set; }
	}
}
