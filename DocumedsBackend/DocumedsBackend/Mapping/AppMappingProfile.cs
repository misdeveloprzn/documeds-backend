using AutoMapper;
using DocumedsBackend.Controllers.PatientController;

namespace DocumedsBackend.Mapping
{
	public class AppMappingProfile : Profile
	{
		public AppMappingProfile()
		{
			CreateMap<Patient, PatientDto>()
				//.ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
				//.ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.LastName))
				//.ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.FirstName))
				//.ForMember(dest => dest.Patronymic, opt => opt.MapFrom(src => src.Patronymic))
				//.ForMember(dest => dest.BirthDate, opt => opt.MapFrom(src => src.BirthDate))
				//.ForMember(dest => dest.Gender, opt => opt.MapFrom(src => src.Gender))
				//.ForMember(dest => dest.Snils, opt => opt.MapFrom(src => src.Snils))
				//.ForMember(dest => dest.Phone, opt => opt.MapFrom(src => src.Phone))
				//.ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
				//.ForMember(dest => dest.Note, opt => opt.MapFrom(src => src.Note))
				
				.ForMember(dest => dest.PatientTags, opt => opt.MapFrom(src => src.PatientTags
					.Select(x => new PatientTagDto { Id = x.Id, IdTag = x.IdTag, Name = x.IdTagNavigation.Name })));



				
		}
	}
}
