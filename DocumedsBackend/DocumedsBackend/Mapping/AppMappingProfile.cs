using AutoMapper;
using DocumedsBackend.Controllers.ContractorOrganizationController;
using DocumedsBackend.Controllers.DoctorController;
using DocumedsBackend.Controllers.FilialController;
using DocumedsBackend.Controllers.PatientController;
using DocumedsBackend.Controllers.ScheduleController;
using DocumedsBackend.Controllers.TagTypeController;

namespace DocumedsBackend.Mapping
{
	public class AppMappingProfile : Profile
	{
		public AppMappingProfile()
		{
			CreateMap<Patient, PatientDto>()
				.ForMember(dest => dest.PatientTags, opt => opt.MapFrom(src => src.PatientTags
					.Select(x => new PatientTagDto { Id = x.Id, IdTag = x.IdTag, Value = x.IdTagNavigation.Value })));
			CreateMap<PatientDto, Patient>()
				.ForMember(dest => dest.PatientTags, opt => opt.MapFrom(src => src.PatientTags
					.Select(x => new PatientTag { Id = x.Id ?? 0, IdTag = x.IdTag })));
			CreateMap<TagType, TagTypeDto>();
			CreateMap<ContractorOrganization, ContractorOrganizationDto>();
			CreateMap<ContractorOrganizationDto, ContractorOrganization>();
			CreateMap<Schedule, ScheduleDto>()
				.ForMember(dest => dest.IdFilial, opt => opt.MapFrom(src => src.IdCabinetNavigation.IdFilial))
				.ForMember(dest => dest.IdDepartment, opt => opt.MapFrom(src => src.IdDoctorPositionNavigation.IdDepartment))
				.ForMember(dest => dest.IdDoctor, opt => opt.MapFrom(src => src.IdDoctorPositionNavigation.IdDoctor))
				.ForMember(dest => dest.DoctorLastName, opt => opt.MapFrom(src => src.IdDoctorPositionNavigation.IdDoctorNavigation.LastName))
				.ForMember(dest => dest.DoctorFirstName, opt => opt.MapFrom(src => src.IdDoctorPositionNavigation.IdDoctorNavigation.FirstName))
				.ForMember(dest => dest.DoctorPatronymic, opt => opt.MapFrom(src => src.IdDoctorPositionNavigation.IdDoctorNavigation.Patronymic))
				.ForMember(dest => dest.DoctorPosition, opt => opt.MapFrom(src => src.IdDoctorPositionNavigation.IdPositionNavigation.Value))				
				.ForMember(dest => dest.Appointments, opt => opt.MapFrom(src => src.Appointments
					.Select(x => new AppointmentDto
					{
						Id = x.Id,
						IdPatient = x.IdPatient,
						IdAppointmentType = x.IdAppointmentType,
						DateTimeFrom = x.DateTimeFrom,
						DateTimeTo = x.DateTimeTo,
						IdAppointmentStatus = x.IdAppointmentStatus,
						IdMedicalCase = x.IdMedicalCase,
						Status = new AppointmentStatusTypeDto
						{
							Id = x.IdAppointmentStatusNavigation.Id,
							Value = x.IdAppointmentStatusNavigation.Value
						},
						Type = new AppointmentTypeDto
						{
							Id = x.IdAppointmentTypeNavigation.Id,
							Value = x.IdAppointmentTypeNavigation.Value
						},
						Patient = new AppointmentPatientDto
						{
							Id = x.IdPatientNavigation.Id,
							LastName = x.IdPatientNavigation.LastName,
							FirstName = x.IdPatientNavigation.FirstName,
							Patronymic = x.IdPatientNavigation.Patronymic,
							Phone = x.IdPatientNavigation.Phone,
							ResidenceAddress = x.IdPatientNavigation.ResidenceAddress,
							BirthDate = x.IdPatientNavigation.BirthDate
						}
					})));
			CreateMap<Filial, FilialDto>()
				.ForMember(dest => dest.Cabinets, opt => opt.MapFrom(src => src.Cabinets
					.Select(x => new CabinetDto { Id = x.Id, IdFilial = x.IdFilial, Name = x.Name, Description = x.Description })))
				.ForMember(dest => dest.Departments, opt => opt.MapFrom(src => src.Departments
					.Select(x => new DepartmentDto { Id = x.Id, IdFilial = x.IdFilial, Name = x.Name, Description = x.Description })));
			CreateMap<Doctor, DoctorDto>()
				.ForMember(dest => dest.Positions, opt => opt.MapFrom(src => src.DoctorPositions
					.Select(x => new DoctorPositionDto
					{
						Id = x.Id,
						IdPosition = x.IdPosition,
						DateStart = x.DateStart,
						DateEnd = x.DateEnd,
						IdDepartment = x.IdDepartment,
						IdFilial = x.IdDepartmentNavigation.IdFilial,
						IdCategory = x.IdCategory,
						IsMainFunction = x.IsMainFunction,
						PositionType = new PositionTypeDto
						{
							Id = x.IdPositionNavigation.Id,
							Value = x.IdPositionNavigation.Value,
							Description = x.IdPositionNavigation.Description
						},
					})));
		}
	}
}
