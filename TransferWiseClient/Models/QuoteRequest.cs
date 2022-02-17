namespace TransferWiseClient.Models
{
    public class QuoteRequest
    {
        public string sourceCurrency { get; set; }
        public string targetCurrency { get; set; }
        public int sourceAmount { get; set; }
        public object targetAmount { get; set; }
        public int profile { get; set; }
    }
}
