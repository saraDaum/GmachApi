using Microsoft.EntityFrameworkCore;
using Repositories.Models;

namespace Repositories;

public interface IDbContext
{
    DbSet<Account> Account { get; set; }

    DbSet<Card> Card { get; set; }
    
    DbSet<Users> Users { get; set; }

    DbSet<Deposit> Deposits { get; set; }

    DbSet<Guarantor> Guarantors { get; set; }

    DbSet<LoanDetails> LoanDetails { get; set; }

    DbSet<UsersUnderWarning> UsersUnderWarning { get; set; }

    DbSet<ContactRequest> ContactRequests { get; set; }

    DbSet<Message> Message { get; set; }

 

    int SaveChanges();
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    //Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken));
}