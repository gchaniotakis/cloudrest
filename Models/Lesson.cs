using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace cloudrest.Models
{
  
    public class Lesson
    {
        public Lesson()
        {
            this.Selection = new HashSet<Selection>();
        }

        public int LessonId { get; set; }

        [Required]
        [Display(Name ="Lesson Title")]
        public string LessonTitle { get; set; }

        public ICollection<Selection> Selection { get; set; }
    }
}