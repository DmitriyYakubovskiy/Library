using AngularLibrary.Server.Models;

namespace AngularLibrary.Server.Services;
public interface IAuthorsService
{
    public AuthorModel[] GetAll();
    public AuthorModel GetById(int id);
    public void Create(AuthorModel model);
    public void Update(AuthorModel model);
    public void Delete(int id);
}
