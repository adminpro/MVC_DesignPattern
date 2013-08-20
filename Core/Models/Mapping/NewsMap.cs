using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Models.Mapping
{
    public class NewsMap: EntityTypeConfiguration<News>
    {
        public NewsMap()
        {
            this.HasKey(c=>c.Id).Property(c => c.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.Property(c => c.Title).HasMaxLength(255);
            this.Property(c => c.CreatedDate).IsRequired();
            this.Property(c => c.ModifiedDate).IsOptional();
            this.Property(c => c.Category_Id).IsRequired();
            this.ToTable("News");
            //HasRequired(c => c.Category).WithMany(d => d.News).Map(a => a.MapKey("Category_Id")).WillCascadeOnDelete(true);
            //HasOptional(c => c.Category).WithMany(d => d.News).Map(a => a.MapKey("Category_Id")).WillCascadeOnDelete(false);
        }
    }
}
