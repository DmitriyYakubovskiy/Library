using Library.DataAccess.Entities;

namespace Library.DataAccess.Repositories;
public interface IBookRepository
{
    BookEntity[] GetAll();
    BookEntity GetById(int id);
    void Create(BookEntity entity);
    void Update(BookEntity entity);
    void Delete(int id);
}
