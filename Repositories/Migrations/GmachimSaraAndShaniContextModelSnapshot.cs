﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Repositories.Models;

#nullable disable

namespace Repositories.Migrations;

[DbContext(typeof(GmachimSaraAndShaniContext))]
partial class GmachimSaraAndShaniContextModelSnapshot : ModelSnapshot
{
    protected override void BuildModel(ModelBuilder modelBuilder)
    {
#pragma warning disable 612, 618
        modelBuilder
            .HasAnnotation("ProductVersion", "7.0.13")
            .HasAnnotation("Relational:MaxIdentifierLength", 128);

        SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

        modelBuilder.Entity("AcountsForLoan", b =>
            {
                b.Property<int>("LoanId")
                    .HasColumnType("int")
                    .HasColumnName("LoanID");

                b.Property<int>("AcountsNumber")
                    .HasColumnType("int");

                b.HasKey("LoanId", "AcountsNumber");

                b.HasIndex("AcountsNumber");

                b.ToTable("AcountsForLoans", (string)null);
            });

        modelBuilder.Entity("BorrowerLoanDetails", b =>
            {
                b.Property<int>("BorrowersUserId")
                    .HasColumnType("int");

                b.Property<int>("LoansLoanId")
                    .HasColumnType("int");

                b.HasKey("BorrowersUserId", "LoansLoanId");

                b.HasIndex("LoansLoanId");

                b.ToTable("BorrowerLoanDetails");
            });

        modelBuilder.Entity("Repositories.Models.Acount", b =>
            {
                b.Property<int>("AccontId")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("int");

                SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AccontId"));

                b.Property<int>("AcountsNumber")
                    .HasColumnType("int");

                b.Property<int>("BankNumber")
                    .HasColumnType("int");

                b.Property<int>("BorrowerId")
                    .HasColumnType("int");

                b.Property<int>("Branch")
                    .HasColumnType("int");

                b.Property<string>("ConfirmAcountFile")
                    .IsRequired()
                    .HasColumnType("nvarchar(max)");

                b.HasKey("AccontId");

                b.HasIndex("BorrowerId");

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

                b.Property<int>("DepositorsId")
                    .HasColumnType("int");

                b.Property<int>("Sum")
                    .HasColumnType("int");

                b.HasKey("DepositId");

                b.HasIndex("DepositorsId");

                b.ToTable("Deposits");
            });

        modelBuilder.Entity("Repositories.Models.LoanDetails", b =>
            {
                b.Property<int>("LoanId")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("int");

                SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("LoanId"));

                b.Property<int>("BorrowerNumber")
                    .HasColumnType("int");

                b.Property<DateTime>("DateToGetBack")
                    .HasColumnType("datetime2");

                b.Property<string>("LoanFile")
                    .IsRequired()
                    .HasColumnType("nvarchar(max)");

                b.Property<int>("Sum")
                    .HasColumnType("int");

                b.HasKey("LoanId");

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
                    .HasColumnType("nvarchar(max)");

                b.Property<string>("UserEmail")
                    .IsRequired()
                    .HasColumnType("nvarchar(max)");

                b.Property<int>("UserIdentityNumber")
                    .HasColumnType("int");

                b.Property<string>("UserName")
                    .IsRequired()
                    .HasColumnType("nvarchar(max)");

                b.Property<string>("UserPassword")
                    .IsRequired()
                    .HasColumnType("nvarchar(max)");

                b.Property<int>("UserPhone")
                    .HasColumnType("int");

                b.HasKey("UserId");

                b.ToTable("User");

                b.HasDiscriminator<string>("Discriminator").HasValue("User");

                b.UseTphMappingStrategy();
            });

        modelBuilder.Entity("Repositories.Models.Borrower", b =>
            {
                b.HasBaseType("Repositories.Models.User");

                b.Property<string>("Copy")
                    .IsRequired()
                    .HasColumnType("nvarchar(max)");

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

                b.Property<int>("LoanId")
                    .HasColumnType("int");

                b.HasIndex("LoanId");

                b.HasDiscriminator().HasValue("Guarantor");
            });

        modelBuilder.Entity("AcountsForLoan", b =>
            {
                b.HasOne("Repositories.Models.Acount", null)
                    .WithMany()
                    .HasForeignKey("AcountsNumber")
                    .IsRequired()
                    .HasConstraintName("FK_AcountsForLoans_Acounts");

                b.HasOne("Repositories.Models.LoanDetails", null)
                    .WithMany()
                    .HasForeignKey("LoanId")
                    .IsRequired()
                    .HasConstraintName("FK_AcountsForLoans_LoansDetails");
            });

        modelBuilder.Entity("BorrowerLoanDetails", b =>
            {
                b.HasOne("Repositories.Models.Borrower", null)
                    .WithMany()
                    .HasForeignKey("BorrowersUserId")
                    .OnDelete(DeleteBehavior.Cascade)
                    .IsRequired();

                b.HasOne("Repositories.Models.LoanDetails", null)
                    .WithMany()
                    .HasForeignKey("LoansLoanId")
                    .OnDelete(DeleteBehavior.Cascade)
                    .IsRequired();
            });

        modelBuilder.Entity("Repositories.Models.Acount", b =>
            {
                b.HasOne("Repositories.Models.Borrower", "Borrower")
                    .WithMany("Acounts")
                    .HasForeignKey("BorrowerId")
                    .OnDelete(DeleteBehavior.Cascade)
                    .IsRequired();

                b.Navigation("Borrower");
            });

        modelBuilder.Entity("Repositories.Models.Deposit", b =>
            {
                b.HasOne("Repositories.Models.Depositor", "Depositors")
                    .WithMany("Deposits")
                    .HasForeignKey("DepositorsId")
                    .OnDelete(DeleteBehavior.Cascade)
                    .IsRequired();

                b.Navigation("Depositors");
            });

        modelBuilder.Entity("Repositories.Models.Guarantor", b =>
            {
                b.HasOne("Repositories.Models.LoanDetails", "Loan")
                    .WithMany("Guarantors")
                    .HasForeignKey("LoanId")
                    .OnDelete(DeleteBehavior.Cascade)
                    .IsRequired();

                b.Navigation("Loan");
            });

        modelBuilder.Entity("Repositories.Models.LoanDetails", b =>
            {
                b.Navigation("Guarantors");
            });

        modelBuilder.Entity("Repositories.Models.Borrower", b =>
            {
                b.Navigation("Acounts");
            });

        modelBuilder.Entity("Repositories.Models.Depositor", b =>
            {
                b.Navigation("Deposits");
            });
#pragma warning restore 612, 618
    }
}
