using FileProcessingDB.DataModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace FileProcessingDB
{
	public interface IFileProcessingDBContext
	{
		public DbSet<BaseRate> BaseRates { get; }
		public DbSet<Advertiser> Advertisers { get; }
		public DbSet<Amount> Amounts { get; }
		public DbSet<CreditScore> CreditScores { get; }
		public DbSet<Ltv> ltvs { get; }
		public DbSet<ProductType> ProductTypes { get; }
		public DbSet<State> States { get; }
	}
}
