namespace MVC_Web_App.Models
{
    public class Contact
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public int ContactGroupId { get; set; } 
        public ContactGroup ContactGroup { get; set; }
    }

    public class ContactGroup
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Contact> Contacts { get; set; } = new();
    }
}
