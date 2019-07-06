using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace cloudrest.Models
{
    [DataContract]
    public class Teacher
    {
        public int Id { get; set; }
        public string FirstName {get; set;}
        public string LastName { get; set; }
    }
}