using Library.DataAccess.Entities;

namespace Library.DataAccess.Repositories;
public interface IPublisherRepository
{
    PublisherEntity[] GetAll();
}
