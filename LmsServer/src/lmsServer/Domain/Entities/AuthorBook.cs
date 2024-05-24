using NArchitecture.Core.Persistence.Repositories;

namespace Domain.Entities;

public class AuthorBook: Entity<Guid>
{
    
    public Guid AuthorId { get; set; }
    public virtual Author? Author { get; set; }
    public Guid BookId { get; set; }
    public virtual Book? Book { get; set; }
    public AuthorBook()
    {
        
    }

    public AuthorBook(Guid id,Guid authorId, Guid bookId):base(id)
    {
        AuthorId = authorId;
        BookId = bookId;
    }
}