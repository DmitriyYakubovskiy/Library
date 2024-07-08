using AngularLibrary.Server.Models;
using AutoMapper;
using Library.DataAccess.Repositories;

namespace AngularLibrary.Server.Services;
public class PublishersService : IPublishersService
{
    private readonly IPublisherRepository publisherRepository;
    private readonly IMapper mapper;

    public PublishersService(IPublisherRepository publisherRepository, IMapper mapper)
    {
        this.publisherRepository = publisherRepository;
        this.mapper = mapper;
    }

    public void Create(PublisherModel model)
    {
        throw new NotImplementedException();
    }

    public void Delete(int id)
    {
        throw new NotImplementedException();
    }

    public PublisherModel[] GetAll()
    {
        return mapper.Map<PublisherModel[]>(publisherRepository.GetAll());
    }

    public PublisherModel GetById(int id)
    {
        throw new NotImplementedException();
    }

    public void Update(PublisherModel model)
    {
        throw new NotImplementedException();
    }
}
