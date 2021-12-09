using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PersonAddresses.Models
{
    public class Address
    {
        public int AddressID {get; set;} // Primary Key
        [Required]
        public string street {get; set;}
        public string city {get;set;}
        public string state {get; set;}
        public int zipCode {get; set;}
        public List<PersonAddress> PersonAddresses {get; set;} // Navigation Property. Course can have MANY StudentCourses
    }

    public class PersonAddress
    {
        public int AddressID {get; set;}     // Composite Primary Key, Foreign Key 1
        public int PersonID {get; set;}    // Composite Primary Key, Foreign Key 2
        public Person Person {get; set;}  // Navigation Property. One Student per StudentCourse
        public Address Address {get; set;}    // Navigation Property. One Course per StudentCourse
    }
}