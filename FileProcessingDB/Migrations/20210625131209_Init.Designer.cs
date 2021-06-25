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
    [Migration("20210625131209_Init")]
    partial class Init
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
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Advertisers");
                });

            modelBuilder.Entity("FileProcessingDB.DataModel.Amount", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<float>("max")
                        .HasColumnType("real");

                    b.Property<float>("min")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.ToTable("Amounts");
                });

            modelBuilder.Entity("FileProcessingDB.DataModel.BaseRate", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("IDAdv")
                        .HasColumnType("int");

                    b.Property<int>("IDAm")
                        .HasColumnType("int");

                    b.Property<int>("IDCr")
                        .HasColumnType("int");

                    b.Property<int>("IDPr")
                        .HasColumnType("int");

                    b.Property<int>("IDSt")
                        .HasColumnType("int");

                    b.Property<int>("IDl")
                        .HasColumnType("int");

                    b.Property<DateTime>("LastModified")
                        .HasColumnType("datetime2");

                    b.Property<int>("TotalTerm")
                        .HasColumnType("int");

                    b.Property<float>("Value")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.HasIndex("IDAdv");

                    b.HasIndex("IDAm");

                    b.HasIndex("IDCr");

                    b.HasIndex("IDPr");

                    b.HasIndex("IDSt");

                    b.HasIndex("IDl");

                    b.ToTable("BaseRates");
                });

            modelBuilder.Entity("FileProcessingDB.DataModel.CreditScore", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("max")
                        .HasColumnType("int");

                    b.Property<int>("min")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("CreditScores");
                });

            modelBuilder.Entity("FileProcessingDB.DataModel.ProductType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ProductTypes");
                });

            modelBuilder.Entity("FileProcessingDB.DataModel.State", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("States");
                });

            modelBuilder.Entity("FileProcessingDB.DataModel.ltv", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<float>("max")
                        .HasColumnType("real");

                    b.Property<float>("min")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.ToTable("ltvs");
                });

            modelBuilder.Entity("FileProcessingDB.DataModel.BaseRate", b =>
                {
                    b.HasOne("FileProcessingDB.DataModel.Advertiser", "Advertiser")
                        .WithMany("baserates")
                        .HasForeignKey("IDAdv")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FileProcessingDB.DataModel.Amount", "Amount")
                        .WithMany("baserates")
                        .HasForeignKey("IDAm")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FileProcessingDB.DataModel.CreditScore", "CreditScore")
                        .WithMany("baserates")
                        .HasForeignKey("IDCr")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FileProcessingDB.DataModel.ProductType", "ProductType")
                        .WithMany("baserates")
                        .HasForeignKey("IDPr")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FileProcessingDB.DataModel.State", "State")
                        .WithMany("baserates")
                        .HasForeignKey("IDSt")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FileProcessingDB.DataModel.ltv", "ltv")
                        .WithMany("baserates")
                        .HasForeignKey("IDl")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Advertiser");

                    b.Navigation("Amount");

                    b.Navigation("CreditScore");

                    b.Navigation("ltv");

                    b.Navigation("ProductType");

                    b.Navigation("State");
                });

            modelBuilder.Entity("FileProcessingDB.DataModel.Advertiser", b =>
                {
                    b.Navigation("baserates");
                });

            modelBuilder.Entity("FileProcessingDB.DataModel.Amount", b =>
                {
                    b.Navigation("baserates");
                });

            modelBuilder.Entity("FileProcessingDB.DataModel.CreditScore", b =>
                {
                    b.Navigation("baserates");
                });

            modelBuilder.Entity("FileProcessingDB.DataModel.ProductType", b =>
                {
                    b.Navigation("baserates");
                });

            modelBuilder.Entity("FileProcessingDB.DataModel.State", b =>
                {
                    b.Navigation("baserates");
                });

            modelBuilder.Entity("FileProcessingDB.DataModel.ltv", b =>
                {
                    b.Navigation("baserates");
                });
#pragma warning restore 612, 618
        }
    }
}
