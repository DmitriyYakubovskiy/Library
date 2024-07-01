using Library.DataAccess.Contexts;
using Library.DataAccess.Repositories;
using Library.Services;
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
        services.AddDbContext<BooksDbContext>(options => options.UseNpgsql(connectionString));

        services
        .AddScoped<IPublisherRepository, PublisherRepository>()
        .AddScoped<IAuthorRepository, AuthorRepository>()
        .AddScoped<IBookRepository, BookRepository>();
        services.AddScoped<IBooksService, BooksService>();
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

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllerRoute(name: "default", pattern: "{controller=Home}/{action=Index}/{id?}");
        });
    }
}
