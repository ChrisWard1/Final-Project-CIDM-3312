using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;


namespace PersonAddresses.Models
{
    public class Person
    {   
        public int PersonID {get; set;}

               
        public string FirstName {get; set;}
        
               
        public string LastName {get; set;}
        public int Age {get;set;}
        public char gender {get;set;}
        public string bDate {get;set;}
         
        public List<PersonAddress> PersonAddresss {get; set;}

    }
        public class PersonAddress
    {
        public int AddressID {get; set;}     
        public int PersonID {get; set;}   
        public Person Person {get; set;} 
        public Address Address {get; set;}  
    }
}