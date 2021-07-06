using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using FileProcessingDB.DataModel;
using FileProcessingDB.Configuration;


namespace FileProcessingDB.DataModel
{	 
	public class FileProcessingDBContext : DbContext, IFileProcessingDBContext
	{
		public FileProcessingDBContext() 
		{			
		}
		
		public DbSet<BaseRate> BaseRates { get; set; }
		public DbSet<Advertiser> Advertisers { get; set; }
		public DbSet<Amount> Amounts { get; set; }
		public DbSet<CreditScore> CreditScores { get; set; }
		public DbSet<Ltv> ltvs { get; set; }
		public DbSet<ProductType> ProductTypes { get; set; }
		public DbSet<State> States { get; set; }

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseLazyLoadingProxies().UseSqlServer(@"Server=DESKTOP-0SG1T74;Database=FileProcessing;Trusted_Connection=True;");
		}
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.ApplyConfiguration(new AdvertiserConfiguration());
			modelBuilder.ApplyConfiguration(new AmountConfiguration());
			modelBuilder.ApplyConfiguration(new BaseRateConfiguration());
			modelBuilder.ApplyConfiguration(new CreditScoreConfiguration());
			modelBuilder.ApplyConfiguration(new LtvConfiguration());
			modelBuilder.ApplyConfiguration(new ProductTypeConfiguration());
			modelBuilder.ApplyConfiguration(new StateConfiguration());
		}

	}
}
