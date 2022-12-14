namespace Api.Entities.Exceptions
{
    public class UnauthorizedIdRequest : ApplicationException
    {
        public UnauthorizedIdRequest(string message) : base(message)
        {
        }
    }
}
