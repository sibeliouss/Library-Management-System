using Application.Features.Books.Commands.Create;
using Application.Features.Books.Commands.Delete;
using Application.Features.Books.Commands.Update;
using Application.Features.Books.Queries.GetById;
using Application.Features.Books.Queries.GetDynamic;
using Application.Features.Books.Queries.GetList;
using AutoMapper;
using NArchitecture.Core.Application.Responses;
using Domain.Entities;
using NArchitecture.Core.Persistence.Paging;

namespace Application.Features.Books.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        
        CreateMap<Book, CreateBookCommand>().ReverseMap();
        CreateMap<Book, CreatedBookResponse>().ReverseMap();
        CreateMap<Book, UpdateBookCommand>().ReverseMap();
        CreateMap<Book, UpdatedBookResponse>().ReverseMap();
        CreateMap<Book, DeleteBookCommand>().ReverseMap();
        CreateMap<Book, DeletedBookResponse>().ReverseMap();
        CreateMap<Book, GetByIdBookResponse>().ReverseMap();
        CreateMap<Book, GetListBookListItemDto>().ReverseMap();
        CreateMap<IPaginate<Book>, GetListResponse<GetListBookListItemDto>>().ReverseMap();
        
        CreateMap<GetDynamicBookItemDto,Book>().ReverseMap().ForMember(i=>i.CategoryName,opt => opt.MapFrom(j=>j.CategoryBooks));
        CreateMap<IPaginate<Book>, GetListResponse<GetDynamicBookItemDto>>().ReverseMap();
        CreateMap<IPaginate<Book>, GetListResponse<GetListBookListItemDto>>().ReverseMap();
        CreateMap<GetListBookListItemDto,Book>().ReverseMap().ForMember(i=>i.CategoryName,opt => opt.MapFrom(j=>j.CategoryBooks));
        
        CreateMap<GetListBookListItemDto, Book>().ReverseMap().ForMember(i => i.AuthorName, opt => opt.MapFrom(j => j.AuthorBooks));
    }  
}