using AutoMapper;
using DocumedsBackend.Controllers.ContractorOrganizationController;
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
				.ForMember(dest => dest.Doctor, opt => opt.MapFrom(src => new DoctorDto
				{
					LastName = src.IdDoctorPositionNavigation.IdDoctorNavigation.LastName,
					FirstName = src.IdDoctorPositionNavigation.IdDoctorNavigation.FirstName,
					Patronymic = src.IdDoctorPositionNavigation.IdDoctorNavigation.Patronymic
				}))
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
						}
					})));
		}
	}
}
