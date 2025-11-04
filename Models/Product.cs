namespace ODataDemo.Models;

public class Product
{
    public int Id { get; set; }            // key OData
    public string Name { get; set; } = "";
    public decimal Price { get; set; }
    public int? CategoryId { get; set; }
    public Category? Category { get; set; }
}