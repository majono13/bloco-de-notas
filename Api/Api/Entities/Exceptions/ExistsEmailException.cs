namespace Api.Entities.Exceptions
{
    public class ExistsEmailException : ApplicationException
    {
        public ExistsEmailException(string message) : base(message)
        {
        }
    }
}
