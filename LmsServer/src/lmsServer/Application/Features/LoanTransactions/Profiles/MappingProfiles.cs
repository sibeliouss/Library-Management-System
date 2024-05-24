using Application.Features.LoanTransactions.Commands.Create;
using Application.Features.LoanTransactions.Commands.Delete;
using Application.Features.LoanTransactions.Commands.Update;
using Application.Features.LoanTransactions.Queries.GetById;
using Application.Features.LoanTransactions.Queries.GetList;
using AutoMapper;
using NArchitecture.Core.Application.Responses;
using Domain.Entities;
using NArchitecture.Core.Persistence.Paging;

namespace Application.Features.LoanTransactions.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<LoanTransaction, CreateLoanTransactionCommand>().ReverseMap();
        CreateMap<LoanTransaction, CreatedLoanTransactionResponse>().ReverseMap();
        CreateMap<LoanTransaction, UpdateLoanTransactionCommand>().ReverseMap();
        CreateMap<LoanTransaction, UpdatedLoanTransactionResponse>().ReverseMap();
        CreateMap<LoanTransaction, DeleteLoanTransactionCommand>().ReverseMap();
        CreateMap<LoanTransaction, DeletedLoanTransactionResponse>().ReverseMap();
        CreateMap<LoanTransaction, GetByIdLoanTransactionResponse>().ReverseMap();
        CreateMap<LoanTransaction, GetListLoanTransactionListItemDto>().ReverseMap();
        CreateMap<IPaginate<LoanTransaction>, GetListResponse<GetListLoanTransactionListItemDto>>().ReverseMap();
    }
}