using SaatSatisSitesi.Models;

public class Order
{
    public int Id { get; set; }
    public DateTime OrderDate { get; set; }
    public int UserId { get; set; }
    public User User { get; set; } = new User();
    public List<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();
}
