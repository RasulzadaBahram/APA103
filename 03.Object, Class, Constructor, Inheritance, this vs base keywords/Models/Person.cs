    using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.Object__Class__Constructor__Inheritance__this_vs_base_keywords.Models
{
    class Person
    {
        public string Firstname;
        public string Lastname;
        public int Age;
        public string Email;
        public int Id;




        public Person()
        {

        }
        public Person(string firstname) : this()
        {
            Firstname = firstname;
        }
        public Person(string firstname, string lastname) : this(firstname)
        {
            Lastname = lastname;
        }
        public Person(string firstname, string lastname, int age) : this(firstname, lastname)
        {
            Age = age;
        }
        public Person(string firstname, string lastname, int age, string email) : this(firstname, lastname, age)
        {
            Email = email;
        }
        public Person(string firstname, string lastname, int age, string email, int id) : this(firstname, lastname, age, email)
        {
            Id = id;
        }

        public string GetFullName()
        {

            return $"{Firstname} {Lastname}";
        }

        public void ShowBasicInfo()
        {
            Console.WriteLine( $"{Id} {Email} {Age}");
        }



    }


}
