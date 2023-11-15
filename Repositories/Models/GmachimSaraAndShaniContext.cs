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
    public virtual DbSet<Account> Acounts { get; set; }

    public virtual DbSet<User> User { get; set; }

    public virtual DbSet<Borrower> Borrowers { get; set; }

    public virtual DbSet<Deposit> Deposits { get; set; }

    public virtual DbSet<Depositor> Depositors { get; set; }

    public virtual DbSet<Guarantor> Guarantors { get; set; }

    public virtual DbSet<LoanDetails> LoanDetails { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=(localdb)\\mssqllocaldb;Initial Catalog=GmachimSaraAndShani;Integrated Security=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<User>()
            .HasKey(u => u.UserId);

        modelBuilder.Entity<Borrower>()
            .HasBaseType<User>();

        modelBuilder.Entity<Depositor>()
            .HasBaseType<User>();

        modelBuilder.Entity<LoanDetails>()
            .HasKey(ld => ld.LoanId);

        modelBuilder.Entity<Account>()
            .HasKey(a => a.AccontId);

        modelBuilder.Entity<LoanDetails>()
            .HasMany(ld => ld.AcountsNumbers)
            .WithMany(a => a.Loans)
            .UsingEntity<Dictionary<string, object>>(
                "AcountsForLoan",
                r => r.HasOne<Account>().WithMany()
                    .HasForeignKey("AcountsNumber")
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AcountsForLoans_Acounts"),
                l => l.HasOne<LoanDetails>().WithMany()
                    .HasForeignKey("LoanId")
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AcountsForLoans_LoansDetails"),
                j =>
                {
                    j.HasKey("LoanId", "AcountsNumber");
                    j.ToTable("AcountsForLoans");
                    j.IndexerProperty<int>("LoanId").HasColumnName("LoanID");
                });
    }



    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
