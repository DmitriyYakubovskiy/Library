using Library.DataAccess.Entities;
using Library.DataAccess.Repositories;

namespace Library.DataAccess.Mocks;
public class MockAuthorRepository : IAuthorRepository
{
    public AuthorEntity[] GetAll()
    {
        return new AuthorEntity[]
        {
            new()
            {
                Id=1,
                FirstName = "Федор",
                LastName="Достоевский"
            },
            new()
            {
                Id=2,
                FirstName="Михаил",
                LastName="Лермонтов"
            },
            new()
            {
                Id=3,
                FirstName="Александр",
                LastName="Куприн"
            },
            new()
            {
                Id=4,
                FirstName="Антон",
                LastName="Чехов"
            }
        };
    }

    public AuthorEntity GetAuthorById(int authorId)
    {
        throw new NotImplementedException();
    }
}
