using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace cloudrest.Models
{
    public class User
    {
        public User()
        {
            this.TeacherSelections = new HashSet<Selection>();
            this.StudentSelections = new HashSet<Selection>();
        }

        public int UserId { get; set; }
        [Required]
        [Display(Name = "Full Name")]
        public string UserName { get; set; }

        [Required]
        [Display(Name = "Role")]
        [EnumDataType(typeof(Role))]
        public Role UserRole { get; set; }

        public ICollection<Selection> TeacherSelections { get; set; }
        public ICollection<Selection> StudentSelections { get; set; }
    }

    public enum Role
    {
        Teacher,
        Student
    }
}