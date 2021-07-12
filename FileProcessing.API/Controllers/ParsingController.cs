using FileProcessingApplication;
using FileProcessingDB.DataModel;
using FileProcessingDB.IServices;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace FileProcessing.API.Controllers
{
	[ApiController]
	[Route("api/controller")]
	public class ParsingController : Controller
	{
		private readonly IFileProcessingParsing fileProcessingParsing;
		private readonly IAdvertiserServices advertiserServices;
		private readonly IFileServices fileServices;

		public ParsingController(IFileProcessingParsing fileProcessingParsing, IAdvertiserServices advertiserServices,
			IFileServices fileServices)
		{
			this.fileProcessingParsing = fileProcessingParsing;
			this.advertiserServices = advertiserServices;
			this.fileServices = fileServices;
		}
		
		[Route("/parse")]
		public IActionResult Index()
		{
			fileProcessingParsing.OpenEXCEL();
			return Ok();			
		}

		[Route("/GetAll")]
		public IActionResult GetAll()
		{			
			return View(fileProcessingParsing.Getall());
		}

		[HttpPost("/AddAdvertiser")]
		public IActionResult AddAdvertiser([FromBody] Advertiser newAdvertiser)
		{
			var LastId = advertiserServices.AddAdvertiser(newAdvertiser);
			return Ok(LastId);
		}

		[HttpPost("/AddFile")]
		public IActionResult AddAFile([FromBody] File newFile)
		{
			var LastId = fileServices.AddFile(newFile);
			return Ok(LastId);
		}
	}
}