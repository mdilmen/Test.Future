﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Test.Future.Data;

#nullable disable

namespace Test.Future.Data.Migrations
{
    [DbContext(typeof(FutureContext))]
    partial class FutureContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Test.Future.Data.Entities.HS_CostOfFuture", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("CardLastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CardName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Comment")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("HS_ExpenseId")
                        .HasColumnType("int");

                    b.Property<int>("InstallmentCount")
                        .HasColumnType("int");

                    b.Property<int>("PaymentMethodType")
                        .HasColumnType("int");

                    b.Property<DateTime?>("PolicyBeginDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("PolicyEndDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("PolicyNumber")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("HS_ExpenseId");

                    b.ToTable("Futures");
                });

            modelBuilder.Entity("Test.Future.Data.Entities.HS_Expense", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Order")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Expenses");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Sigorta",
                            Order = 1
                        },
                        new
                        {
                            Id = 2,
                            Name = "Kasko",
                            Order = 2
                        },
                        new
                        {
                            Id = 3,
                            Name = "Kira",
                            Order = 3
                        });
                });

            modelBuilder.Entity("Test.Future.Data.Entities.HS_CostOfFuture", b =>
                {
                    b.HasOne("Test.Future.Data.Entities.HS_Expense", "HS_Expense")
                        .WithMany()
                        .HasForeignKey("HS_ExpenseId");

                    b.Navigation("HS_Expense");
                });
#pragma warning restore 612, 618
        }
    }
}
