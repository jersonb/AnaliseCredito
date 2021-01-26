using System.Collections.Generic;
using System.Net;

namespace CreditApplication.Api
{
    public abstract class Result
    {
        protected Result(bool sucess, object data, HttpStatusCode statusCode, IEnumerable<string> messages)
        {
            Sucess = sucess;
            Data = data;
            Messages = messages;
            HttpStatus = statusCode;
        }

        public bool Sucess { get; }
        public object Data { get; }
        public int StatusCode => (int)HttpStatus;
        public IEnumerable<string> Messages { get; }
        private HttpStatusCode HttpStatus { get; }
    }
}