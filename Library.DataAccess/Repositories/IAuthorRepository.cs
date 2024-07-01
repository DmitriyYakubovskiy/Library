using Library.DataAccess.Entities;

namespace Library.DataAccess.Repositories;
public interface IAuthorRepository
{
    AuthorEntity[] GetAll();
}
