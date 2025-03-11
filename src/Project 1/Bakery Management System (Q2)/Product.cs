namespace Bakery_Management_System
{
    public class Product
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public string Category { get; set; }
        public float Price { get; set; }
        public int QuantityInStock { get; set; }

        public Product()
        {
            ProductName = string.Empty; // Prevent NullReferenceException
            Category = string.Empty;
        }
    }
}
