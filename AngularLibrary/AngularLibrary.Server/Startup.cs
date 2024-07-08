using AngularLibrary.Server.Configuration;
using AngularLibrary.Server.Services;
using Library.DataAccess.Contexts;
using Library.DataAccess.Repositories;
using Microsoft.AspNetCore.SpaServices.AngularCli;
using Microsoft.EntityFrameworkCore;

namespace AngularLibrary;

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
        services.AddDbContext<BooksDbContext>(
                            options => options.UseNpgsql(connectionString));
        services.AddScoped<IAuthorRepository, AuthorRepository>();
        services.AddScoped<IPublisherRepository, PublisherRepository>();
        services.AddScoped<IBookRepository, BookRepository>();

        services.AddScoped<IBooksService, BooksService>()
            .AddScoped<IAuthorsService, AuthorsService>()
            .AddScoped<IPublishersService, PublishersService>();
        services.AddMvc();
        services.AddControllers();

        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();

        services.AddSpaStaticFiles(conf =>
        {
            var settings = configuration.GetSection(SpaSettings.Key).Get<SpaSettings>();
            conf.RootPath = settings.RootPath;
        });
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        app.UseCors(x => x
        //.AllowAnyOrigin()
        .WithOrigins(GetAllowedOrigins(configuration))
        .AllowAnyMethod()
        .AllowAnyHeader()
        );

        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
            app.UseSwagger();
            app.UseSwaggerUI(options => // UseSwaggerUI is called only in Development.
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
            });
        }

        app.UseStatusCodePages();
        app.UseStaticFiles();
        if (!env.IsDevelopment())
        {
            app.UseSpaStaticFiles();
        }
        app.UseRouting();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllerRoute(name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
            endpoints.MapControllers();
        });

        app.UseSpa(spa =>
        {
            var settings = configuration.GetSection(SpaSettings.Key).Get<SpaSettings>();
            spa.Options.SourcePath = settings.SourcePath;
            Console.WriteLine(settings.SourcePath);
            spa.Options.DevServerPort = 4200;
            if (env.IsDevelopment())
            {
                spa.UseAngularCliServer(npmScript: "start");
            }
        });
        Console.WriteLine($"ContentRoot Path: {env.ContentRootPath}");
        Console.WriteLine($"WebRootPath: {env.WebRootPath}");
    }

    private string[] GetAllowedOrigins(IConfiguration configuration) =>
        configuration.GetSection("AllowedOrigins").Get<string[]>() ?? new string[0];
}