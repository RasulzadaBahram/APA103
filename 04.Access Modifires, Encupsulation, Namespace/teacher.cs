using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.Access_Modifires__Encupsulation__Namespace
{
    internal class teacher
    {

        public string name;
        private string lastname;


        public teacher()
        {

        }
        public teacher(string name) : this()
        {
            this.name = name;
        }
        public teacher(string name, string lastname) : this(name)
        {
            this.lastname = lastname;
        }

        public string TeacherInfo() 
        {
            return $"Name: {name} Lastname: {lastname}";
        }


    }
}
