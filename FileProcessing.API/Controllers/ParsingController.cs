using FileProcessingApplication;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FileProcessing.API.Controllers
{
	[ApiController]
	[Route("api/controller")]
	public class ParsingController : Controller
	{
		private readonly IFileProcessingParsing fileProcessingParsing;
		public ParsingController(IFileProcessingParsing fileProcessingParsing)
		{
			this.fileProcessingParsing = fileProcessingParsing;
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
	}
}
