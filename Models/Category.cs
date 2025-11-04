namespace ODataDemo.Models;

public class Category
{
    public int Id { get; set; }            // key OData
    public string Title { get; set; } = "";
    public ICollection<Product> Products { get; set; } = new List<Product>();
}