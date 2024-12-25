public class OrderDetail
{
    public int Id { get; set; }
    public int OrderId { get; set; }
    public Order Order { get; set; } = new Order();
    public int ProductId { get; set; }
    public Product Product { get; set; } = new Product();
    public int Quantity { get; set; }
    public decimal TotalPrice { get; set; }
}
