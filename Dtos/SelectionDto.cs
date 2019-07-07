using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace cloudrest.Dtos
{
    public class SelectionDto
    {
        public int SelectionId { get; set; }

        [Required]
        public int TeacherId { get; set; }

        public int? StudentId { get; set; }

        [Required]
        public int LessonId { get; set; }
    }
}