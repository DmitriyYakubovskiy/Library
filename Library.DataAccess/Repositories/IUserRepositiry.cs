using Library.DataAccess.Entities;

namespace Library.DataAccess.Repositories;

public interface IUserRepositiry
{
    public Task<UserEntity> GetUserByEmail(string email);
    public Task Create(UserEntity entity);
}
