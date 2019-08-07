using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VCompare.Domain.Entities;

namespace VCompare.Persistence.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(256);
            builder
                .HasOne(p => p.PriceCalculationModel)
                .WithOne(pcm => pcm.Product)
                .HasForeignKey<PriceCalculationModel>(pcm => pcm.ProductId);
        }
    }
}