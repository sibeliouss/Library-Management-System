using FluentValidation;

namespace Application.Features.Authors.Commands.Create;

public class CreateAuthorCommandValidator : AbstractValidator<CreateAuthorCommand>
{
    public CreateAuthorCommandValidator()
    {
        RuleFor(c => c.Name).NotEmpty();
        RuleFor(c => c.IdentityNumber).NotEmpty();
        RuleFor(c => c.Biography).NotEmpty();
    }
}