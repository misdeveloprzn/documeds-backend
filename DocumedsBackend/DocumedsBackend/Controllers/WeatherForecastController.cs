using DocumedsBackend;
using Microsoft.AspNetCore.Mvc;

namespace DocumedsBackend.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class WeatherForecastController : ControllerBase
	{
		private static readonly string[] Summaries = new[]
		{
		"Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
	    };

		private documeds_dbContext db;

		private readonly ILogger<WeatherForecastController> _logger;

		public WeatherForecastController(ILogger<WeatherForecastController> logger ,documeds_dbContext context)
		{
			_logger = logger;
			db = context;
		}
		/// <summary>
		/// Возвращает расширенную информацию о записи на прием.
		/// </summary>
		/// <returns>Расширенная информация о записи на прием (AppointmentInfoDto)</returns>
		[HttpGet(Name = "GetWeatherForecast")]
		public IEnumerable<WeatherForecast> Get()
		{

	//		for (int i = 1; i <= 500; i++)
	//		{
	//			var patient = new Patient();
	//			patient.LastName = "фамилия" + i.ToString();
	//			patient.FirstName = "имя" + i.ToString();
	//			patient.Patronymic = "отчество" + i.ToString();
	//			var rand = new Random();
	//			patient.BirthDate = new DateTime(rand.Next(1950, 2003), rand.Next(1, 12), rand.Next(1, 28));
	//			patient.Phone = "+" + rand.Next(0000000, 999999).ToString().PadLeft(6, '0') + rand.Next(000000, 99999).ToString().PadLeft(5, '0');
	//			patient.Email = "email" + i.ToString() + "@mail.test";
	//			patient.Gender = rand.Next(0, 1);
	//			patient.Snils = "СНИЛС" + i.ToString();
	//			patient.Note = "комментарий" + i.ToString();
	//			patient.IdOrg = 1;
	//			patient.DateStart = DateTime.Today;

	//	        db.Patients.Add(patient);
	//			db.SaveChanges();

	//			var factAddr = new PatientAddress();
	//			factAddr.IdPatient = patient.Id;
	//			factAddr.IdAddressType = 1;
	//			factAddr.Address = "Адрес проживания" + i.ToString();
	//			db.PatientAddresses.Add(factAddr);
	//			var regAddr = new PatientAddress();
	//			regAddr.IdPatient = patient.Id;
	//			regAddr.IdAddressType = 2;
	//			regAddr.Address = "Адрес регистрации" + i.ToString();
	//			db.PatientAddresses.Add(regAddr);

	//			var patDoc = new PatientDocument();
	//			patDoc.IdPatient = patient.Id;
	//			patDoc.IdDocumentType = 1;
	//			patDoc.Series = rand.Next(1000, 9999).ToString();
	//			patDoc.Number = rand.Next(100000, 999999).ToString();
	//			patDoc.Issuer = "УФМС" + i.ToString();
	//			patDoc.IssuerCode = "К" + i.ToString();
	//			patDoc.DateFrom = new DateTime(rand.Next(2000, 2021), rand.Next(1, 12), rand.Next(1, 28));
	//			db.PatientDocuments.Add(patDoc);

	//			var patTag1 = new PatientTag();
	//			patTag1.IdPatient = patient.Id;
	//			patTag1.IdTag = rand.Next(1, 5);
	//			db.PatientTags.Add(patTag1);
	//			var patTag2 = new PatientTag();
	//			patTag2.IdPatient = patient.Id;
	//			patTag2.IdTag = rand.Next(1, 5);
	//			db.PatientTags.Add(patTag2);

	//			db.SaveChanges();
	//}


			return Enumerable.Range(1, 5).Select(index => new WeatherForecast
			{
				Date = DateTime.Now.AddDays(index),
				TemperatureC = Random.Shared.Next(-20, 55),
				Summary = Summaries[Random.Shared.Next(Summaries.Length)]
			})
			.ToArray();
		}
	}
}