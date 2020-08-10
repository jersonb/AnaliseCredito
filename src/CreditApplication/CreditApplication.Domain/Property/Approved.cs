namespace CreditApplication.Domain.Property
{
    public struct Approved
    {
        private Approved(string message = null)
        {
            Message = message ?? "Ok!";
            Value = message is null;
        }


       
        public static Approved Yes()
            => new Approved(null);
        
        public static Approved No(string message)
            => new Approved(message);

        public bool Value { get; }
        public string Message { get; }
    }
}
