using FluentValidation;

namespace Application.Features.Reservations.Commands.Create;

public class CreateReservationCommandValidator : AbstractValidator<CreateReservationCommand>
{
    public CreateReservationCommandValidator()
    {
       
        RuleFor(c => c.BookId).NotEmpty();
        RuleFor(c => c.MemberId).NotEmpty();
        RuleFor(c => c.ReservationDate).NotEmpty();
        RuleFor(c => c.ExpirationDate).NotEmpty();
    }
}