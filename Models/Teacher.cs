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
        [DataMember(Name ="id")]
        public int Id { get; set; }
        [DataMember(Name = "firstname")]
        public string FirstName {get; set;}
        [DataMember(Name ="lastname")]
        public string LastName { get; set; }
    }
}