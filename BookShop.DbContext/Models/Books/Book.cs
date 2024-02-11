namespace BookShop.DbContext.Models.Books;

public class Book
{
    public Guid Id { get; set; } = Guid.NewGuid();

    public string Name { get; set; }

    public string? Description { get; set; }
}