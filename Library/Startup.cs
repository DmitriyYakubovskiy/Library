using Library.DataAccess.Contexts;
using Library.DataAccess.Repositories;
using Library.Services;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;

namespace Library;
public class Startup
{
    private readonly IConfiguration configuration;

    public Startup(IConfiguration configuration)
    {
        this.configuration = configuration;
    }

    public void ConfigureServices(IServiceCollection services)
    {
        services.AddAutoMapper(typeof(Startup).Assembly);

        var connectionString = configuration.GetConnectionString("BooksDbConnection");
        services.AddDbContext<LibraryDbContext>(options => options.UseNpgsql(connectionString));

        services
        .AddScoped<IPublisherRepository, PublisherRepository>()
        .AddScoped<IAuthorRepository, AuthorRepository>()
        .AddScoped<IBookRepository, BookRepository>()
        .AddScoped<IUserRepositiry, UserRepositiry>();
        services.AddScoped<IBooksService, BooksService>()
            .AddScoped<IUserService, UserService>();

        services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(options =>
        {
            options.LoginPath = new PathString(CookieAuthenticationDefaults.LoginPath);
            options.LogoutPath=new PathString(CookieAuthenticationDefaults.LogoutPath);
            options.AccessDeniedPath=new PathString(CookieAuthenticationDefaults.AccessDeniedPath);
        });
        
        services.AddHttpContextAccessor();
        services.AddMvc();
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }

        app.UseStatusCodePages();
        app.UseStaticFiles();
        app.UseRouting();
        app.UseAuthentication();
        app.UseAuthorization();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllerRoute(name: "default", pattern: "{controller=Home}/{action=Index}/{id?}");
        });
    }
}
