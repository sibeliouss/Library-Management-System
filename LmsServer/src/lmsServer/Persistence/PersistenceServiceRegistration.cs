using Application.Services.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NArchitecture.Core.Persistence.DependencyInjection;
using Persistence.Contexts;
using Persistence.Repositories;

namespace Persistence;

public static class PersistenceServiceRegistration
{
    public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<BaseDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("BaseDb")));
        services.AddDbMigrationApplier(buildServices => buildServices.GetRequiredService<BaseDbContext>());

        services.AddScoped<IEmailAuthenticatorRepository, EmailAuthenticatorRepository>();
        services.AddScoped<IOperationClaimRepository, OperationClaimRepository>();
        services.AddScoped<IOtpAuthenticatorRepository, OtpAuthenticatorRepository>();
        services.AddScoped<IRefreshTokenRepository, RefreshTokenRepository>();
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IUserOperationClaimRepository, UserOperationClaimRepository>();

        services.AddScoped<IAuthorBookRepository, AuthorBookRepository>();
        services.AddScoped<IAuthorRepository, AuthorRepository>();
        services.AddScoped<IMemberRepository, MemberRepository>();
        services.AddScoped<ICategoryBookRepository, CategoryBookRepository>();
        services.AddScoped<IPublisherRepository, PublisherRepository>();
        services.AddScoped<ICategoryRepository, CategoryRepository>();
        services.AddScoped<IBookPublisherRepository, BookPublisherRepository>();
        
        services.AddScoped<IBookRepository, BookRepository>();
        services.AddScoped<ILoanTransactionRepository, LoanTransactionRepository>();
        services.AddScoped<ILoanTransactionRepository, LoanTransactionRepository>();
        
        services.AddScoped<IAnnouncementRepository, AnnouncementRepository>();
        services.AddScoped<IAnnouncementRepository, AnnouncementRepository>();
   
   services.AddScoped<IReservationRepository, ReservationRepository>();
        return services;
    }
}
