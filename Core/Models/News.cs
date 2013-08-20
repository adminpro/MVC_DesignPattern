using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Models
{
    public class News : BaseEntity<int>
    {
        [StringLength(255)]
        [Required(ErrorMessage="Please input title")]
        public string Title { get; set; }
        [Required(ErrorMessage="Does not allow empty content")]
        [DataType(DataType.MultilineText)]
        public string FullText { get; set; }
        [ScaffoldColumn(false)]
        [DataType(DataType.Date)]
        public DateTime CreatedDate { get; set; }
        [ScaffoldColumn(false)]
        [DataType(DataType.Date)]
        public DateTime ModifiedDate { get; set; }
        public int Category_Id { get; set; }
        [ForeignKey("Category_Id")]
        public virtual Category Category { get; set; }
    }
}
