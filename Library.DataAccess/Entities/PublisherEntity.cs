namespace Library.DataAccess.Entities;
public class PublisherEntity
{
    public int Id { get; set; }
    public string Name { get; set; }
    public virtual ICollection<BookEntity> Books { get; set; } = new List<BookEntity>();    
}
