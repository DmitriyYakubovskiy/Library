using Library.Models;

namespace Library.Services;

public interface IUserService
{
    public Task<bool> Register(RegisterModel registerModel);
    public Task<bool> Login(LoginModel loginModel);
    public Task<bool> Logout();
}
