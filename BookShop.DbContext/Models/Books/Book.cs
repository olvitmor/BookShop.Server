namespace BookShop.DbContext.Models.Books;

public class Book
{
    /// <summary>
    /// Unique book id
    /// </summary>
    public Guid Id { get; set; } = Guid.NewGuid();

    /// <summary>
    /// Book name
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Book description
    /// </summary>
    public string? Description { get; set; }

    public void Apply(Book from)
    {
        Name = from.Name;
        Description = from.Description;
    }
}