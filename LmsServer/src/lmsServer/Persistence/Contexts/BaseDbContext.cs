using System.Reflection;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Persistence.Contexts;

public class BaseDbContext : DbContext
{
    protected IConfiguration Configuration { get; set; }
    public DbSet<EmailAuthenticator> EmailAuthenticators { get; set; }
    public DbSet<OperationClaim> OperationClaims { get; set; }
    public DbSet<OtpAuthenticator> OtpAuthenticators { get; set; }
    public DbSet<RefreshToken> RefreshTokens { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<UserOperationClaim> UserOperationClaims { get; set; }
    public DbSet<AuthorBook> AuthorBooks { get; set; }
    public DbSet<Author> Authors { get; set; }
    public DbSet<Member> Members { get; set; }
    public DbSet<CategoryBook> CategoryBooks { get; set; }
    public DbSet<Publisher> Publishers { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<BookPublisher> BookPublishers { get; set; }
    public DbSet<Book> Books { get; set; }
    public DbSet<LoanTransaction> LoanTransactions { get; set; }
    public DbSet<Announcement> Announcements { get; set; }
    public DbSet<Reservation> Reservations { get; set; }



    public BaseDbContext(DbContextOptions dbContextOptions, IConfiguration configuration)
        : base(dbContextOptions)
    {
        Configuration = configuration;
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}
