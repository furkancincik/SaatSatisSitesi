using SaatSatisSitesi.Models;

public class Comment
{
    public int Id { get; set; }
    public string Content { get; set; } = string.Empty;
    public int UserId { get; set; }
    public User User { get; set; } = new User();
    public int ProductId { get; set; }
    public Product Product { get; set; } = new Product();
}
