using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace DocumedsBackend.Controllers.ScheduleController
{
	[ApiController]
	[Route("api/[controller]")]
	public class ScheduleController : Controller
	{
		private readonly IMapper _mapper;
		private readonly documeds_dbContext _db;

		public ScheduleController(documeds_dbContext db, IMapper mapper)
		{
			_db = db;
			_mapper = mapper;
		}
		/// <summary>
		/// Возвращает все записи расписания по текущей организации.
		/// </summary>
		/// <returns>Список записей расписания</returns>
		[Authorize]
		[HttpGet]
		public async Task<IActionResult> Get()
		{
			try
			{
				var orgIdStr = User?.FindFirst(ClaimTypes.Actor).Value;
				int orgId = int.Parse(orgIdStr ?? "");
				var schedule = _db.Schedules.Where(x => x.IdOrg == orgId)
					.Include(x => x.Appointments).ThenInclude(x => x.IdAppointmentStatusNavigation)
					.Include(x => x.Appointments).ThenInclude(x => x.IdAppointmentTypeNavigation)
					.Include(x => x.Appointments).ThenInclude(x => x.IdPatientNavigation)
					.Include(x => x.IdDoctorPositionNavigation).ThenInclude(x => x.IdDoctorNavigation);


				var scheduleToSend = await schedule.Select(p => _mapper.Map<ScheduleDto>(p)).ToListAsync();
				return Ok(Json(scheduleToSend));
			}
			catch(Exception e)
			{
				ModelState.AddModelError(nameof(e.Message), e.Message);
				return BadRequest(ModelState);
			}
		}
	}
}
