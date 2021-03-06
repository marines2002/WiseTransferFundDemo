namespace TransferWiseClient.Models
{
    public class TransferStatusResponseDetails
    {
        public string reference { get; set; }
    }

    public class TransferStatusResponse
    {
        public int id { get; set; }
        public int user { get; set; }
        public int targetAccount { get; set; }
        public object sourceAccount { get; set; }
        public string quote { get; set; }
        public string status { get; set; }
        public string reference { get; set; }
        public double rate { get; set; }
        public string created { get; set; }
        public object business { get; set; }
        public object transferRequest { get; set; }
        public TransferStatusResponseDetails details { get; set; }
        public bool hasActiveIssues { get; set; }
        public string sourceCurrency { get; set; }
        public double sourceValue { get; set; }
        public string targetCurrency { get; set; }
        public double targetValue { get; set; }
        public string customerTransactionId { get; set; }
    }

}
