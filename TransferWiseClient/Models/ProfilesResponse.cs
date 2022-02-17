namespace TransferWiseClient.Models
{
    public class Details
    {
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string dateOfBirth { get; set; }
        public string phoneNumber { get; set; }
        public object avatar { get; set; }
        public object occupation { get; set; }
        public object occupations { get; set; }
        public int primaryAddress { get; set; }
        public object firstNameInKana { get; set; }
        public object lastNameInKana { get; set; }
        public string name { get; set; }
        public string registrationNumber { get; set; }
        public object acn { get; set; }
        public object abn { get; set; }
        public object arbn { get; set; }
        public string companyType { get; set; }
        public string companyRole { get; set; }
        public string descriptionOfBusiness { get; set; }
        public object webpage { get; set; }
        public string businessCategory { get; set; }
        public object businessSubCategory { get; set; }
    }

    public class Detail
    {
        public int id { get; set; }
        public string type { get; set; }
        public Details details { get; set; }
    }
}
