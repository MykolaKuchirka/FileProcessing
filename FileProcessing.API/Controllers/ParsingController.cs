using FileProcessingApplication;
using FileProcessingDB.DataModel;
using FileProcessingDB.FileProcessingDTO;
using FileProcessingDB.IServices;
using Microsoft.AspNetCore.Authorization;
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
		private readonly IUserServices userServices;

		public ParsingController(IFileProcessingParsing fileProcessingParsing, IAdvertiserServices advertiserServices,
			IFileServices fileServices, IUserServices userServices)
		{
			this.fileProcessingParsing = fileProcessingParsing;
			this.advertiserServices = advertiserServices;
			this.fileServices = fileServices;
			this.userServices = userServices;
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

		[Authorize]
		[HttpPost("/AddAdvertiser")]
		public IActionResult AddAdvertiser([FromBody] Advertiser newAdvertiser)
		{
			var LastId = advertiserServices.AddAdvertiser(newAdvertiser);
			return Ok(LastId);
		}

		[Authorize]
		[HttpPost("/AddFile")]
		public IActionResult AddAFile([FromBody] File newFile)
		{
			var LastId = fileServices.AddFile(newFile);
			return Ok(LastId);
		}
		[HttpPost("/AddUser")]
		public IActionResult AddUser([FromBody] User newUser)
		{
			var LastId = userServices.AddUser(newUser);
			return Ok(LastId);
		}
		[HttpPost("/CheckUser")]
		public IActionResult CheckUser([FromBody] AuthorizationDTO authorization)
		{
			if(userServices.CheckUser(authorization))
				return Ok(5);
			return Ok(0);
		}
	}
}