
using Application.Features.Books.Queries.GetList;
using Application.Features.Reservations.Queries.GetList;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;



namespace Application.Features.Reservations.Queries.GetListReservationByMemberId;

public class GetListReservationByMemberId : IRequest<GetListResponse<GetListReservationListItemDto>>
{
    public PageRequest PageRequest { get; set; }
    public Guid MemberId { get; set; }
    public bool BypassCache { get; }
    public TimeSpan? SlidingExpiration { get; }

    public class GetListReservationByMemberIdHandler : IRequestHandler<GetListReservationByMemberId, GetListResponse<GetListReservationListItemDto>>
    {
        private readonly IMapper _mapper;
        private readonly IReservationRepository _reservationRepository;
        public GetListReservationByMemberIdHandler(IReservationRepository reservationRepository, IMapper mapper)
        {
            _reservationRepository = reservationRepository;
            _mapper = mapper;
        }
        public async Task<GetListResponse<GetListReservationListItemDto>> Handle(
            GetListReservationByMemberId request,
            CancellationToken cancellationToken)
        {
            IPaginate<Reservation> reservations = await _reservationRepository.GetListAsync(
                predicate: x => x.MemberId == request.MemberId,
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, include: i => i.Include(r => r.Book),
                cancellationToken: cancellationToken
            ) ;
            GetListResponse<GetListReservationListItemDto> response = _mapper.Map<GetListResponse<GetListReservationListItemDto>>(reservations);
            return response;
        }
    }
}