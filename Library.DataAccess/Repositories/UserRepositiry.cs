using Library.DataAccess.Contexts;
using Library.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace Library.DataAccess.Repositories;

public class UserRepositiry:IUserRepositiry
{
    private readonly LibraryDbContext LibraryDbContext;

    public UserRepositiry(LibraryDbContext dbContext)
    {
        this.LibraryDbContext = dbContext;
    }

    async Task IUserRepositiry.Create(UserEntity entity)
    {
        LibraryDbContext.Users.Add(entity);
        await LibraryDbContext.SaveChangesAsync();
    }

    Task<UserEntity> IUserRepositiry.GetUserByEmail(string email) =>
        LibraryDbContext.Users.FirstOrDefaultAsync(x => x.Email == email);
}