﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TestMVCNetCore.Context;

namespace TestMVCNetCore.Migrations
{
    [DbContext(typeof(TestMVCNetCoreContext))]
    [Migration("20220723223507_table Option")]
    partial class tableOption
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("TestMVCNetCore.Models.Header", b =>
                {
                    b.Property<int>("Header_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Header_Comment")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Header_Id");

                    b.ToTable("Header");
                });

            modelBuilder.Entity("TestMVCNetCore.Models.Header_Detail", b =>
                {
                    b.Property<int>("Header_Detail_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("Header_Detail_Date")
                        .HasColumnType("datetime2");

                    b.Property<float>("Header_Detail_Estimated")
                        .HasColumnType("real");

                    b.Property<string>("Header_Detail_Number")
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("Header_Detail_Quantity")
                        .HasColumnType("real");

                    b.Property<int>("Header_Id")
                        .HasColumnType("int");

                    b.Property<int?>("Header_Id1")
                        .HasColumnType("int");

                    b.Property<int>("TypOption_Id")
                        .HasColumnType("int");

                    b.HasKey("Header_Detail_Id");

                    b.HasIndex("Header_Id1");

                    b.ToTable("Header_Detail");
                });

            modelBuilder.Entity("TestMVCNetCore.Models.TypeOption", b =>
                {
                    b.Property<int>("TypOption_Id")
                        .HasColumnType("int");

                    b.Property<string>("TypOpt_Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TypOption_Id");

                    b.ToTable("TypeOption");
                });

            modelBuilder.Entity("TestMVCNetCore.Models.Header_Detail", b =>
                {
                    b.HasOne("TestMVCNetCore.Models.Header", null)
                        .WithMany("Header_Detail")
                        .HasForeignKey("Header_Id1");
                });

            modelBuilder.Entity("TestMVCNetCore.Models.Header", b =>
                {
                    b.Navigation("Header_Detail");
                });
#pragma warning restore 612, 618
        }
    }
}