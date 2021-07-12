using FileProcessingDB.DataModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;


namespace FileProcessingDB.Configuration
{
	class UserConfiguration : IEntityTypeConfiguration<User>
	{
		public void Configure(EntityTypeBuilder<User> builder)
		{
			builder.HasKey(x => x.Id);
			builder.Property(x => x.Id).UseIdentityColumn();
			builder.Property(x => x.Name).HasColumnType("nvarchar(50)").IsRequired();
			builder.Property(x => x.Email).HasColumnType("nvarchar(50)").IsRequired();
			builder.Property(x => x.Password).HasColumnType("nvarchar(50)").IsRequired();
		}
	}
}