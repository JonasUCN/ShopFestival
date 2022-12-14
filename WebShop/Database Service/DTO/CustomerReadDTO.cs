namespace Database_Service.DTO
{
    /// <summary>
    /// Data transfer object for representing customer data in the application
    /// </summary>
    public class CustomerReadDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ZipCode { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string StreetNo { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string userID { get; internal set; }
    }
}
