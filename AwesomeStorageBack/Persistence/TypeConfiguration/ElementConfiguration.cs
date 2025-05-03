using System.Text.RegularExpressions;
using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.TypeConfiguration;

public class ElementConfiguration : IEntityTypeConfiguration<Element>
{
    public void Configure(EntityTypeBuilder<Element> builder)
    {
        builder.HasKey(o => o.Id);
        builder.Property(o => o.Details).IsRequired();

        // Добавьте индекс для полнотекстового поиска
        builder.HasIndex(o => o.DetailsSearch).HasMethod("GIN");
    }
}