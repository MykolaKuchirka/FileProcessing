using FileProcessingDB.DataModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


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
			builder.HasOne(x => x.Advertiser).WithMany(x => x.Baserates).HasForeignKey(x=>x.IDAdv);
			builder.HasOne(x => x.Amount).WithMany(x => x.Baserates).HasForeignKey(x => x.IDAm);
			builder.HasOne(x => x.CreditScore).WithMany(x => x.Baserates).HasForeignKey(x => x.IDCr);
			builder.HasOne(x => x.Ltv).WithMany(x => x.Baserates).HasForeignKey(x => x.IDL);
			builder.HasOne(x => x.ProductType).WithMany(x => x.Baserates).HasForeignKey(x => x.IDPr);
			builder.HasOne(x => x.State).WithMany(x => x.Baserates).HasForeignKey(x => x.IDSt);
		}
	}
}