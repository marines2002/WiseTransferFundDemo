using System;
using System.Collections.Generic;

namespace TransferWiseClient.Models
{
    public class Fee
    {
        public double transferwise { get; set; }
        public double payIn { get; set; }
        public int discount { get; set; }
        public double total { get; set; }
        public int priceSetId { get; set; }
        public double partner { get; set; }
    }

    public class Value
    {
        public double amount { get; set; }
        public string currency { get; set; }
        public string label { get; set; }
    }

    public class Total
    {
        public string type { get; set; }
        public string label { get; set; }
        public Value value { get; set; }
    }

    public class Item
    {
        public string type { get; set; }
        public string label { get; set; }
        public Value value { get; set; }
    }

    public class Price
    {
        public int priceSetId { get; set; }
        public Total total { get; set; }
        public List<Item> items { get; set; }
    }

    public class PaymentOption
    {
        public string formattedEstimatedDelivery { get; set; }
        public List<object> estimatedDeliveryDelays { get; set; }
        public List<string> allowedProfileTypes { get; set; }
        public string payInProduct { get; set; }
        public double feePercentage { get; set; }
        public DateTime estimatedDelivery { get; set; }
        public string targetCurrency { get; set; }
        public string sourceCurrency { get; set; }
        public double sourceAmount { get; set; }
        public double targetAmount { get; set; }
        public string payOut { get; set; }
        public bool disabled { get; set; }
        public Fee fee { get; set; }
        public Price price { get; set; }
        public string payIn { get; set; }
    }

    public class HighAmount
    {
        public bool showFeePercentage { get; set; }
        public bool trackAsHighAmountSender { get; set; }
        public bool showEducationStep { get; set; }
        public bool offerPrefundingOption { get; set; }
        public bool overLimitThroughCs { get; set; }
    }

    public class TransferFlowConfig
    {
        public HighAmount highAmount { get; set; }
    }

    public class QuoteResponse
    {
        public double sourceAmount { get; set; }
        public bool guaranteedTargetAmountAllowed { get; set; }
        public bool targetAmountAllowed { get; set; }
        public List<PaymentOption> paymentOptions { get; set; }
        public List<object> notices { get; set; }
        public TransferFlowConfig transferFlowConfig { get; set; }
        public DateTime rateTimestamp { get; set; }
        public string clientId { get; set; }
        public string id { get; set; }
        public string type { get; set; }
        public string targetCurrency { get; set; }
        public string status { get; set; }
        public int profile { get; set; }
        public int rate { get; set; }
        public string sourceCurrency { get; set; }
        public DateTime createdTime { get; set; }
        public int user { get; set; }
        public string rateType { get; set; }
        public DateTime rateExpirationTime { get; set; }
        public string payOut { get; set; }
        public bool guaranteedTargetAmount { get; set; }
        public string providedAmountType { get; set; }
        public DateTime expirationTime { get; set; }
        public string payInCountry { get; set; }
        public string funding { get; set; }
    }

}
