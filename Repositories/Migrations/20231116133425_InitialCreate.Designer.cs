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
    [Migration("20231116133425_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("GuarantorLoanDetails", b =>
                {
                    b.Property<int>("GuarantorsUserId")
                        .HasColumnType("int");

                    b.Property<int>("LoanId")
                        .HasColumnType("int");

                    b.HasKey("GuarantorsUserId", "LoanId");

                    b.HasIndex("LoanId");

                    b.ToTable("GuarantorLoanDetails");
                });

            modelBuilder.Entity("Repositories.Models.Account", b =>
                {
                    b.Property<int>("AccontId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AccontId"));

                    b.Property<string>("AccountsNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BankNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("BorrowerUserId")
                        .HasColumnType("int");

                    b.Property<string>("Branch")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ConfirmAcountFile")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("AccontId");

                    b.HasIndex("BorrowerUserId");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("Acounts");
                });

            modelBuilder.Entity("Repositories.Models.Deposit", b =>
                {
                    b.Property<int>("DepositId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DepositId"));

                    b.Property<DateTime>("DateToPull")
                        .HasColumnType("datetime2");

                    b.Property<int?>("DepositorUserId")
                        .HasColumnType("int");

                    b.Property<int>("Sum")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("DepositId");

                    b.HasIndex("DepositorUserId");

                    b.ToTable("Deposits");
                });

            modelBuilder.Entity("Repositories.Models.LoanDetails", b =>
                {
                    b.Property<int>("LoanId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("LoanId"));

                    b.Property<int?>("BorrowerUserId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateToGetBack")
                        .HasColumnType("datetime2");

                    b.Property<string>("LoanFile")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<int>("Sum")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("LoanId");

                    b.HasIndex("BorrowerUserId");

                    b.HasIndex("UserId");

                    b.ToTable("LoanDetails");
                });

            modelBuilder.Entity("Repositories.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserId"));

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

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

                    b.ToTable("User");

                    b.HasDiscriminator<string>("Discriminator").HasValue("User");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("Repositories.Models.Borrower", b =>
                {
                    b.HasBaseType("Repositories.Models.User");

                    b.HasDiscriminator().HasValue("Borrower");
                });

            modelBuilder.Entity("Repositories.Models.Depositor", b =>
                {
                    b.HasBaseType("Repositories.Models.User");

                    b.HasDiscriminator().HasValue("Depositor");
                });

            modelBuilder.Entity("Repositories.Models.Guarantor", b =>
                {
                    b.HasBaseType("Repositories.Models.User");

                    b.HasDiscriminator().HasValue("Guarantor");
                });

            modelBuilder.Entity("GuarantorLoanDetails", b =>
                {
                    b.HasOne("Repositories.Models.Guarantor", null)
                        .WithMany()
                        .HasForeignKey("GuarantorsUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Repositories.Models.LoanDetails", null)
                        .WithMany()
                        .HasForeignKey("LoanId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Repositories.Models.Account", b =>
                {
                    b.HasOne("Repositories.Models.Borrower", null)
                        .WithMany("Acounts")
                        .HasForeignKey("BorrowerUserId");

                    b.HasOne("Repositories.Models.Guarantor", null)
                        .WithOne("Account")
                        .HasForeignKey("Repositories.Models.Account", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Repositories.Models.Deposit", b =>
                {
                    b.HasOne("Repositories.Models.Depositor", null)
                        .WithMany("Deposits")
                        .HasForeignKey("DepositorUserId");
                });

            modelBuilder.Entity("Repositories.Models.LoanDetails", b =>
                {
                    b.HasOne("Repositories.Models.Borrower", null)
                        .WithMany("Loans")
                        .HasForeignKey("BorrowerUserId");

                    b.HasOne("Repositories.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Repositories.Models.Borrower", b =>
                {
                    b.Navigation("Acounts");

                    b.Navigation("Loans");
                });

            modelBuilder.Entity("Repositories.Models.Depositor", b =>
                {
                    b.Navigation("Deposits");
                });

            modelBuilder.Entity("Repositories.Models.Guarantor", b =>
                {
                    b.Navigation("Account")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}