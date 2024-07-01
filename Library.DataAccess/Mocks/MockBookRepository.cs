using Library.DataAccess.Entities;
using Library.DataAccess.Repositories;

namespace Library.DataAccess.Mocks;
public class MockBookRepository : IBookRepository
{
    public void Create(BookEntity entity)
    {
        throw new NotImplementedException();
    }

    public void Delete(int id)
    {
        throw new NotImplementedException();
    }

    public BookEntity[] GetAll()
    {
        return new BookEntity[]
        {
            new()
            {
                Id=1,
                Name="Преступление и наказание",
                Genre="Роман",
                Year="1865",
                AuthorId=1,
                PublisherId=1,
            },
            new()
            {
                Id= 2,
                Name="Герой нашего времени",
                Genre="Психологический роман",
                Year="1837",
                AuthorId=2,
                PublisherId=1,
            },
            new()
            {
                Id=3,
                Name="В аптеке",
                Genre="Рассказ",
                Year="1885",
                AuthorId=4,
                PublisherId=1,
            },
            new()
            {
                Id=4,
                Name="Чудесный доктор",
                Genre = "Рассказ",
                Year="1897",
                AuthorId=3,
                PublisherId=1,
            },
        };
    }

    public BookEntity GetBookById(int bookId)
    {
        throw new NotImplementedException();
    }

    public BookEntity GetById(int id)
    {
        throw new NotImplementedException();
    }

    public void Update(BookEntity entity)
    {
        throw new NotImplementedException();
    }
}
