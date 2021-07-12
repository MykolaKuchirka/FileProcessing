using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using FileProcessingDB.DataModel;

namespace FileProcessingDB.Configuration
{
	class FileConfiguration : IEntityTypeConfiguration<File>
	{
		public void Configure(EntityTypeBuilder<File> builder)
		{
			builder.HasKey(x => x.Id);
			builder.Property(x => x.Id).UseIdentityColumn();
			builder.Property(x => x.FilePath).HasColumnType("nvarchar(255)");			
			builder.HasOne(x => x.Advertiser).WithMany(x => x.Files).HasForeignKey(x => x.IDAdv);
		}
	}
}
