using Library.DataAccess.Contexts;
using Library.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace Library.DataAccess.Repositories;
public class BookRepository : IBookRepository
{
    private readonly LibraryDbContext libraryDbContext;

    public BookRepository(LibraryDbContext booksDbContext)
    {
        this.libraryDbContext = booksDbContext;
    }

    public void Create(BookEntity model)
    {
        libraryDbContext.Books.Add(model);
        libraryDbContext.SaveChanges();
    }

    public void Delete(int id)
    {
        var entity = GetById(id);
        Console.WriteLine(entity.Genre);
        if (entity == null) return;
        libraryDbContext.Books.Remove(entity);
        libraryDbContext.SaveChanges();
    }

    public BookEntity[] GetAll()
    {
        return libraryDbContext.Books
                        .Include(x => x.Author)
                        .Include(x => x.Publisher)
                        .ToArray();
    }

    public BookEntity GetById(int id)
    {
        return libraryDbContext.Books
                        .Include(x => x.Author)
                        .Include(x => x.Publisher)
                        .FirstOrDefault(x => x.Id == id);
    }

    public void Update(BookEntity entity)
    {
        libraryDbContext.Update(entity);
        libraryDbContext.SaveChanges();
    }
}
