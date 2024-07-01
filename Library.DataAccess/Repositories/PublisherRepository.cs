using Library.DataAccess.Contexts;
using Library.DataAccess.Entities;

namespace Library.DataAccess.Repositories;
public class PublisherRepository : IPublisherRepository
{
    private readonly BooksDbContext booksDbContext;

    public PublisherRepository(BooksDbContext booksDbContext)
    {
        this.booksDbContext = booksDbContext;
    }

    public PublisherEntity[] GetAll()
    {
        return booksDbContext.Publishers.ToArray();
    }
}
