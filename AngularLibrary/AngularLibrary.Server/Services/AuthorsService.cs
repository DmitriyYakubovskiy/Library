using AngularLibrary.Server.Models;
using AutoMapper;
using Library.DataAccess.Repositories;

namespace AngularLibrary.Server.Services;
public class AuthorsService : IAuthorsService
{
    private readonly IAuthorRepository authorRepository;
    private readonly IMapper mapper;

    public AuthorsService(IAuthorRepository authorRepository, IMapper mapper)
    {
        this.authorRepository = authorRepository;
        this.mapper = mapper;
    }

    public AuthorModel[] GetAll()
    {
        return mapper.Map<AuthorModel[]>(authorRepository.GetAll());
    }

    public AuthorModel GetById(int id)
    {
        throw new NotImplementedException();
    }

    public void Create(AuthorModel model)
    {
        throw new NotImplementedException();
    }

    public void Update(AuthorModel model)
    {
        throw new NotImplementedException();
    }

    public void Delete(int id)
    {
        throw new NotImplementedException();
    }
}
