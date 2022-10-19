using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DocumedsBackend.Controllers.PatientController
{
	[ApiController]
	[Route("api/[controller]")]
	public class PatientController : Controller
	{
		private readonly IMapper _mapper;
		private readonly documeds_dbContext _db;
		public PatientController(documeds_dbContext db, IMapper mapper)
		{
			_db = db;
			_mapper = mapper;
		}
		/// <summary>
		/// Возвращает информацию о пациенте для выбранной строки комбо-бокса в модальном окне записи пациента.
		/// </summary>
		/// <returns>Информацию о пациенте для отображения в модалке по добавлению записи (AppointmentPersomInfoDto)</returns>
		//[Authorize]
		[HttpGet]
		public IActionResult Get()
		{
			var patients = _db.Patients.Include(x => x.PatientAddresses).Include(x => x.PatientDocuments)
				.Include(x => x.PatientTags).ThenInclude(x => x.IdTagNavigation);

			var test1 = _mapper.Map<PatientDto>(patients.FirstOrDefault());

			var patientsToSend = patients.Select(p =>  _mapper.Map<PatientDto>(p));
			return Ok(Json(patientsToSend));
		}
	}
}
