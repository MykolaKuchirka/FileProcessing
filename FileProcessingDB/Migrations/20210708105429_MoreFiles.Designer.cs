﻿// <auto-generated />
using System;
using FileProcessingDB.DataModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace FileProcessingDB.Migrations
{
    [DbContext(typeof(FileProcessingDBContext))]
    [Migration("20210708105429_MoreFiles")]
    partial class MoreFiles
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.7")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("FileProcessingDB.DataModel.Advertiser", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:IdentityIncrement", 1)
                        .HasAnnotation("SqlServer:IdentitySeed", 1)
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Advertisers");
                });

            modelBuilder.Entity("FileProcessingDB.DataModel.Amount", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:IdentityIncrement", 1)
                        .HasAnnotation("SqlServer:IdentitySeed", 1)
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<float>("Max")
                        .HasMaxLength(10)
                        .HasColumnType("real");

                    b.Property<float>("Min")
                        .HasMaxLength(10)
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.ToTable("Amounts");
                });

            modelBuilder.Entity("FileProcessingDB.DataModel.BaseRate", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:IdentityIncrement", 1)
                        .HasAnnotation("SqlServer:IdentitySeed", 1)
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("IDAdv")
                        .HasColumnType("int");

                    b.Property<int>("IDAm")
                        .HasColumnType("int");

                    b.Property<int>("IDCr")
                        .HasColumnType("int");

                    b.Property<int>("IDL")
                        .HasColumnType("int");

                    b.Property<int>("IDPr")
                        .HasColumnType("int");

                    b.Property<int>("IDSt")
                        .HasColumnType("int");

                    b.Property<DateTime>("LastModified")
                        .HasColumnType("datetime2");

                    b.Property<int>("TotalTerm")
                        .HasMaxLength(10)
                        .HasColumnType("int");

                    b.Property<float>("Value")
                        .HasMaxLength(10)
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.HasIndex("IDAdv");

                    b.HasIndex("IDAm");

                    b.HasIndex("IDCr");

                    b.HasIndex("IDL");

                    b.HasIndex("IDPr");

                    b.HasIndex("IDSt");

                    b.ToTable("BaseRates");
                });

            modelBuilder.Entity("FileProcessingDB.DataModel.CreditScore", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:IdentityIncrement", 1)
                        .HasAnnotation("SqlServer:IdentitySeed", 1)
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Max")
                        .HasMaxLength(10)
                        .HasColumnType("int");

                    b.Property<int>("Min")
                        .HasMaxLength(10)
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("CreditScores");
                });

            modelBuilder.Entity("FileProcessingDB.DataModel.File", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:IdentityIncrement", 1)
                        .HasAnnotation("SqlServer:IdentitySeed", 1)
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FilePath")
                        .HasColumnType("nvarchar(255)");

                    b.Property<int>("IDAdv")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IDAdv");

                    b.ToTable("Files");
                });

            modelBuilder.Entity("FileProcessingDB.DataModel.Ltv", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:IdentityIncrement", 1)
                        .HasAnnotation("SqlServer:IdentitySeed", 1)
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<float>("Max")
                        .HasMaxLength(10)
                        .HasColumnType("real");

                    b.Property<float>("Min")
                        .HasMaxLength(10)
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.ToTable("ltvs");
                });

            modelBuilder.Entity("FileProcessingDB.DataModel.ProductType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:IdentityIncrement", 1)
                        .HasAnnotation("SqlServer:IdentitySeed", 1)
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("ProductTypes");
                });

            modelBuilder.Entity("FileProcessingDB.DataModel.State", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:IdentityIncrement", 1)
                        .HasAnnotation("SqlServer:IdentitySeed", 1)
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("States");
                });

            modelBuilder.Entity("FileProcessingDB.DataModel.BaseRate", b =>
                {
                    b.HasOne("FileProcessingDB.DataModel.Advertiser", "Advertiser")
                        .WithMany("Baserates")
                        .HasForeignKey("IDAdv")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FileProcessingDB.DataModel.Amount", "Amount")
                        .WithMany("Baserates")
                        .HasForeignKey("IDAm")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FileProcessingDB.DataModel.CreditScore", "CreditScore")
                        .WithMany("Baserates")
                        .HasForeignKey("IDCr")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FileProcessingDB.DataModel.Ltv", "Ltv")
                        .WithMany("Baserates")
                        .HasForeignKey("IDL")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FileProcessingDB.DataModel.ProductType", "ProductType")
                        .WithMany("Baserates")
                        .HasForeignKey("IDPr")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FileProcessingDB.DataModel.State", "State")
                        .WithMany("Baserates")
                        .HasForeignKey("IDSt")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Advertiser");

                    b.Navigation("Amount");

                    b.Navigation("CreditScore");

                    b.Navigation("Ltv");

                    b.Navigation("ProductType");

                    b.Navigation("State");
                });

            modelBuilder.Entity("FileProcessingDB.DataModel.File", b =>
                {
                    b.HasOne("FileProcessingDB.DataModel.Advertiser", "Advertiser")
                        .WithMany("Files")
                        .HasForeignKey("IDAdv")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Advertiser");
                });

            modelBuilder.Entity("FileProcessingDB.DataModel.Advertiser", b =>
                {
                    b.Navigation("Baserates");

                    b.Navigation("Files");
                });

            modelBuilder.Entity("FileProcessingDB.DataModel.Amount", b =>
                {
                    b.Navigation("Baserates");
                });

            modelBuilder.Entity("FileProcessingDB.DataModel.CreditScore", b =>
                {
                    b.Navigation("Baserates");
                });

            modelBuilder.Entity("FileProcessingDB.DataModel.Ltv", b =>
                {
                    b.Navigation("Baserates");
                });

            modelBuilder.Entity("FileProcessingDB.DataModel.ProductType", b =>
                {
                    b.Navigation("Baserates");
                });

            modelBuilder.Entity("FileProcessingDB.DataModel.State", b =>
                {
                    b.Navigation("Baserates");
                });
#pragma warning restore 612, 618
        }
    }
}
