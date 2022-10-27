namespace DocumedsBackend.Controllers.ScheduleController
{
	public class ScheduleDto
	{
		public int Id { get; set; }
		public int IdDoctorPosition { get; set; }
		public int IdCabinet { get; set; }
		public DateTime DateTimeFrom { get; set; }
		public DateTime DateTimeTo { get; set; }
		public DoctorInfoDto Doctor { get; set; }
		public List<AppointmentDto> Appointments { get; set; }
	}
	public class AppointmentDto
	{
		public int Id { get; set; }
		public int IdPatient { get; set; }
		public int IdAppointmentType { get; set; }
		public DateTime DateTimeFrom { get; set; }
		public DateTime DateTimeTo { get; set; }
		public int IdAppointmentStatus { get; set; }
		public int? IdMedicalCase { get; set; }
		public AppointmentStatusTypeDto Status { get; set; }
		public AppointmentTypeDto Type { get; set; }
		public AppointmentPatientDto Patient { get; set; }
	}
	public class AppointmentStatusTypeDto
	{
		public int Id { get; set; }
		public string? Value { get; set; }
	}
	public class AppointmentTypeDto
	{
		public int Id { get; set; }
		public string? Value { get; set; }
	}
	public class DoctorInfoDto
	{
		public string? LastName { get; set; }
		public string? FirstName { get; set; }
		public string? Patronymic { get; set; }
	}
	public class AppointmentPatientDto
	{
		public int Id { get; set; }
		public string LastName { get; set; }
		public string FirstName { get; set; }
		public string? Patronymic { get; set; }
		public string? Phone { get; set; }
		public string? ResidenceAddress { get; set; }
		public DateTime? BirthDate { get; set; }
	}
}
