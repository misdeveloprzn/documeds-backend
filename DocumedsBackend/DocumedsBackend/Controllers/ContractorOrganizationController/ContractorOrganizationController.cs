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
			var orgs = _db.ContractorOrganizations.Where(x => x.IdOrg == 1 && x.DateEnd == null);
			var orgsToSend = await orgs.Select(p => _mapper.Map<ContractorOrganizationDto>(p)).ToListAsync();
			return Ok(Json(orgsToSend));
		}
		/// <summary>
		/// Создает новую запись организации-контрагента.
		/// </summary>
		/// <returns>Информацию по созданной организации-контрагента</returns>
		//[Authorize]
		[HttpPost]
		public async Task<IActionResult> Post(ContractorOrganizationDto dto)
		{
			try
			{
				var contractor = _mapper.Map<ContractorOrganization>(dto);
				contractor.IdOrg = 1;
				_db.ContractorOrganizations.Add(contractor);
				await _db.SaveChangesAsync();
				var contractorToSend = _mapper.Map<ContractorOrganizationDto>(await _db.ContractorOrganizations
					.SingleOrDefaultAsync(x => x.Id == contractor.Id));
				return Ok(Json(contractorToSend));
			}
			catch (Exception e)
			{
				ModelState.AddModelError(nameof(e.Message), "Что-то пошло не так!");
				return BadRequest(ModelState);
			}
		}
		/// <summary>
		/// Редактирует существующую запись организации-контрагента.
		/// </summary>
		//[Authorize]
		[HttpPut]
		public async Task<IActionResult> Put(ContractorOrganizationDto dto)
		{
			var contractor = await _db.ContractorOrganizations.FindAsync(dto.Id);
			_mapper.Map(dto, contractor);
			await _db.SaveChangesAsync();
			return Ok();
		}
		/// <summary>
		/// Удаляет существующую запись организации-контрагента.
		/// </summary>
		//[Authorize]
		[HttpDelete("{id}")]
		public async Task<IActionResult> Delete(int id)
		{
			var contractor = await _db.ContractorOrganizations.FindAsync(id);
			if (contractor != null)
				contractor.DateEnd = DateTime.Today;
			await _db.SaveChangesAsync();
			return Ok();
		}
	}
}
