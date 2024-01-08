using ETRadeApp.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ETRadeApp.DataAccess.EntityConfigurations
{
    internal class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.ToTable("Categories");
            builder.Property(x => x.Id).UseIdentityColumn();
            builder.Property(x => x.Name).HasColumnName("Name");
            builder.HasQueryFilter(x => !x.IsDeleted);
            builder.Property(x => x.CreatedDate).HasColumnName("CreatedDate");
            builder.Property(x => x.UpdateDate).HasColumnName("UpdateDate");
            builder.Property(x => x.DeletedDate).HasColumnName("DeletedDate");
            builder.Property(x => x.IsDeleted).HasDefaultValue(false);
        }
    }
}
