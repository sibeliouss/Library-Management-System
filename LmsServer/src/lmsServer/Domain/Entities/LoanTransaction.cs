using Domain.Enums;
using NArchitecture.Core.Persistence.Repositories;

namespace Domain.Entities;

public class LoanTransaction : Entity<Guid>
{
    public Guid MemberId { get; set; }
    public Guid BookId { get; set; }
    public ReturnStatus? ReturnStatus { get; set; }
    public DateTime ReturnTime { get; set; }

    public virtual Member? Member { get; set; }
    public virtual Book? Book { get; set; } 
}