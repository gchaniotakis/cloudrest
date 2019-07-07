using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace cloudrest.Dtos
{
    public class LessonDto
    {
        public int LessonId { get; set; }

        [Required]
        public string LessonTitle { get; set; }
    }
}