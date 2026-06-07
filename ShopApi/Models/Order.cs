namespace ShopApi.Models;

public class Order
{
    public int OrderId { get; set; }
    public DateTime OrderDate { get; set; }
    public String Status { get; set; }
    public double TotalAmount { get; set; }
    public ICollection<Payment> Payments { get; set; }
    public ICollection<OrderItem> OrderItems { get; set; }
}