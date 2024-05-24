using Application.Features.Reservations.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Reservations.Queries.GetById;

public class GetByIdReservationQuery : IRequest<GetByIdReservationResponse>
{
    public Guid Id { get; set; }

    public class GetByIdReservationQueryHandler : IRequestHandler<GetByIdReservationQuery, GetByIdReservationResponse>
    {
        private readonly IMapper _mapper;
        private readonly IReservationRepository _reservationRepository;
        private readonly ReservationBusinessRules _reservationBusinessRules;

        public GetByIdReservationQueryHandler(IMapper mapper, IReservationRepository reservationRepository, ReservationBusinessRules reservationBusinessRules)
        {
            _mapper = mapper;
            _reservationRepository = reservationRepository;
            _reservationBusinessRules = reservationBusinessRules;
        }

        public async Task<GetByIdReservationResponse> Handle(GetByIdReservationQuery request, CancellationToken cancellationToken)
        {
            Reservation? reservation = await _reservationRepository.GetAsync(predicate: r => r.Id == request.Id, cancellationToken: cancellationToken);
            await _reservationBusinessRules.ReservationShouldExistWhenSelected(reservation);

            GetByIdReservationResponse response = _mapper.Map<GetByIdReservationResponse>(reservation);
            return response;
        }
    }
}