namespace ShopApi.Models;

public class Payment
{
    public int PaymentId {get; set;}
    public String PaymentMethod {get; set;}
    public double Amount {get; set;}
    public String PaymentStatus {get; set;}
    public Order Order {get; set;}
    public int OrderId {get; set;}
    
}