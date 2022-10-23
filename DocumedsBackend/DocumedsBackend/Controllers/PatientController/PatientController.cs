using AutoMapper;
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
		/// Возвращает список пациентов.
		/// </summary>
		/// <returns>Список пациентов</returns>
		//[Authorize]
		[HttpGet]
		public async Task<IActionResult> Get()
		{
			var patients = _db.Patients.Include(x => x.PatientTags).ThenInclude(x => x.IdTagNavigation);
			var patientsToSend = await patients.Select(p => _mapper.Map<PatientDto>(p)).ToListAsync();
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
			try
			{
				var patient = _mapper.Map<Patient>(dto);
				patient.IdOrg = 1;
				_db.Patients.Add(patient);
				await _db.SaveChangesAsync();
				var patientToSend = _mapper.Map<PatientDto>(await _db.Patients.Include(x => x.PatientTags).ThenInclude(x => x.IdTagNavigation)
				.SingleOrDefaultAsync(x => x.Id == patient.Id));
				return Ok(Json(patientToSend));
			}
			catch(Exception e)
			{
				ModelState.AddModelError(nameof(e.Message), "Что-то пошло не так!");
				return BadRequest(ModelState);
			}
		}
		/// <summary>
		/// Редактирует существующую запись пациента.
		/// </summary>
		/// <returns>Информацию по созданному пациенту</returns>
		//[Authorize]
		[HttpPut]
		public async Task<IActionResult> Put(PatientDto dto)
		{
			var patient = await _db.Patients.FindAsync(dto.Id);
			_mapper.Map(dto, patient);
			await _db.SaveChangesAsync();
			return Ok();
		}
		/// <summary>
		/// Удаляет существующую запись пациента.
		/// </summary>
		/// <returns>Информацию по созданному пациенту</returns>
		//[Authorize]
		[HttpDelete("{id}")]
		public async Task<IActionResult> Delete(int id)
		{
			var patient = await _db.Patients.FindAsync(id);
			if(patient != null)
				_db.Patients.Remove(patient);
			await _db.SaveChangesAsync();
			return Ok();
		}
	}
}
