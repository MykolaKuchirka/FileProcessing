using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using FileProcessingDB.DataModel;
using FileProcessingDB.Services;
using FileProcessingDB;
using FileProcessingDB.IServices;

namespace FileProcessing.API
{
	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			FileProcessingDBContext DBCont = new FileProcessingDBContext();
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{
			//services.AddDbContext<FileProcessingDBContext>(options =>
				 //options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

			services.AddControllersWithViews();
			services.AddDbContext<FileProcessingDBContext>();
			services.AddTransient<IFileProcessingDBContext, FileProcessingDBContext>();
			services.AddTransient<IAdvertiserServices, AdvertiserServices>();
			services.AddTransient<IAmountServices,AmountServices>();
			services.AddTransient<IBaseRateServices,BaseRateServices>();
			services.AddTransient<ICreditScoreServices, CreditScoreServices>();
			services.AddTransient<ILtvServices, LtvServices>();
			services.AddTransient<IProductTypeServices, ProductTypeServices>();
			services.AddTransient<IStateServices, StateServices>();
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}

			app.UseHttpsRedirection();

			app.UseRouting();

			app.UseAuthorization();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllers();
			});
		}
	}
}
