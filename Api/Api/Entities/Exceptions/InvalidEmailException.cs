namespace Api.Entities.Exceptions
{
    public class InvalidEmailException : ApplicationException
    {
        public InvalidEmailException(string message) : base(message)
        {
        }
    }
}
