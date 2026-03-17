using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.Object__Class__Constructor__Inheritance__this_vs_base_keywords.Models
{
    class Administrator:Person
    {
        string Position;
        string Department;
        int AccessLevel;




        public Administrator()
        {

        }
        public Administrator(string position) : this()
        {
            Position = position;
        }
        public Administrator(string position, string department) : this(position)
        {
            Department = department;
        }
        public Administrator(string position, string department, int accesslevel) : this(position, department)
        {
            AccessLevel = accesslevel;
        }


        public Administrator(string firstname, string lastname, int age, string email,int id):base(firstname,lastname,age,email,id)
        {

        }




        public void ShowAdminInfo()
        {
            Console.WriteLine($"{Position} {Department} {AccessLevel}");
        }

        public void GrantAccess(Student student)
        {
            Console.WriteLine($"{Firstname}{Lastname} sisteme icaze verildi");
        }



    }
}
