﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Repositories.Models;

#nullable disable

namespace Repositories.Migrations
{
    [DbContext(typeof(GmachimSaraAndShaniContext))]
    [Migration("20231224103601_ChangeUserIdToLoarnerId")]
    partial class ChangeUserIdToLoarnerId
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Repositories.Models.Account", b =>
                {
                    b.Property<int>("AccountId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AccountId"));

                    b.Property<string>("AccountNumber")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("AccountOwnerName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("BankNumber")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("BranchNumber")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("ConfirmAccountFile")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("AccountId");

                    b.ToTable("Account");
                });

            modelBuilder.Entity("Repositories.Models.Card", b =>
                {
                    b.Property<int>("CardId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CardId"));

                    b.Property<string>("CVV")
                        .IsRequired()
                        .HasMaxLength(3)
                        .HasColumnType("nvarchar(3)");

                    b.Property<string>("CreditCardNumber")
                        .IsRequired()
                        .HasMaxLength(16)
                        .HasColumnType("nvarchar(16)");

                    b.Property<string>("OwnersName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Validity")
                        .HasColumnType("datetime2");

                    b.HasKey("CardId");

                    b.ToTable("Card");
                });

            modelBuilder.Entity("Repositories.Models.Deposit", b =>
                {
                    b.Property<int>("DepositId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DepositId"));

                    b.Property<DateTime>("DateToPull")
                        .HasColumnType("datetime2");

                    b.Property<int>("Sum")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("DepositId");

                    b.ToTable("Deposits");
                });

            modelBuilder.Entity("Repositories.Models.Guarantor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Check")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EmailAddress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IdentityNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("LoanId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Guarantors");
                });

            modelBuilder.Entity("Repositories.Models.LoanDetails", b =>
                {
                    b.Property<int>("LoanId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("LoanId"));

                    b.Property<DateTime>("DateToGetBack")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsAprovied")
                        .HasColumnType("bit");

                    b.Property<string>("LoanFile")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("LoanerId")
                        .HasColumnType("int");

                    b.Property<int>("Sum")
                        .HasColumnType("int");

                    b.HasKey("LoanId");

                    b.ToTable("LoanDetails");
                });

            modelBuilder.Entity("Repositories.Models.Users", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserId"));

                    b.Property<string>("UserAddress")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("UserEmail")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("UserIdentityNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("UserPassword")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<int>("UserPhone")
                        .HasColumnType("int");

                    b.HasKey("UserId");

                    b.HasIndex("UserIdentityNumber")
                        .IsUnique();

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Repositories.Models.UsersUnderWarning", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.ToTable("UsersUnderWarning");
                });
#pragma warning restore 612, 618
        }
    }
}
