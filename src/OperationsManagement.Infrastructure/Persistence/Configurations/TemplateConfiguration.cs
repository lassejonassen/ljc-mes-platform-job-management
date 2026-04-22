using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OperationsManagement.Domain.Templates.Entities;

namespace OperationsManagement.Infrastructure.Persistence.Configurations;

internal sealed class TemplateConfiguration : IEntityTypeConfiguration<Template>
{
    public void Configure(EntityTypeBuilder<Template> builder)
    {
        builder.ToTable("Templates");

        builder.HasKey(e => e.Id);

        builder.Property(e => e.Id)
            .ValueGeneratedNever();

        builder.Property(e => e.Name)
            .HasMaxLength(Template.NameMaxLength)
            .IsRequired(true);

        builder.Property(e => e.Description)
            .HasMaxLength(Template.DescriptionMaxLength)
            .IsRequired(false);
    }
}
