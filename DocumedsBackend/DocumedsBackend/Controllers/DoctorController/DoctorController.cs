using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace DocumedsBackend.Controllers.DoctorController
{
	[ApiController]
	[Route("api/[controller]")]
	public class DoctorController : Controller
	{
		private readonly IMapper _mapper;
		private readonly documeds_dbContext _db;

		public DoctorController(documeds_dbContext db, IMapper mapper)
		{
			_db = db;
			_mapper = mapper;
		}
		/// <summary>
		/// Возвращает список текущих исполнений должностей.
		/// </summary>
		/// <returns>Список текущих исполнений должностей</returns>
		[Authorize]
		[HttpGet]
		public async Task<IActionResult> Get()
		{
			try
			{
				var orgIdStr = User?.FindFirst(ClaimTypes.Actor).Value;
				int orgId = int.Parse(orgIdStr ?? "");
				var doctors = _db.Doctors.Where(x => x.IdOrg == orgId)
					.Include(x => x.DoctorPositions).ThenInclude(x => x.IdPositionNavigation)
					.Include(x => x.DoctorPositions).ThenInclude(x => x.IdDepartmentNavigation);
				var doctorsToSend = await doctors.Select(p => _mapper.Map<DoctorDto>(p)).ToListAsync();
				return Ok(Json(doctorsToSend));
			}
			catch (Exception e)
			{
				ModelState.AddModelError(nameof(e.Message), e.Message);
				return BadRequest(ModelState);
			}
		}
	}
}
