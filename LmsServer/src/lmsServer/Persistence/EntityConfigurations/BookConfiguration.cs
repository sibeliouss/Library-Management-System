using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class BookConfiguration : IEntityTypeConfiguration<Book>
{
    public void Configure(EntityTypeBuilder<Book> builder)
    {
        builder.ToTable("Books").HasKey(b => b.Id);

        builder.Property(b => b.Id).HasColumnName("Id").IsRequired();
        builder.Property(b => b.Name).HasColumnName("Name");
        builder.Property(b => b.ISBN).HasColumnName("ISBN");
        builder.Property(b => b.Page).HasColumnName("Page");
        builder.Property(b => b.Language).HasColumnName("Language");
        builder.Property(b => b.UnitsInStock).HasColumnName("UnitsInStock");
        builder.Property(b => b.Description).HasColumnName("Description");
        builder.Property(b => b.CategoryId).HasColumnName("CategoryId");
        builder.Property(b => b.PublisherId).HasColumnName("PublisherId");
        builder.Property(b => b.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(b => b.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(b => b.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(b => !b.DeletedDate.HasValue);
    }
}