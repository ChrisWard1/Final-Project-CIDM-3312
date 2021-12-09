using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PersonAddresses.Models
{
    public class Person
    {
        public int PersonID {get; set;}
        [Display(Name = "First Name")]
        [Required]
        public string FirstName {get; set;}
        [Display(Name = "Last Name")]
        [Required]
        public string LastName {get; set;}
        public int Age {get;set;}
        public char gender {get;set;}
        public string bDate {get;set;}
        public List<PersonAddress> PersonAddressses {get; set;} // Navigation Property. Student can have MANY PersonAddresses

    }
}