using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;

namespace PersonAddresses.Models
{
    public class Address
    {
        public int AddressID {get; set;} // Primary Key
        
        public string street {get; set;}
        public string city {get;set;}
        public string state {get; set;}
        public int zipCode {get; set;}
        public Person Person {get; set;} 
        
        public List<PersonAddress> PersonAddress {get; set;} 
    }


}