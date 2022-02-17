using System.Collections.Generic;

namespace TransferWiseClient.Models
{
    public class Name
    {
        public string fullName { get; set; }
        public object givenName { get; set; }
        public object familyName { get; set; }
        public object middleName { get; set; }
        public object patronymicName { get; set; }
        public object cannotHavePatronymicName { get; set; }
    }

    public class RecipientDetails
    {
        public string iban { get; set; }
        public object bic { get; set; }
        public string hashedByLooseHashAlgorithm { get; set; }
    }

    public class CommonFieldMap
    {
        public string accountNumberField { get; set; }
        public string bankCodeField { get; set; }
        public string bicField { get; set; }
    }

    public class DisplayField
    {
        public string label { get; set; }
        public string value { get; set; }
    }

    public class Content
    {
        public int id { get; set; }
        public int creatorId { get; set; }
        public int profileId { get; set; }
        public Name name { get; set; }
        public string currency { get; set; }
        public string country { get; set; }
        public string type { get; set; }
        public string legalEntityType { get; set; }
        public string email { get; set; }
        public bool active { get; set; }
        public RecipientDetails details { get; set; }
        public CommonFieldMap commonFieldMap { get; set; }
        public bool isDefaultAccount { get; set; }
        public string hash { get; set; }
        public string accountSummary { get; set; }
        public string longAccountSummary { get; set; }
        public List<DisplayField> displayFields { get; set; }
        public bool ownedByCustomer { get; set; }
    }

    public class Sort
    {
        public bool empty { get; set; }
        public bool unsorted { get; set; }
        public bool sorted { get; set; }
    }

    public class RecipientsResponse
    {
        public List<Content> content { get; set; }
        public Sort sort { get; set; }
        public int size { get; set; }
    }
}
