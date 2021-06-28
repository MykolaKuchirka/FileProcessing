﻿using FileProcessingDB.DataModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace FileProcessingDB.Configuration
{
	class LtvConfiguration : IEntityTypeConfiguration<Ltv>
	{
		public void Configure(EntityTypeBuilder<Ltv> builder)
		{
			builder.HasKey(x => x.Id);
			builder.Property(x => x.Id).UseIdentityColumn();
			builder.Property(x => x.Min).HasMaxLength(10);
			builder.Property(x => x.Max).HasMaxLength(10);
		}
	}
}