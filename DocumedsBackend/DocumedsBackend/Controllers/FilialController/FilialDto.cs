namespace DocumedsBackend.Controllers.FilialController
{
	public class FilialDto
	{
		public int? Id { get; set; }
		public string? Name { get; set; }
		public string? Address { get; set; }
		public List<CabinetDto> Cabinets { get; set; }
		public List<DepartmentDto> Departments { get; set; }
	}
	public class CabinetDto
	{
		public int? Id { get; set; }
		public int IdFilial { get; set; }
		public string? Name { get; set; }
		public string? Description { get; set; }
	}
	public class DepartmentDto
	{
		public int? Id { get; set; }
		public int IdFilial { get; set; }
		public string? Name { get; set; }
		public string? Description { get; set; }
	}
}
