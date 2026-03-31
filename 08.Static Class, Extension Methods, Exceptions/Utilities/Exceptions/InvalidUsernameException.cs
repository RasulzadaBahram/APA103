using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08.Static_Class__Extension_Methods__Exceptions.Utilities.Exceptions
{
    internal class InvalidUsernameException:Exception
    {

        public InvalidUsernameException()
        {

        }
        public InvalidUsernameException(string message):base(message)
        {

        }

    }
}
