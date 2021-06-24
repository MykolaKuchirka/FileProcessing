using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Text;

namespace FileProcessingDB.DataModel
{
	class FileProcessingDBContext : DbContext
	{
		public FileProcessingDBContext() : base("name = FileProcessingDBContext") { }
		public DbSet<BaseRate> BaseRates { get; set; }
		public DbSet<Advertiser> Advertisers { get; set; }
		public DbSet<Amount> Amounts { get; set; }
		public DbSet<CreditScore> CreditScores { get; set; }
		public DbSet<ltv> ltvs { get; set; }
		public DbSet<ProductType> ProductTypes { get; set; }
		public DbSet<State> States { get; set; }
	}
}
