using ETRadeApp.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ETRadeApp.DataAccess.EntityConfigurations
{
    internal class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Products");
            builder.HasKey(x=>x.Id);
            builder.Property(x => x.Name).HasColumnName("Name");
            builder.HasQueryFilter(x => !x.IsDeleted);
            builder.Property(x => x.UnitPrice).HasColumnType("decimal(18,2)").HasColumnName("UnitPrice");
            builder.Property(x => x.CreatedDate).HasColumnName("CreatedDate");
            builder.Property(x => x.UpdateDate).HasColumnName("UpdateDate");
            builder.Property(x => x.DeletedDate).HasColumnName("DeletedDate");
            builder.Property(x => x.CategoryId).HasColumnName("CategoryId");
            builder.Property(x=>x.IsDeleted).HasDefaultValue(false);
            builder.HasOne(x=>x.Category).WithMany(x=>x.Products).HasForeignKey(x=>x.CategoryId);
        }
    }
}
