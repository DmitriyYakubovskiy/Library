using Library.DataAccess.Contexts;
using Library.DataAccess.Entities;

namespace Library.DataAccess.Repositories;
public class AuthorRepository : IAuthorRepository
{
    private readonly LibraryDbContext libraryDbContext;

    public AuthorRepository(LibraryDbContext booksDbContext)
    {
        this.libraryDbContext = booksDbContext;
    }

    public AuthorEntity[] GetAll()
    {
        return libraryDbContext.Authors.ToArray();
    }
}
