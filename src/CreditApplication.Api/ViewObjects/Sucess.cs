using System.Net;

namespace CreditApplication.Api
{
    public class Sucess : Result
    {
        public Sucess(object data) : base(true, data, HttpStatusCode.Created, null)
        {
        }
    }
}