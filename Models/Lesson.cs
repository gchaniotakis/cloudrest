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
        [DataMember(Name ="id")]
        public int Id { get; set; }
        [DataMember(Name ="title")]
        public string Title { get; set; }
    }
}