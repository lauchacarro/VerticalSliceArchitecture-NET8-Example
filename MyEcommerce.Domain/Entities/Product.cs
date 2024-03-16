using MyEcommerce.Domain.Enums;

namespace MyEcommerce.Domain.Entities
{
    public class Product
    {
        public Product(string name, int stock, DateTime creationDate, ProductStatus status)
        {
            Name = name;
            Stock = stock;
            CreationDate = creationDate;
            Status = status;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int Stock { get; set; }
        public DateTime CreationDate { get; set; }
        public ProductStatus Status { get; set; }
    }
}
