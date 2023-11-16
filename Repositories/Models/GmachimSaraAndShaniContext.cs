using System;
using System.Collections.Generic;
using System.ComponentModel;
using Microsoft.EntityFrameworkCore;

namespace Repositories.Models;

public partial class GmachimSaraAndShaniContext : DbContext, IDbContext
{
    
    public GmachimSaraAndShaniContext()
    {
    }

    public GmachimSaraAndShaniContext(DbContextOptions<GmachimSaraAndShaniContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Account> Acounts { get; set; }

    public virtual DbSet<Borrower> Borrowers { get; set; }

    public virtual DbSet<Deposit> Deposits { get; set; }

    public virtual DbSet<Depositor> Depositors { get; set; }

    public virtual DbSet<Guarantor> Guarantors { get; set; }

    public virtual DbSet<LoanDetails> LoansDetails { get; set; }
    public DbSet<User> User {get; set;}
    public DbSet<LoanDetails> LoanDetails {get; set;}

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=(localdb)\\mssqllocaldb;Initial Catalog=GmachimSaraAndShani;Integrated Security=True;Pooling=False;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Configure Account
        modelBuilder.Entity<Account>(entity =>
        {
            entity.HasKey(e => e.AccontId);

            // Set other configurations if needed
            entity.Property(e => e.AccountsNumber).IsRequired();
            entity.Property(e => e.BankNumber).IsRequired();
            entity.Property(e => e.Branch).IsRequired();
            entity.Property(e => e.ConfirmAcountFile).IsRequired().HasMaxLength(255);

            // Example: Relationships
            //entity.HasOne(a => a.Borrower)
            //    .WithMany(b => b.Acounts)
            //    .HasForeignKey(a => a.UserId);
        });
    
        // Configure User
        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId);

            // Set other configurations if needed
            entity.Property(e => e.UserName).IsRequired().HasMaxLength(255);
            entity.Property(e => e.UserPassword).IsRequired().HasMaxLength(255);
            entity.Property(e => e.UserEmail).IsRequired().HasMaxLength(255);
            entity.Property(e => e.UserAddress).IsRequired().HasMaxLength(255);
            entity.Property(e => e.UserPhone).IsRequired();

            // Example: Add a unique constraint on UserEmail
            entity.HasIndex(e => e.UserIdentityNumber).IsUnique();
        });

        // Configure Borrower
        modelBuilder.Entity<Borrower>(entity =>
        {
            // Inherit properties from User
            entity.HasBaseType<User>();

            // Add specific configurations for Borrower
            // Example: Relationships
            //entity.HasMany(b => b.Acounts)
            //    .WithOne(a => a.Borrower)
            //    .HasForeignKey(a => a.BorrowerID);

            //entity.HasMany(b => b.Loans)
            //    .WithOne(ld => ld.)
            //    .HasForeignKey(ld => ld.BorrowerNumber);
        });

        // Configure Depositor
        modelBuilder.Entity<Depositor>(entity =>
        {
            // Inherit properties from User
            entity.HasBaseType<User>();

            // Add specific configurations for Depositor
            // Example: Relationships
            //entity.HasMany(d => d.Deposits)
            //    .WithOne(de => de.Depositor)
            //    .HasForeignKey(de => de.DepositorID);
        });

        // Configure Guarantor
        modelBuilder.Entity<Guarantor>(entity =>
        {
            // Inherit properties from User
            entity.HasBaseType<User>();

            entity.HasOne(g => g.Account)
            .WithOne()
            .HasForeignKey<Account>(a => a.UserId)
            .IsRequired();
        });

        // Configure Deposit
        modelBuilder.Entity<Deposit>(entity =>
        {
            entity.HasKey(e => e.DepositId);

            // Set other configurations if needed
            entity.Property(e => e.Sum).IsRequired();
            entity.Property(e => e.DateToPull).IsRequired();

            // Example: Relationships
            //entity.HasOne(d => d.Depositor)
            //    .WithMany(de => de.Deposits)
            //    .HasForeignKey(d => d.UserId);
        });

        // Configure LoanDetails
        modelBuilder.Entity<LoanDetails>(entity =>
        {
            entity.HasKey(e => e.LoanId);

            // Set other configurations if needed
            entity.Property(e => e.DateToGetBack).IsRequired();
            entity.Property(e => e.Sum).IsRequired();
            entity.Property(e => e.LoanFile).IsRequired().HasMaxLength(255);

            entity.HasOne<User>()  // Assuming there is a DbSet<User> in your context
            .WithMany()
            .HasForeignKey(ld => ld.UserId)  // This sets up the foreign key relationship
            .IsRequired();
        });

            OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
