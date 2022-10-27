using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace DocumedsBackend.Controllers.FilialController
{
	[ApiController]
	[Route("api/[controller]")]
	public class FilialController : Controller
	{
		private readonly IMapper _mapper;
		private readonly documeds_dbContext _db;

		public FilialController(documeds_dbContext db, IMapper mapper)
		{
			_db = db;
			_mapper = mapper;
		}
		/// <summary>
		/// Возвращает список филиалов с детализацией по подразделениям и кабинетам.
		/// </summary>
		/// <returns>Список филиалов с детализацией по подразделениям и кабинетам</returns>
		[Authorize]
		[HttpGet]
		public async Task<IActionResult> Get()
		{
			var orgIdStr = User?.FindFirst(ClaimTypes.Actor).Value;
			int orgId;
			if (int.TryParse(orgIdStr, out orgId))
			{
				var filials = _db.Filials.Where(x => x.IdOrg == orgId).Include(x => x.Cabinets).Include(x => x.Departments);
				var filialsToSend = await filials.Select(p => _mapper.Map<FilialDto>(p)).ToListAsync();
				return Ok(Json(filialsToSend));
			}
			else
			{
				ModelState.AddModelError(nameof(orgId), "Данная организация не существует!");
				return BadRequest(ModelState);
			}
		}
	}
}
