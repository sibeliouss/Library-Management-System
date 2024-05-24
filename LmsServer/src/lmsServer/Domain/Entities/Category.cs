using NArchitecture.Core.Persistence.Repositories;

namespace Domain.Entities;

public class Category :Entity<Guid>
{
    public string CategoryName { get; set; }
    public virtual ICollection<CategoryBook>? CategoryBooks { get; set; } 
    public Category()
    {
        
    }
    public Category(Guid id,string name):base(id) 
    {
        CategoryName = name;
    }
    
}