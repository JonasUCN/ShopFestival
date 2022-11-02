namespace Database_Service.DataAccess
{
    public abstract class Product
    {
        public Product(decimal price, int stock, string productDesc, string brand, string title)
        {
            Price = price;
            Stock = stock;
            ProductDesc = productDesc;
            Brand = brand;
            Title = title;
        }

        public int id { get; set; }
        public decimal Price { get; set; }

        public int Stock { get; set; }

        public string ProductDesc { get; set; }

        public string Brand { get; set; }
        public string  Title { get; set; }


    }
}