using NArchitecture.Core.Persistence.Repositories;

namespace Domain.Entities;

public class Publisher : Entity<Guid>
{
    public string Name { get; set; }
    public virtual ICollection<BookPublisher>? BookPublishers { get; set; }

    public Publisher(Guid id,string name):base(id)
    {
        Name = name;

    }
    public Publisher()
    {
        
    } 
}