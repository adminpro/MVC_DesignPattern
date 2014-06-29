using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity.ModelConfiguration;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Models.LessionLearn
{
    public class LessionReleateMap : EntityTypeConfiguration<LessionReleate>
    {
        public LessionReleateMap()
        {
            HasKey(c => c.Id).Property(c => c.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(c => c.LessionReleateId).IsRequired();
            Property(c => c.LessionId).IsRequired();
            ToTable("LessionReleate");
        }
    }
}
