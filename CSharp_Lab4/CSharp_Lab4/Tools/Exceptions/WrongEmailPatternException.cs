
namespace CSharp_Lab4.Tools.Exceptions
{
    class WrongEmailPatternException : PersonDataException
    {
        public WrongEmailPatternException() { }
        public WrongEmailPatternException(string message) : base(message) { }
        public WrongEmailPatternException(string message, System.Exception inner) : base(message, inner) { }
    }
}
