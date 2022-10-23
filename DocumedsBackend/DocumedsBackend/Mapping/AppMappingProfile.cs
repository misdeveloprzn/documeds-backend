﻿using AutoMapper;
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
					.Select(x => new PatientTagDto { Id = x.Id, IdTag = x.IdTag, Name = x.IdTagNavigation.Name })));
			CreateMap<PatientDto, Patient>()
				.ForMember(dest => dest.PatientTags, opt => opt.MapFrom(src => src.PatientTags
					.Select(x => new PatientTag { Id = x.Id ?? 0, IdTag = x.IdTag })));
			CreateMap<TagType, TagTypeDto>()
				.ForMember(dest => dest.Value, opt => opt.MapFrom(src => src.Name));
		}
	}
}
