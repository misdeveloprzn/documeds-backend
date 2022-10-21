using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.HttpLogging;
using Microsoft.Extensions.Logging;

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
		/// Возвращает список пациентов.
		/// </summary>
		/// <returns>Список пациентов</returns>
		//[Authorize]
		[HttpGet]
		public async Task<IActionResult> Get()
		{
			var patients = _db.Patients.Include(x => x.PatientTags).ThenInclude(x => x.IdTagNavigation);
			var patientsToSend = await patients.Select(p => _mapper.Map<PatientDto>(p)).ToListAsync();
			//var patientsToSend = Json(patients);
			return Ok(Json(patientsToSend));
		}
		/// <summary>
		/// Создает новую запись пациента.
		/// </summary>
		/// <returns>Информацию по созданному пациенту</returns>
		//[Authorize]
		[HttpPost]
		public async Task<IActionResult> Post(PatientDto dto)
		{
			var patients = _db.Patients//.Include(x => x.PatientAddresses).Include(x => x.PatientDocuments)
				.Include(x => x.PatientTags).ThenInclude(x => x.IdTagNavigation);
			var patientsToSend = await patients.Select(p => _mapper.Map<PatientDto>(p)).ToListAsync();
			return Ok(Json(patientsToSend));
		}
	}
}
