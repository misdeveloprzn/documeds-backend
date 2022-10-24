using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DocumedsBackend.Controllers.ContractorOrganizationController
{
	[ApiController]
	[Route("api/[controller]")]
	public class ContractorOrganizationController : Controller
	{
		private readonly IMapper _mapper;
		private readonly documeds_dbContext _db;

		public ContractorOrganizationController(documeds_dbContext db, IMapper mapper)
		{
			_db = db;
			_mapper = mapper;
		}
		/// <summary>
		/// Возвращает список организаций-контрагентов.
		/// </summary>
		/// <returns>Список организаций-контрагентов</returns>
		//[Authorize]
		[HttpGet]
		public async Task<IActionResult> Get()
		{
			var orgs = _db.ContractorOrganizations;
			var orgsToSend = await orgs.Select(p => _mapper.Map<ContractorOrganizationDto>(p)).ToListAsync();
			return Ok(Json(orgsToSend));
		}
	}
}
