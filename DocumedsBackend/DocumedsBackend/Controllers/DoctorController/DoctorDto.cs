namespace DocumedsBackend.Controllers.DoctorController
{
	public class DoctorDto
	{
        public int Id { get; set; }
        public string? LastName { get; set; }
        public string? FirstName { get; set; }
        public string? Patronymic { get; set; }
        public DateTime? BirthDate { get; set; }
        public int? Gender { get; set; }
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
        public List<DoctorPositionDto> Positions { get; set; }
    }
    public class DoctorPositionDto
    {
        public int Id { get; set; }
        public int IdPosition { get; set; }
        public DateTime DateStart { get; set; }
        public DateTime? DateEnd { get; set; }
        public int IdDepartment { get; set; }
        public int IdFilial { get; set; }
        public int IdCategory { get; set; }
        public int IsMainFunction { get; set; }
        public PositionTypeDto PositionType { get; set; }
    }
    public class PositionTypeDto
    {
        public int Id { get; set; }
        public string? Value { get; set; }
        public string? Description { get; set; }
    }
}
