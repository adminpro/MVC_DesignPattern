using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Models
{
    public class Category : BaseEntity<int>
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "Input cate name")]
        [StringLength(255)]
        public string Name { get; set; }
        [StringLength(255)]
        public string Url { get; set; }
        public byte Order { get; set; }
        [DefaultValue(true)]
        public bool Status { get; set; }
        public virtual IList<News> News { get; set; }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
