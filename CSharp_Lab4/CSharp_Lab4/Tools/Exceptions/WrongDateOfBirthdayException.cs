using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_Lab4.Tools.Exceptions
{
    class WrongDateOfBirthdayException : PersonDataException
    {
        public WrongDateOfBirthdayException() { }
        public WrongDateOfBirthdayException(string message) : base(message) { }
        public WrongDateOfBirthdayException(string message, System.Exception inner) : base(message, inner) { }
    }
}
