using NArchitecture.Core.Persistence.Repositories;

namespace Domain.Entities;

public class CategoryBook : Entity<Guid>
{
    public virtual Category? Category { get; set; } 
    public virtual Book? Book { get; set; }
    public Guid BookId { get; set; }
    public Guid CategoryId { get; set; }

    public CategoryBook()
    {
        
    }

    public CategoryBook(Guid id,Guid categoryId, Guid bookId):base(id)
    {
        CategoryId = categoryId;
        BookId = bookId;
    } 
}