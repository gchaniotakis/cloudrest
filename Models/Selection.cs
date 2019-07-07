using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace cloudrest.Models
{
    public class Selection
    {
        public int SelectionId { get; set; }
        public int TeacherId { get; set; }
        public int? StudentId { get; set; }
        public int LessonId { get; set; }

        public Lesson Lesson { get; set; }
        public User Teacher { get; set; }
        public User Student { get; set; }
    }
}