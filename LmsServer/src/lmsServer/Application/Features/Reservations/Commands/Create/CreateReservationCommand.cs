using Application.Features.Reservations.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Pipelines.Logging;
using NArchitecture.Core.Application.Pipelines.Transaction;
using MediatR;

namespace Application.Features.Reservations.Commands.Create;

public class CreateReservationCommand : IRequest<CreatedReservationResponse>, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
  
    public Guid BookId { get; set; }
    public Guid MemberId { get; set; }
    public DateTime ReservationDate { get; set; }
    public DateTime ExpirationDate { get; set; }

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetReservations"];

    public class CreateReservationCommandHandler : IRequestHandler<CreateReservationCommand, CreatedReservationResponse>
    {
        private readonly IMapper _mapper;
        private readonly IReservationRepository _reservationRepository;
        private readonly ReservationBusinessRules _reservationBusinessRules;

        public CreateReservationCommandHandler(IMapper mapper, IReservationRepository reservationRepository,
                                         ReservationBusinessRules reservationBusinessRules)
        {
            _mapper = mapper;
            _reservationRepository = reservationRepository;
            _reservationBusinessRules = reservationBusinessRules;
        }

        public async Task<CreatedReservationResponse> Handle(CreateReservationCommand request, CancellationToken cancellationToken)
        {
            Reservation reservation = _mapper.Map<Reservation>(request);

            await _reservationRepository.AddAsync(reservation);

            CreatedReservationResponse response = _mapper.Map<CreatedReservationResponse>(reservation);
            return response;
        }
    }
}