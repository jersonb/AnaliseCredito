using System.Net;

namespace CreditApplication.Api
{
    public class NotFound : Result
    {
        public NotFound(object data) : base(false, data, HttpStatusCode.NotFound, null)
        {
        }
    }
}