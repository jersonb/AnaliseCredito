using System.Collections.Generic;
using System.Net;

namespace CreditApplication.Api
{
    public class Reproved : Result
    {
        public Reproved(IEnumerable<string> messages) : base(false, null, HttpStatusCode.UnprocessableEntity, messages)
        {
        }
    }
}