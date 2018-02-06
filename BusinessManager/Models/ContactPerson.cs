namespace BusinessManager.Models
{
    public class ContactPerson
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Phone { get; set; }
        public string Email { get; set; }
        public Client Client { get; set; }
    }
}