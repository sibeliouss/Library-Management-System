using NArchitecture.Core.Persistence.Repositories;

namespace Domain.Entities;

public class Author : Entity<Guid>
{
    public string Name { get; set; }
    public string IdentityNumber { get; set; }
    public string Biography { get; set; }
    
    public virtual ICollection<AuthorBook>? AuthorBooks { get; set; }
    public Author()
    {
        
    }
    public Author(Guid id,string name, string identityNumber, string biography):base(id)
    {
        Name = name;
        IdentityNumber = identityNumber;
        Biography = biography;
    }
    
}