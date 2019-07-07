using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using cloudrest.Models;

namespace cloudrest.Dtos
{
    public class UserDto
    {
        public int UserId { get; set; }

        [Required]
        public string UserName { get; set; }

        [Required]
        public Role UserRole { get; set; }

    }
}