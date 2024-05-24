using Application.Features.Reservations.Constants;
using Application.Features.Reservations.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Pipelines.Logging;
using NArchitecture.Core.Application.Pipelines.Transaction;
using MediatR;

namespace Application.Features.Reservations.Commands.Delete;

public class DeleteReservationCommand : IRequest<DeletedReservationResponse>, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public Guid Id { get; set; }

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetReservations"];

    public class DeleteReservationCommandHandler : IRequestHandler<DeleteReservationCommand, DeletedReservationResponse>
    {
        private readonly IMapper _mapper;
        private readonly IReservationRepository _reservationRepository;
        private readonly ReservationBusinessRules _reservationBusinessRules;

        public DeleteReservationCommandHandler(IMapper mapper, IReservationRepository reservationRepository,
                                         ReservationBusinessRules reservationBusinessRules)
        {
            _mapper = mapper;
            _reservationRepository = reservationRepository;
            _reservationBusinessRules = reservationBusinessRules;
        }

        public async Task<DeletedReservationResponse> Handle(DeleteReservationCommand request, CancellationToken cancellationToken)
        {
            Reservation? reservation = await _reservationRepository.GetAsync(predicate: r => r.Id == request.Id, cancellationToken: cancellationToken);
            await _reservationBusinessRules.ReservationShouldExistWhenSelected(reservation);

            await _reservationRepository.DeleteAsync(reservation!);

            DeletedReservationResponse response = _mapper.Map<DeletedReservationResponse>(reservation);
            return response;
        }
    }
}