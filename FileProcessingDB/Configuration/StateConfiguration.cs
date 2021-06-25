using FileProcessingDB.DataModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace FileProcessingDB.Configuration
{
	class StateConfiguration : IEntityTypeConfiguration<State>
	{
		public void Configure(EntityTypeBuilder<State> builder)
		{
			builder.HasKey(x => x.Id);
			builder.Property(x => x.Id).UseIdentityColumn();
			builder.Property(x => x.Name).HasColumnType("nvarchar(255)");
		}
	}
}