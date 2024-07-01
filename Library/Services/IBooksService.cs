using Library.Models;

namespace Library.Services;
public interface IBooksService
{
    BookModel[] GetAll();
    BookModel GetById(int id);
    AuthorModel[] GetAuthors();
    PublisherModel[] GetPublisher();
    void Create(BookModel model);
    void Update(BookModel model);
    void Delete(int id);
}
