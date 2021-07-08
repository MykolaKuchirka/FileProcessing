using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using FileProcessingDB.DataModel;
using FileProcessingDB.Services;
using FileProcessingDB;
using FileProcessingDB.IServices;
using FileProcessingApplication;

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
			services.AddControllersWithViews();

			services.AddDbContext<FileProcessingDBContext>();

			services.AddTransient<IFileProcessingDBContext, FileProcessingDBContext>()
				.AddTransient<IAdvertiserServices, AdvertiserServices>()
				.AddTransient<IAmountServices,AmountServices>()
				.AddTransient<IBaseRateServices,BaseRateServices>()
				.AddTransient<ICreditScoreServices, CreditScoreServices>()
				.AddTransient<IFileServices, FileServices>()
				.AddTransient<ILtvServices, LtvServices>()
				.AddTransient<IProductTypeServices, ProductTypeServices>()
				.AddTransient<IStateServices, StateServices>()
				.AddTransient<IFileProcessingParsing, FileProcessingParsing>();
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env, 
			IAdvertiserServices advertiserServices, IAmountServices amountServices,
			IBaseRateServices baseRateServices, ICreditScoreServices creditScoreServices, 
			IFileServices fileServices, ILtvServices ltvServices, IProductTypeServices productTypeServices, 
			IStateServices stateServices, IFileProcessingParsing fileProcessingParsing)
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