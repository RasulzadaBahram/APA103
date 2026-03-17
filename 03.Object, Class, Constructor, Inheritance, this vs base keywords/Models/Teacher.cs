using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.Object__Class__Constructor__Inheritance__this_vs_base_keywords.Models
{
    class Teacher:Person
    {
        string Department;
        string MainSubject;
        decimal BaseSalary;
        int ExperienceYears;



        public Teacher()
        {

        }
        public Teacher(string department):this()
        {
            Department = department;
        }
        public Teacher(string department, string mainsubject):this(department)
        {
            MainSubject = mainsubject;
        }
        public Teacher(string department, string mainsubject, decimal basesalary):this(department,mainsubject)
        {
            BaseSalary = basesalary;
        }

        public Teacher(string department, string mainsubject, decimal basesalary,int experienceyears)
        {
            ExperienceYears = experienceyears;
        }






        public string ShowTeacherInfo() 
        {
            return $"{Department}{MainSubject}{BaseSalary}{ExperienceYears}";
        }

        public decimal CalculateSalary() 
        {
            decimal total = BaseSalary + (50 * ExperienceYears);
            return total;
        }













    }
}
