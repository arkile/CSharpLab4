
namespace CSharp_Lab4.Tools.Exceptions
{
    class WrongNameException : PersonDataException
    {
        public WrongNameException() { }
        public WrongNameException(string message) : base(message) { }
        public WrongNameException(string message, System.Exception inner) : base(message, inner) { }
    }
}
