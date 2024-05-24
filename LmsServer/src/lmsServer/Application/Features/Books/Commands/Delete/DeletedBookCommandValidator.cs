using FluentValidation;

namespace Application.Features.Books.Commands.Delete;

public class DeleteBookCommandValidator : AbstractValidator<DeleteBookCommand>
{
    public DeleteBookCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}