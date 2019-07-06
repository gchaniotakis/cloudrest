using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace cloudrest.Models
{
    [DataContract]
    public class Lesson
    {
        public int Id { get; set; }
        public string Title { get; set; }
    }
}