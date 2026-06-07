namespace ShopApi.Models;

public class OrderItem
{
    public int OrderId {get; set;}
    public int ProductId {get; set;}
    public int Quantity {get; set;}
    public double Price {get; set;}

    public Product Product {get; set;}
    public Order Order {get; set;}
    
    public ICollection<Order> Orders {get; set;}
    public ICollection<Product> Products {get; set;}
}