using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RectangleAssignment.Domain;

namespace RectangleAssignment.Infrastructure.EntityTypeConfigurations
{
    public class RectangleDimensionEntityTypeConfigurations : IEntityTypeConfiguration<RectangleDimension>
    {
        public void Configure(EntityTypeBuilder<RectangleDimension> b)
        {
            b.Property(x => x.Id)
                .ValueGeneratedOnAdd()
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            b.Property(x => x.Height)
                .IsRequired();

            b.Property(x => x.Width)
                .IsRequired();

            b.Property(x => x.Perimeter)
                .IsRequired();

            b.Property(x => x.CreateDate)
                .IsRequired();

            b.HasKey(x => x.Id);

            b.ToTable("RectangleDimensions");
        }
    }
}
