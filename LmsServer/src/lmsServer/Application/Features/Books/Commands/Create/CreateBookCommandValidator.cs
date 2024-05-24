using FluentValidation;

namespace Application.Features.Books.Commands.Create;

public class CreateBookCommandValidator : AbstractValidator<CreateBookCommand>
{
    public CreateBookCommandValidator()
    {
        RuleFor(c => c.Name).NotEmpty();
        RuleFor(c => c.ISBN).NotEmpty();
        RuleFor(c => c.Page).NotEmpty();
        RuleFor(c => c.Language).NotEmpty();
        RuleFor(c => c.UnitsInStock).NotEmpty();
        RuleFor(c => c.Description).NotEmpty();
        RuleFor(c => c.CategoryId).NotEmpty();
        RuleFor(c => c.PublisherId).NotEmpty();
        
     
    }
}