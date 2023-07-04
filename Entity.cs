using System.ComponentModel.DataAnnotations;

namespace APIApp
{
    public class Categorie
    {
        [Key]
        public int CategoryId { get; set; }
        public required string CategoryName { get; set; }
        public required string Description { get; set; }
    }

    public class Products
    {
        [Key]
        public required int ProductId { get; set; }
        public required string ProductName { get; set; } = "";
        public int SupplierId { get; set; }
        public required int CategoryId { get; set; }
        public required string QuantityPerUnit { get; set; }
        public int UnitPrice { get; set; }
        public int UnitsInStock { get; set; }
        public int UnitsOnOrder { get; set; }
        public int ReorderLevel { get; set; }
        public int Discontinued { get; set; }
    }
}
