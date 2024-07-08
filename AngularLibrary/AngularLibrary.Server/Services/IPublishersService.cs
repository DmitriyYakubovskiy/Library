using AngularLibrary.Server.Models;

namespace AngularLibrary.Server.Services;
public interface IPublishersService
{
    public PublisherModel[] GetAll();
    public PublisherModel GetById(int id);
    public void Create(PublisherModel model);
    public void Update(PublisherModel model);
    public void Delete(int id);
}
