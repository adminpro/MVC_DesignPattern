using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Models.LessionLearn
{
    public class Chapter:BaseEntity<int>
    {
        [MaxLength(50)]
        public string Name { get; set; }
        [MaxLength(500)]
        public string Description { get; set; }
        public int TopicGroupId { get; set; }
        [ForeignKey("TopicGroupId")]
        public TopicGroup TopicGroup { get; set; }
    }
}
