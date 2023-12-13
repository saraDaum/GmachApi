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

    public virtual DbSet<Account> Accounts { get; set; }

    public virtual DbSet<Card> Cards { get; set; }

    public virtual DbSet<Deposit> Deposits { get; set; }

    public virtual DbSet<Guarantor> Guarantors { get; set; }

    public virtual DbSet<Users> Users {get; set;}

    public virtual DbSet<LoanDetails> LoanDetails {get; set;}

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=(localdb)\\mssqllocaldb;Initial Catalog=GmachimSaraAndShani;Integrated Security=True;");
    //Shani code:       => optionsBuilder.UseSqlServer("Data Source=(localdb)\\mssqllocaldb;Initial Catalog=GmachimSaraAndShani;Integrated Security=True;Pooling=False;");


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Configure Account
        modelBuilder.Entity<Account>(entity =>
        {
            entity.HasKey(e => e.AccontId);

            // Set other configurations if needed
            entity.Property(e => e.UserId).IsRequired();
            entity.Property(e => e.AccountsNumber).IsRequired();
            entity.Property(e => e.BankNumber).IsRequired();
            entity.Property(e => e.Branch).IsRequired();
            entity.Property(e => e.OwnerIdNumber).IsRequired();
            entity.Property(e => e.ConfirmAcountFile).IsRequired().HasMaxLength(255);


            //entity.HasOne<Users>()  // Specify Users as the type here
            //.WithMany()
            //.HasForeignKey(d => d.UserId)
            //.OnDelete(DeleteBehavior.Cascade);
        });

        // Configure User
        modelBuilder.Entity<Users>(entity =>
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

        // Configure Guarantor entity
        modelBuilder.Entity<Guarantor>(entity =>
        {
            entity.HasKey(g => g.Id);  // Assuming Id is the primary key

            entity.Property(g => g.IdentityNumber)
                .IsRequired();

            entity.Property(g => g.Name)
                .IsRequired();

            entity.Property(g => g.PhoneNumber)
                .IsRequired();

            entity.Property(g => g.EmailAddress)
                .IsRequired();

            entity.Property(g => g.Address)
                .IsRequired();

            //// Define the relationship between Guarantor and Account
            //entity.HasOne(g => g.Account)
            //    .WithOne()
            //    .HasForeignKey<Account>(a => a.AccontId);  // Assuming GuarantorId is the foreign key in the Account table
        });


        // Configure Deposit entity
        modelBuilder.Entity<Deposit>(entity =>
        {
            entity.HasKey(d => d.DepositId);

            entity.Property(d => d.Sum).IsRequired();

            entity.Property(d => d.DateToPull).IsRequired();

            //// Define the relationship between Deposit and Users
            //entity.HasOne<Users>()  // Specify Users as the type here
            //.WithMany()
            //.HasForeignKey(d => d.UserId)
            //.OnDelete(DeleteBehavior.Cascade);
        });

        // Configure LoanDetails entity
        modelBuilder.Entity<LoanDetails>(entity =>
        {
            entity.HasKey(ld => ld.LoanId);

            entity.Property(ld => ld.DateToGetBack)
                .IsRequired();

            entity.Property(ld => ld.Sum)
                .IsRequired();

            entity.Property(ld => ld.UserId)
                .IsRequired();

            entity.Property(ld => ld.LoanFile)
                .IsRequired();

            entity.Property(ld=> ld.IsAprovied)
                .IsRequired();
        
    }); }
        

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
