namespace BusinessManager.Models
{
    public class BillingInfo
    {
        public int Id { get; set; }
        public string OfficialName { get; set; }
        public string BillingAddress { get; set; }
        public int CompanyRegistryNumber { get; set; }
        public int TaxNumber { get; set; }
        public Client Client { get; set; }
    }
}