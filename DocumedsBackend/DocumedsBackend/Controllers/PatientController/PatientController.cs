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
		//private readonly ILogger _logger;
		public PatientController(documeds_dbContext db, IMapper mapper/*, W3CLogger logger*/)
		{
			_db = db;
			_mapper = mapper;
			//_logger = logger;
		}
		/// <summary>
		/// Возвращает список пациентов.
		/// </summary>
		/// <returns>Список пациентов</returns>
		//[Authorize]
		[HttpGet]
		public IActionResult Get()
		{
			var patients = _db.Patients.Include(x => x.PatientAddresses).Include(x => x.PatientDocuments)
				.Include(x => x.PatientTags).ThenInclude(x => x.IdTagNavigation);

			//var test1 = _mapper.Map<PatientDto>(patients.FirstOrDefault());

			//var qs = patients.ToQueryString();

			var patientsToSend = patients.Select(p =>  _mapper.Map<PatientDto>(p));

			//.LogInformation("тест");

			return Ok(Json(patientsToSend));
		}
	}
}
