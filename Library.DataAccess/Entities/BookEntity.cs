namespace Library.DataAccess.Entities;
public class BookEntity
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string Genre { get; set; } = null!;
    public string Year { get; set; } = null!;
    public int AuthorId { get; set; }
    public int PublisherId { get; set; }
    public virtual AuthorEntity Author { get; set; } = null!;
    public virtual PublisherEntity Publisher { get; set; } = null!;
}
