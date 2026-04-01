using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09.Upcasting_and_Downcasting__Explicit_and_Implicit.Models
{
    internal class Teacher:Person
    {
        public string ClassOwner { get; set; }
        public int Salary { get; set; }
    }
}
