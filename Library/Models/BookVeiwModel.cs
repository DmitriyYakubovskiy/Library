namespace Library.Models;
public class BookVeiwModel
{
    public BookModel Book { get; set; }
    public AuthorModel[] Authors { get; set; }  
    public PublisherModel[] Publishers { get; set; }
}
