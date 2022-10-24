using AutoMapper;
using DocumedsBackend.Controllers.TagTypeController;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DocumedsBackend.Controllers.PatientTagController
{
	[ApiController]
	[Route("api/[controller]")]
	public class TagTypeController : Controller
	{
		private readonly IMapper _mapper;
		private readonly documeds_dbContext _db;
		public TagTypeController(documeds_dbContext db, IMapper mapper)
		{
			_db = db;
			_mapper = mapper;
		}
		/// <summary>
		/// Возвращает список возмодных тэгов пациентов.
		/// </summary>
		/// <returns>Список возможных тэгов пациентов</returns>
		[Authorize]
		[HttpGet]
		public async Task<IActionResult> Get()
		{
			var tagTypes = await _db.TagTypes.Select(x => _mapper.Map<TagTypeDto>(x)).ToListAsync();
			return Ok(Json(tagTypes));
		}
	}
}
