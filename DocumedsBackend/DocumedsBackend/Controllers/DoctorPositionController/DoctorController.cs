//using AutoMapper;
//using Microsoft.AspNetCore.Authorization;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;
//using System.Security.Claims;

//namespace DocumedsBackend.Controllers.DoctorController
//{
//	[ApiController]
//	[Route("api/[controller]")]
//	public class DoctorPositionController : Controller
//	{
//		private readonly IMapper _mapper;
//		private readonly documeds_dbContext _db;

//		public DoctorPositionController(documeds_dbContext db, IMapper mapper)
//		{
//			_db = db;
//			_mapper = mapper;
//		}
//		/// <summary>
//		/// Возвращает список исполнения должностей.
//		/// </summary>
//		/// <returns>Список исполнения должностей</returns>
//		[Authorize]
//		[HttpGet]
//		public async Task<IActionResult> Get()
//		{
//			try
//			{
//				var orgIdStr = User?.FindFirst(ClaimTypes.Actor).Value;
//				int orgId = int.Parse(orgIdStr ?? "");
//				var schedule = _db.DoctorPositions.Where(x => x.IdOrg == orgId)
//					.Include(x => x.IdDoctorNavigation);
//				var scheduleToSend = await schedule.Select(p => _mapper.Map<ScheduleDto>(p)).ToListAsync();
//				return Ok(Json(scheduleToSend));
//			}
//			catch (Exception e)
//			{
//				ModelState.AddModelError(nameof(e.Message), e.Message);
//				return BadRequest(ModelState);
//			}
//		}
//	}
//}
