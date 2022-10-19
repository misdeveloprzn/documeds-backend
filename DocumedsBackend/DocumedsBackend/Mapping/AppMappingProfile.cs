using AutoMapper;
using DocumedsBackend.Controllers.PatientController;

namespace DocumedsBackend.Mapping
{
	public class AppMappingProfile : Profile
	{
		public AppMappingProfile()
		{
			CreateMap<Patient, PatientDto>()
				.ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
				.ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.LastName))
				.ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.FirstName))
				.ForMember(dest => dest.Patronymic, opt => opt.MapFrom(src => src.Patronymic))
				.ForMember(dest => dest.BirthDate, opt => opt.MapFrom(src => src.BirthDate))
				.ForMember(dest => dest.Gender, opt => opt.MapFrom(src => src.Gender))
				.ForMember(dest => dest.Snils, opt => opt.MapFrom(src => src.Snils))
				.ForMember(dest => dest.Phone, opt => opt.MapFrom(src => src.Phone))
				.ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
				.ForMember(dest => dest.Note, opt => opt.MapFrom(src => src.Note))
				.ForMember(dest => dest.IdAddressResidence, opt => opt.MapFrom(src => src.PatientAddresses
					.FirstOrDefault(x => x.IdAddressType == 1 && x.DateFrom <= DateTime.Today && x.DateTo == null).Id))
				.ForMember(dest => dest.AddressResidence, opt => opt.MapFrom(src => src.PatientAddresses
					.FirstOrDefault(x => x.IdAddressType == 1 && x.DateFrom <= DateTime.Today && x.DateTo == null).Address))
				.ForMember(dest => dest.IdAddressRegister, opt => opt.MapFrom(src => src.PatientAddresses
					.FirstOrDefault(x => x.IdAddressType == 2 && x.DateFrom <= DateTime.Today && x.DateTo == null).Id))
				.ForMember(dest => dest.AddressRegister, opt => opt.MapFrom(src => src.PatientAddresses
					.FirstOrDefault(x => x.IdAddressType == 2 && x.DateFrom <= DateTime.Today && x.DateTo == null).Address))
				.ForMember(dest => dest.IdPassport, opt => opt.MapFrom(src => src.PatientDocuments
					.FirstOrDefault(x => x.IdDocumentType == 1 && x.DateFrom <= DateTime.Today && x.DateTo == null).Id))
				.ForMember(dest => dest.PassportSeries, opt => opt.MapFrom(src => src.PatientDocuments
					.FirstOrDefault(x => x.IdDocumentType == 1 && x.DateFrom <= DateTime.Today && x.DateTo == null).Series))
				.ForMember(dest => dest.PassportNumber, opt => opt.MapFrom(src => src.PatientDocuments
					.FirstOrDefault(x => x.IdDocumentType == 1 && x.DateFrom <= DateTime.Today && x.DateTo == null).Number))
				.ForMember(dest => dest.PassportIssuer, opt => opt.MapFrom(src => src.PatientDocuments
					.FirstOrDefault(x => x.IdDocumentType == 1 && x.DateFrom <= DateTime.Today && x.DateTo == null).Issuer))
				.ForMember(dest => dest.PassportIssuerCode, opt => opt.MapFrom(src => src.PatientDocuments
					.FirstOrDefault(x => x.IdDocumentType == 1 && x.DateFrom <= DateTime.Today && x.DateTo == null).IssuerCode))
				.ForMember(dest => dest.PassportDateFrom, opt => opt.MapFrom(src => src.PatientDocuments
					.FirstOrDefault(x => x.IdDocumentType == 1 && x.DateFrom <= DateTime.Today && x.DateTo == null).DateFrom))
				.ForMember(dest => dest.PatientTags, opt => opt.MapFrom(src => src.PatientTags
					.Select(x => new PatientTagDto { IdPatientTag = x.Id, Name = x.IdTagNavigation.Name })));



				
		}
	}
}
