
public class Categorie
{
    public int CategoryId { get; set; }
    public required string CategoryName { get; set; }
    public required string Description { get; set; }

}

public class Products
{
    public int ProductId { get; set; }
    public string ProductName { get; set; } = "";
    public int SupplierId { get; set; }
    public int CategoryId { get; set; }
    public required string QuantityPerUnit { get; set; }
    public int UnitPrice { get; set; }
    public int UnitsInStock { get; set; }
    public int UnitsOnOrder { get; set; }
    public int ReorderLevel { get; set; }
    public int Discontinued { get; set; }
    public virtual Categorie? Categorie { get; set; } = null;
}
