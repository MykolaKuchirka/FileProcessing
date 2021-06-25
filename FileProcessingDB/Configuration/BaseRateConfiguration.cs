using FileProcessingDB.DataModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace FileProcessingDB.Configuration
{
	class BaseRateConfiguration : IEntityTypeConfiguration<BaseRate>
	{
		public void Configure(EntityTypeBuilder<BaseRate> builder)
		{
			builder.HasKey(x => x.Id);
			builder.Property(x => x.Id).UseIdentityColumn();
			builder.Property(x => x.Value).HasMaxLength(10);	
			builder.Property(x => x.TotalTerm).HasMaxLength(10);
			builder.HasOne(x => x.Advertiser).WithMany(x => x.Baserates).HasForeignKey(x=>x.IDAdv).OnDelete(DeleteBehavior.SetNull);
			builder.HasOne(x => x.Amount).WithMany(x => x.Baserates).HasForeignKey(x => x.IDAm).OnDelete(DeleteBehavior.SetNull);
			builder.HasOne(x => x.CreditScore).WithMany(x => x.Baserates).HasForeignKey(x => x.IDCr).OnDelete(DeleteBehavior.SetNull);
			builder.HasOne(x => x.Ltv).WithMany(x => x.Baserates).HasForeignKey(x => x.IDL).OnDelete(DeleteBehavior.SetNull);
			builder.HasOne(x => x.ProductType).WithMany(x => x.Baserates).HasForeignKey(x => x.IDPr).OnDelete(DeleteBehavior.SetNull);
			builder.HasOne(x => x.State).WithMany(x => x.Baserates).HasForeignKey(x => x.IDSt).OnDelete(DeleteBehavior.SetNull);
		}
	}
}