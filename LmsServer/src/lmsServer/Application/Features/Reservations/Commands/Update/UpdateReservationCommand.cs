using Application.Features.Reservations.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Pipelines.Logging;
using NArchitecture.Core.Application.Pipelines.Transaction;
using MediatR;

namespace Application.Features.Reservations.Commands.Update;

public class UpdateReservationCommand : IRequest<UpdatedReservationResponse>, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public Guid Id { get; set; }
    public Guid BookId { get; set; }
    public Guid MemberId { get; set; }
    public DateTime ReservationDate { get; set; }
    public DateTime ExpirationDate { get; set; }

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetReservations"];

    public class UpdateReservationCommandHandler : IRequestHandler<UpdateReservationCommand, UpdatedReservationResponse>
    {
        private readonly IMapper _mapper;
        private readonly IReservationRepository _reservationRepository;
        private readonly ReservationBusinessRules _reservationBusinessRules;

        public UpdateReservationCommandHandler(IMapper mapper, IReservationRepository reservationRepository,
                                         ReservationBusinessRules reservationBusinessRules)
        {
            _mapper = mapper;
            _reservationRepository = reservationRepository;
            _reservationBusinessRules = reservationBusinessRules;
        }

        public async Task<UpdatedReservationResponse> Handle(UpdateReservationCommand request, CancellationToken cancellationToken)
        {
            Reservation? reservation = await _reservationRepository.GetAsync(predicate: r => r.Id == request.Id, cancellationToken: cancellationToken);
            await _reservationBusinessRules.ReservationShouldExistWhenSelected(reservation);
            reservation = _mapper.Map(request, reservation);

            await _reservationRepository.UpdateAsync(reservation!);

            UpdatedReservationResponse response = _mapper.Map<UpdatedReservationResponse>(reservation);
            return response;
        }
    }
}