using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FileProcessingDB.DataModel;
using FileProcessingApplication;
namespace FileProcessing.API
{
	public class Program
	{
		public static void Main(string[] args)
		{			
			FileProcessingParsing.OpenEXEL();
			CreateHostBuilder(args).Build().Run();						
		}

		public static IHostBuilder CreateHostBuilder(string[] args) =>
			Host.CreateDefaultBuilder(args)
				.ConfigureWebHostDefaults(webBuilder =>
				{
					webBuilder.UseStartup<Startup>();
				});
	}
}
