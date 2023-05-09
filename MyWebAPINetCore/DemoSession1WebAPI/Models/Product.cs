namespace DemoSession1WebAPI.Models;

public class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
    public bool Status { get; set; }
    public double Price { get; set; }
    public int Quantity { get; set; }
    public DateTime Created { get; set; }
}
