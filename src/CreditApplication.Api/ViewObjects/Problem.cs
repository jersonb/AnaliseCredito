using System.Net;

namespace CreditApplication.Api
{
    public class Problem : Result
    {
        public Problem(string message) : base(false, null, HttpStatusCode.BadRequest, new string[] { message })
        {
        }
    }
}