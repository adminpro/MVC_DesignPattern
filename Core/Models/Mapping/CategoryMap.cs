using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;
using System.ComponentModel.DataAnnotations.Schema;
namespace Core.Models.Mapping
{
    public class CategoryMap : EntityTypeConfiguration<Category>
    {
        public CategoryMap()
        {
            HasKey(c => c.Id).Property(c => c.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(c => c.Name).IsRequired().HasMaxLength(255);
            Property(c => c.Url).IsOptional();
            Property(c => c.Order).IsOptional();
            Property(c => c.Status).IsRequired();
            ToTable("Category");
        }
    }
}
