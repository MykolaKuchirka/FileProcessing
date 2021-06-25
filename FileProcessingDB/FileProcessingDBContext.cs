using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using FileProcessingDB.DataModel;

namespace FileProcessingDB.DataModel
{
	public class FileProcessingDBContext : DbContext
	{
		public FileProcessingDBContext() 
		{
			Database.EnsureCreated();
		}
		
		public DbSet<BaseRate> BaseRates { get; set; }
		public DbSet<Advertiser> Advertisers { get; set; }
		public DbSet<Amount> Amounts { get; set; }
		public DbSet<CreditScore> CreditScores { get; set; }
		public DbSet<ltv> ltvs { get; set; }
		public DbSet<ProductType> ProductTypes { get; set; }
		public DbSet<State> States { get; set; }

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer(@"Server=DESKTOP-0SG1T74;Database=FileProcessing;Trusted_Connection=True;");
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<BaseRate>()
				.HasOne(p => p.Advertiser)
				.WithMany(b => b.baserates)
				.HasForeignKey(p => p.IDAdv);
			modelBuilder.Entity<BaseRate>()
				.HasOne(p => p.Amount)
				.WithMany(b => b.baserates)
				.HasForeignKey(p => p.IDAm);
			modelBuilder.Entity<BaseRate>()
				.HasOne(p => p.CreditScore)
				.WithMany(b => b.baserates)
				.HasForeignKey(p => p.IDCr);
			modelBuilder.Entity<BaseRate>()
				.HasOne(p => p.ltv)
				.WithMany(b => b.baserates)
				.HasForeignKey(p => p.IDl);
			modelBuilder.Entity<BaseRate>()
				.HasOne(p => p.ProductType)
				.WithMany(b => b.baserates)
				.HasForeignKey(p => p.IDPr);
			modelBuilder.Entity<BaseRate>()
				.HasOne(p => p.State)
				.WithMany(b => b.baserates)
				.HasForeignKey(p => p.IDSt);
		}
	}
}
