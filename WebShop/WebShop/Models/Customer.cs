namespace WebShop.Models
{
    public class Customer
    {
        public string fname { get; set; }
        public string lname { get; set; }
        public string ZipCode { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string StreetNo { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string userID { get; internal set; }
    }
}
