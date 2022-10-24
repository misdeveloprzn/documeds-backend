using AutoMapper;
using DocumedsBackend.Controllers.ContractorOrganizationController;
using DocumedsBackend.Controllers.PatientController;
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
		}
	}
}
