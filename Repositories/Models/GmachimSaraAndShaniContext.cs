using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Repositories.Models;

public partial class GmachimSaraAndShaniContext : DbContext ,IDbContext
{
    public GmachimSaraAndShaniContext()
    {
    }

    public GmachimSaraAndShaniContext(DbContextOptions<GmachimSaraAndShaniContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Acount> Acounts { get; set; }
    public virtual DbSet<User> User { get; set; }

    public virtual DbSet<Borrower> Borrowers { get; set; }

    public virtual DbSet<Deposit> Deposits { get; set; }

    public virtual DbSet<Depositor> Depositors { get; set; }

    public virtual DbSet<Guarantor> Guarantors { get; set; }

    public virtual DbSet<LoansDetail> LoansDetails { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=fsqln\\fsqln;Database=Gmachim_Sara_and_Shani;Trusted_Connection=True;Trust Server Certificate=true;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Acount>(entity =>
        {
            entity.HasKey(e => e.AccontId).HasName("PK_Acounts_1");

            entity.HasIndex(e => new { e.BorrowerId, e.AcountsNumber, e.BankNumber }, "IX_Acounts").IsUnique();

            entity.Property(e => e.BorrowerId).HasColumnName("BorrowerID");
            entity.Property(e => e.ConfirmAcountFile).HasMaxLength(150);

            entity.HasOne(d => d.Borrower).WithMany(p => p.Acounts)
                .HasForeignKey(d => d.BorrowerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Acounts_Borrowers");
        });

        modelBuilder.Entity<Borrower>(entity =>
        {
            entity.HasKey(e => e.UserNumber);

            entity.Property(e => e.CopyId)
                .HasMaxLength(150)
                .HasColumnName("CopyID");
            entity.Property(e => e.UserAddress).HasMaxLength(40);
            entity.Property(e => e.UserEmail)
                .HasMaxLength(30)
                .IsFixedLength();
            entity.Property(e => e.UserId).HasColumnName("UserID");
            entity.Property(e => e.UserName).HasMaxLength(30);
        });

        modelBuilder.Entity<Deposit>(entity =>
        {
            entity.Property(e => e.DepositId).HasColumnName("DepositID");
            entity.Property(e => e.DepositorsId).HasColumnName("DepositorsID");

            entity.HasOne(d => d.Depositors).WithMany(p => p.Deposits)
                .HasForeignKey(d => d.DepositorsId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Deposits_Depositors");
        });

        modelBuilder.Entity<Depositor>(entity =>
        {
            entity.HasKey(e => e.UserNumber);

            entity.Property(e => e.UserAddress).HasMaxLength(40);
            entity.Property(e => e.UserEmail)
                .HasMaxLength(30)
                .IsFixedLength()
                .HasColumnName("userEmail");
            entity.Property(e => e.UserId).HasColumnName("UserID");
            entity.Property(e => e.UserName).HasMaxLength(30);
        });

        modelBuilder.Entity<Guarantor>(entity =>
        {
            entity.HasKey(e => e.UserNumber);

            entity.Property(e => e.UserAddress).HasMaxLength(40);
            entity.Property(e => e.UserEmail)
                .HasMaxLength(40)
                .IsFixedLength();
            entity.Property(e => e.UserId).HasColumnName("guarantorID");
            entity.Property(e => e.UserName)
                .HasMaxLength(30)
                .HasColumnName("guarantorName");
            entity.Property(e => e.LoanId).HasColumnName("LoanID");

            entity.HasOne(d => d.Loan).WithMany(p => p.Guarantors)
                .HasForeignKey(d => d.LoanId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Guarantors_LoansDetails");
        });

        modelBuilder.Entity<LoansDetail>(entity =>
        {
            entity.HasKey(e => e.LoanId);

            entity.Property(e => e.LoanId).HasColumnName("LoanID");
            entity.Property(e => e.LoanFile).HasMaxLength(150);

            entity.HasMany(d => d.AcountsNumbers).WithMany(p => p.Loans)
                .UsingEntity<Dictionary<string, object>>(
                    "AcountsForLoan",
                    r => r.HasOne<Acount>().WithMany()
                        .HasForeignKey("AcountsNumber")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_AcountsForLoans_Acounts"),
                    l => l.HasOne<LoansDetail>().WithMany()
                        .HasForeignKey("LoanId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_AcountsForLoans_LoansDetails"),
                    j =>
                    {
                        j.HasKey("LoanId", "AcountsNumber");
                        j.ToTable("AcountsForLoans");
                        j.IndexerProperty<int>("LoanId").HasColumnName("LoanID");
                    });

            entity.HasMany(d => d.Borrowers).WithMany(p => p.Loans)
                .UsingEntity<Dictionary<string, object>>(
                    "LoansGuarantor",
                    r => r.HasOne<Borrower>().WithMany()
                        .HasForeignKey("BorrowerId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_LoansGuarantors _Borrowers"),
                    l => l.HasOne<LoansDetail>().WithMany()
                        .HasForeignKey("LoanId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_LoansGuarantors _LoansDetails"),
                    j =>
                    {
                        j.HasKey("LoanId", "BorrowerId").HasName("PK_LoansConectoin");
                        j.ToTable("LoansGuarantors ");
                        j.IndexerProperty<int>("LoanId").HasColumnName("LoanID");
                        j.IndexerProperty<int>("BorrowerId").HasColumnName("BorrowerID");
                    });
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
