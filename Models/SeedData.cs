using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PersonAddresses.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new Context(serviceProvider.GetRequiredService<DbContextOptions<Context>>()))
            {
                if (context.Persons.Any())
                {
                    return;
                }

                List<Person> Person = new List<Person> {
                    new Person {FirstName="Laurie", LastName="Cornfoot", Age= 22, gender='f', bDate="1999-12-02"},
                    new Person {FirstName="Conni", LastName="Spriggen",Age= 15, gender='f',bDate="1999-12-02"},
                    new Person {FirstName="Darsey", LastName="Pervoe", Age= 33, gender='f',bDate="1999-12-02"},
                    new Person {FirstName="Ninetta", LastName="Seccombe",Age= 88, gender='f',bDate="1999-12-02"},
                    new Person {FirstName="Sibilla", LastName="Louisot", Age= 44, gender='f',bDate="1999-12-02"},
                    new Person {FirstName="Harli", LastName="Jencken", Age= 55, gender='f',bDate="1999-12-02"},
                    new Person {FirstName="Lisa", LastName="Dorrian",Age= 38, gender='f',bDate="1999-12-02"},
                    new Person {FirstName="Cary", LastName="Witt", Age= 56, gender='m',bDate="1999-12-02"},
                    new Person {FirstName="Hallsy", LastName="Choppen",Age= 21, gender='f',bDate="1999-12-02"},
                    new Person {FirstName="Sanson", LastName="Feyer",Age= 23, gender='m',bDate="1999-12-02"},
                    new Person {FirstName="Stearn", LastName="Hutchason",Age= 47, gender='m',bDate="1999-12-02"},
                    new Person {FirstName="Hewet", LastName="Gamlen",Age= 66, gender='m',bDate="1999-12-02"},
                    new Person {FirstName="Sheffie", LastName="Dicte",Age= 13, gender='m',bDate="1999-12-02"},
                    new Person {FirstName="Dot", LastName="Ralton",Age= 15, gender='f',bDate="1999-12-02"},
                    new Person {FirstName="Drusi", LastName="MacGovern", Age= 77, gender='m',bDate="1999-12-02"},
                    new Person {FirstName="Izak", LastName="Rosenkranc", Age= 69, gender='m',bDate="1999-12-02"},
                    new Person {FirstName="Clarinda", LastName="Rolling", Age= 14, gender='f',bDate="1999-12-02"},
                    new Person {FirstName="Coleen", LastName="Forcade", Age= 33, gender='f',bDate="1999-12-02"},
                    new Person {FirstName="Gray", LastName="Madner", Age= 22, gender='f',bDate="1999-12-02"},
                    new Person {FirstName="Rowan", LastName="Bursnell",Age= 29, gender='m',bDate="1999-12-02"},
                    new Person {FirstName="Kipp", LastName="Kiddell", Age= 27, gender='m',bDate="1999-12-02"},
                    new Person {FirstName="Iosep", LastName="Morville", Age= 25, gender='m',bDate="1999-12-02"},
                    new Person {FirstName="Martyn", LastName="Bhar", Age= 41, gender='m',bDate="1999-12-02"},
                    new Person {FirstName="Antoinette", LastName="Hanhardt", Age= 44, gender='f',bDate="1999-12-02"},
                    new Person {FirstName="Thor", LastName="Candy", Age= 52, gender='m',bDate="1999-12-02"},
                    new Person {FirstName="Beryl", LastName="Spikings", Age= 54, gender='m',bDate="1999-12-02"},
                    new Person {FirstName="Margeaux", LastName="Sturzaker", Age= 37, gender='f',bDate="1999-12-02"},
                    new Person {FirstName="Horatio", LastName="Chessel", Age= 40, gender='m',bDate="1999-12-02"},
                    new Person {FirstName="Vasili", LastName="Dore", Age= 66, gender='m',bDate="1999-12-02"},
                    new Person {FirstName="Flemming", LastName="Magnay", Age= 99, gender='m',bDate="1999-12-02"},
                };
                context.AddRange(Person);

                List<Address> addresses = new List<Address> {
                    new Address {street = "6114 Leopard Rd", city="Ropesville", zipCode=79358},
                    new Address {street = "6116 Leopard Rd",city="Ropesville", zipCode=79358},
                    new Address {street = "3575 Mallard Rd",city="Ropesville", zipCode=79358},
                    new Address {street = "6112 Leopard Rd",city="Ropesville", zipCode=79358},
                    new Address {street = "6116 Leopard Rd",city="Ropesville", zipCode=79358},
                    new Address {street = "5223 109th St",city="Luubock", zipCode=79423},
                    new Address {street = "5226 109th St",city="Lubbock", zipCode=793423},
                };
                context.AddRange(addresses);

                List<PersonAddress> newAddress = new List<PersonAddress> {
                    new PersonAddress {AddressID = 1, PersonID = 1},
                    new PersonAddress {AddressID = 1, PersonID = 26},
                    new PersonAddress {AddressID = 1, PersonID = 5},
                    new PersonAddress {AddressID = 1, PersonID = 18},
                    new PersonAddress {AddressID = 1, PersonID = 2},
                    new PersonAddress {AddressID = 1, PersonID = 20},
                    new PersonAddress {AddressID = 1, PersonID = 25},
                    new PersonAddress {AddressID = 1, PersonID = 6},
                    new PersonAddress {AddressID = 1, PersonID = 27},

                    new PersonAddress {AddressID = 2, PersonID = 4},
                    new PersonAddress {AddressID = 2, PersonID = 2},
                    new PersonAddress {AddressID = 2, PersonID = 13},
                    new PersonAddress {AddressID = 2, PersonID = 11},
                    new PersonAddress {AddressID = 2, PersonID = 14},
                    new PersonAddress {AddressID = 2, PersonID = 10},
                    new PersonAddress {AddressID = 2, PersonID = 29},
                    new PersonAddress {AddressID = 2, PersonID = 7},
                    new PersonAddress {AddressID = 2, PersonID = 24},
                };
                context.AddRange(newAddress);

                context.SaveChanges();
            }
        }
    }
}