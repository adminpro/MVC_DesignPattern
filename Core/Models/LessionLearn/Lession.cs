using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Models.LessionLearn
{
    public class Lession:BaseEntity<int>
    {
        [MaxLength(50)]
        public string Name { get; set; }
        [MaxLength(500)]
        public string English { get; set; }
        [MaxLength(500)]
        public string VietNam { get; set; }
        [MaxLength(500)]
        public string Description { get; set; }
        public List<LessionReleate> LessionReleates { get; set; }
        public int LessionGroupId { get; set; }
        [ForeignKey("LessionGroupId")]
        public LessionGroup LessionGroup { get; set; }
    }
}
