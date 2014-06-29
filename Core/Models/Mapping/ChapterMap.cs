using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity.ModelConfiguration;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Models.LessionLearn
{
    public class ChapterMap : EntityTypeConfiguration<Chapter>
    {
        public ChapterMap()
        {
            HasKey(c => c.Id).Property(c => c.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(c => c.Name).IsRequired().HasMaxLength(50);
            Property(c => c.Description).IsOptional().HasMaxLength(500);
            ToTable("Chapter");
        }
    }
}
