namespace Library.Models;
public class BookModel
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Genre { get; set; }
    public string Year { get; set; }
    public AuthorModel Author { get; set; }
    public PublisherModel Publisher { get; set; }
}
