using NArchitecture.Core.Application.Dtos;

namespace Application.Features.Reservations.Queries.GetList;

public class GetListReservationListItemDto : IDto
{
    public Guid Id { get; set; }
    public Guid BookId { get; set; }
    public Guid MemberId { get; set; }
    public string BookName { get; set; }
    public DateTime ReservationDate { get; set; }
    public DateTime ExpirationDate { get; set; }
}