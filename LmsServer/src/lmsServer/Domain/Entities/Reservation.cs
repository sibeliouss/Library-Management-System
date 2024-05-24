using NArchitecture.Core.Persistence.Repositories;

namespace Domain.Entities;

public class Reservation: Entity<Guid>
{
    public Guid Id { get; set; }
    public Guid BookId { get; set; }
    public Guid MemberId { get; set; }
    public DateTime ReservationDate { get; set; }//Rezervasyonun başlayacağı tarih
    public DateTime ExpirationDate { get; set; }//Rezervasyonun biteceği tarih

    public virtual Member Member { get; set; }
    public virtual Book Book { get; set; }  
    
}