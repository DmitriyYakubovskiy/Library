using AngularLibrary.Server.Models;

namespace AngularLibrary.Server.Services;
public interface IBooksService
{
    public BookModel[] GetAll();
    public BookModel GetById(int id);
    public AuthorModel[] GetAuthors();
    public PublisherModel[] GetPublisher();
    public void Create(BookModel model);
    public void Update(BookModel model);
    public void Delete(int id);
}
