﻿using FileProcessingDB.DataModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;


namespace FileProcessingDB.Configuration
{
	class AdvertiserConfiguration : IEntityTypeConfiguration<Advertiser>
	{
		public void Configure(EntityTypeBuilder<Advertiser> builder)
		{
			builder.HasKey(x => x.Id);
			builder.Property(x => x.Id).UseIdentityColumn();
			builder.Property(x => x.Name).HasColumnType("nvarchar(100)");
			
		}
	}
}