using AutoMapper;
using Library.DataAccess.Entities;
using Library.DataAccess.Repositories;
using AngularLibrary.Server.Models;

namespace AngularLibrary.Server.Services;
public class BooksService : IBooksService
{
    private readonly IBookRepository bookRepository;
    private readonly IAuthorRepository authorRepository;
    private readonly IPublisherRepository publisherRepository;
    private readonly IMapper mapper;

    public BooksService(IBookRepository bookRepository, IAuthorRepository authorRepository, IPublisherRepository publisherRepository, IMapper mapper)
    {
        this.bookRepository = bookRepository;
        this.authorRepository = authorRepository;
        this.publisherRepository = publisherRepository;
        this.mapper = mapper;
    }

    public void Create(BookModel model)
    {
        bookRepository.Create(mapper.Map<BookEntity>(model));
    }

    public void Delete(int id)
    {
        bookRepository.Delete(id);
    }

    public BookModel[] GetAll()
    {
        return mapper.Map<BookModel[]>(bookRepository.GetAll());
    }

    public BookModel GetById(int id)
    {
        var entity = bookRepository.GetById(id);
        return mapper.Map<BookModel>(entity);
    }

    public AuthorModel[] GetAuthors()
    {
        return mapper.Map<AuthorModel[]>(authorRepository.GetAll());
    }

    public PublisherModel[] GetPublisher()
    {
        return mapper.Map<PublisherModel[]>(publisherRepository.GetAll());
    }

    public void Update(BookModel model)
    {
        var oldEntity = bookRepository.GetById(model.Id);
        if (oldEntity == null) return;
        oldEntity.Name = model.Name;
        oldEntity.Genre = model.Genre;
        oldEntity.Year = model.Year;
        oldEntity.PublisherId = model.Publisher.Id;
        oldEntity.AuthorId = model.Author.Id;

        bookRepository.Update(oldEntity);
    }
}
