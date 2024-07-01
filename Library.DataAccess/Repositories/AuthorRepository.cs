using Library.DataAccess.Contexts;
using Library.DataAccess.Entities;

namespace Library.DataAccess.Repositories;
public class AuthorRepository : IAuthorRepository
{
    private readonly BooksDbContext booksDbContext;

    public AuthorRepository(BooksDbContext booksDbContext)
    {
        this.booksDbContext = booksDbContext;
    }

    public AuthorEntity[] GetAll()
    {
        return booksDbContext.Authors.ToArray();
    }
}
