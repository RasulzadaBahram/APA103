using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08.Static_Class__Extension_Methods__Exceptions.Utilities.Exceptions
{
    internal class IncorrectPasswordException:Exception
    {
        public int AttempsLeft { get; set; }
        public IncorrectPasswordException()
        {

        }
        public IncorrectPasswordException(int attempsLeft)
        {
            AttempsLeft=attempsLeft;
            Console.WriteLine(attempsLeft);
        }

    }
}
