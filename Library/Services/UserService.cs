using Library.DataAccess.Entities;
using Library.DataAccess.Repositories;
using Library.Helpers;
using Library.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;

namespace Library.Services;

public class UserService: IUserService
{
    private readonly IUserRepositiry userRepositiry;
    private readonly IHttpContextAccessor httpContextAccessor;

    public UserService(IUserRepositiry userRepositiry, IHttpContextAccessor httpContextAccessor)
    {
        this.userRepositiry = userRepositiry;
        this.httpContextAccessor = httpContextAccessor;
    }

    async Task<bool> IUserService.Login(LoginModel loginModel)
    {
        var user = await userRepositiry.GetUserByEmail(loginModel.Email);
        if (user != null && SecurityHelper.PasswordMatch(loginModel.Password, user.Id.ToString(), user.Password))
        {
            await Authenticate(loginModel.Email, user.Role, loginModel.RememberMe);
            return true;
        }
        return false;
    }

    async Task<bool> IUserService.Logout()
    {
        await httpContextAccessor.HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        return true;
    }

    async Task<bool> IUserService.Register(RegisterModel registerModel)
    {
        var user = await userRepositiry.GetUserByEmail(registerModel.Email);
        if (user != null) return false;

        var id=Guid.NewGuid();
        var hash = SecurityHelper.GenerateSaltedHash(registerModel.Password, id.ToString());
        var userEntity = new UserEntity
        {
            Id = id,
            Email = registerModel.Email,
            Password = hash,
            Role = registerModel.Role,
            CreatedDate = DateTimeOffset.UtcNow,
        };
        await userRepositiry.Create(userEntity);
        await Authenticate(registerModel.Email, registerModel.Role, false);
        return true;
    }

    private async Task Authenticate(string userName, string role, bool rememberMe)
    {
        var claims = new[]
        {
            new Claim(ClaimTypes.Name, userName),
            new Claim(ClaimTypes.Role, role),
            new Claim(ClaimTypes.Email, userName)
        };
        var id = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
        await httpContextAccessor.HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id), new AuthenticationProperties { IsPersistent= rememberMe});
    }
}