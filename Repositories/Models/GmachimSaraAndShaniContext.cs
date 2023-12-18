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

    public virtual DbSet<Card> Cards { get; set; }

    public virtual DbSet<Deposit> Deposits { get; set; }

    public virtual DbSet<Guarantor> Guarantors { get; set; }

    public virtual DbSet<Users> Users {get; set;}

    public virtual DbSet<LoanDetails> LoanDetails {get; set;}
    public virtual DbSet<UsersUnderWarning> UsersUnderWarning { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=(localdb)\\mssqllocaldb;Initial Catalog=GmachimSaraAndShani;Integrated Security=True;");
    //Shani code:       => optionsBuilder.UseSqlServer("Data Source=(localdb)\\mssqllocaldb;Initial Catalog=GmachimSaraAndShani;Integrated Security=True;Pooling=False;");


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Configure Account
        modelBuilder.Entity<Card>(entity =>
        {
            entity.HasKey(e => e.AccontId);

            // Set other configurations if needed
            entity.Property(e => e.UserId).IsRequired();
            entity.Property(e => e.CreditCardNumber).IsRequired().HasMaxLength(16);
            entity.Property(e => e.CVV).IsRequired().HasMaxLength(3);
            entity.Property(e => e.Validity).IsRequired();
            entity.Property(e => e.OwnersName).IsRequired();
            
        });

        modelBuilder.Entity<Account>(entity =>
        {
            // Configure primary key
            entity.HasKey(e => e.Id);

            // Configure auto-generated value for Id
            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd();

            // Configure UserId as a foreign key if needed
            // entity.HasOne(e => e.User)
            //     .WithMany()
            //     .HasForeignKey(e => e.UserId);

            // Configure other properties
            entity.Property(e => e.OwnerFullName)
                .HasMaxLength(255); // Adjust the length as needed

            entity.Property(e => e.AccountNunber)
                .HasMaxLength(50); // Adjust the length as needed

            entity.Property(e => e.BankNumber)
                .HasMaxLength(50); // Adjust the length as needed

            entity.Property(e => e.BranchNumber)
                .HasMaxLength(50); // Adjust the length as needed
        });

        // Configure UserUnderWarning
        modelBuilder.Entity<UsersUnderWarning>(entity =>
        {
            entity.HasNoKey(); // Specify that it's a keyless entity
            entity.Property(u => u.UserId).IsRequired();
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
            
            entity.Property(g => g.LoanId).IsRequired();

            entity.Property(g => g.IdentityNumber).IsRequired();

            entity.Property(g => g.Name).IsRequired();

            entity.Property(g => g.PhoneNumber).IsRequired();

            entity.Property(g => g.EmailAddress).IsRequired();

            entity.Property(g => g.Address).IsRequired();

            entity.Property(g => g.Check).IsRequired();
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

            entity.Property(ld => ld.DateToGetBack).IsRequired();

            entity.Property(ld => ld.Sum).IsRequired();

            entity.Property(ld => ld.UserId).IsRequired();

            entity.Property(ld => ld.LoanFile).IsRequired();

            entity.Property(ld=> ld.IsAprovied).IsRequired();
        
    }); }
        

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
