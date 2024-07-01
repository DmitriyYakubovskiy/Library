using Library.DataAccess.Contexts;
using Library.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace Library.DataAccess.Repositories;
public class BookRepository : IBookRepository
{
    private readonly BooksDbContext booksDbContext;

    public BookRepository(BooksDbContext booksDbContext)
    {
        this.booksDbContext = booksDbContext;
    }

    public void Create(BookEntity model)
    {
        booksDbContext.Books.Add(model);
        booksDbContext.SaveChanges();
    }

    public void Delete(int id)
    {
        var entity = GetById(id);
        Console.WriteLine(entity.Genre);
        if (entity == null) return;
        booksDbContext.Books.Remove(entity);
        booksDbContext.SaveChanges();
    }

    public BookEntity[] GetAll()
    {
        return booksDbContext.Books
                        .Include(x => x.Author)
                        .Include(x => x.Publisher)
                        .ToArray();
    }

    public BookEntity GetById(int id)
    {
        return booksDbContext.Books
                        .Include(x => x.Author)
                        .Include(x => x.Publisher)
                        .FirstOrDefault(x => x.Id == id);
    }

    public void Update(BookEntity entity)
    {
        booksDbContext.Update(entity);
        booksDbContext.SaveChanges();
    }
}
