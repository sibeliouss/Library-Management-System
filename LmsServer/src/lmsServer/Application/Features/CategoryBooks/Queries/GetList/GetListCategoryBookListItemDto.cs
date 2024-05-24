using NArchitecture.Core.Application.Dtos;

namespace Application.Features.CategoryBooks.Queries.GetList;

public class GetListCategoryBookListItemDto : IDto
{
    public Guid Id { get; set; }
    public Guid BookId { get; set; }
    public Guid CategoryId { get; set; }
}