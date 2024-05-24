using NArchitecture.Core.Application.Responses;

namespace Application.Features.CategoryBooks.Commands.Create;

public class CreatedCategoryBookResponse : IResponse
{
    public Guid Id { get; set; }
    public Guid BookId { get; set; }
    public Guid CategoryId { get; set; }
}