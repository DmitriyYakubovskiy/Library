using Library.DataAccess.Contexts;
using Library.DataAccess.Entities;

namespace Library.DataAccess.Repositories;
public class PublisherRepository : IPublisherRepository
{
    private readonly LibraryDbContext libraryDbContext;

    public PublisherRepository(LibraryDbContext booksDbContext)
    {
        this.libraryDbContext = booksDbContext;
    }

    public PublisherEntity[] GetAll()
    {
        return libraryDbContext.Publishers.ToArray();
    }
}
