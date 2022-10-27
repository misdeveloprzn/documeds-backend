using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace DocumedsBackend.Controllers.ClientOrganizationController
{
	[ApiController]
	[Route("api/[controller]")]
	public class ClientOrganizationController : Controller
	{
		private readonly IMapper _mapper;
		private readonly documeds_dbContext _db;

		public ClientOrganizationController(documeds_dbContext db, IMapper mapper)
		{
			_db = db;
			_mapper = mapper;
		}
		/// <summary>
		/// Возвращает основную информацию по текущей организации.
		/// </summary>
		/// <returns>Список основную информацию по текущей организации</returns>
		[Authorize]
		[HttpGet]
		public async Task<IActionResult> Get()
		{
			try
			{
				var orgIdStr = User?.FindFirst(ClaimTypes.Actor).Value;
				int orgId = int.Parse(orgIdStr ?? "");
				var currentOrganization = await _db.ClientOrganizations.FindAsync(orgId);
				var currentOrganizationToSend = _mapper.Map<ClientOrganizationDto>(currentOrganization);
				return Ok(Json(currentOrganizationToSend));
			}
			catch (Exception e)
			{
				ModelState.AddModelError(nameof(e.Message), e.Message);
				return BadRequest(ModelState);
			}
		}
	}
}
