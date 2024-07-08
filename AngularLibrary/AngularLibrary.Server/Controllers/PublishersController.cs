using AngularLibrary.Server.Models;
using AngularLibrary.Server.Services;
using Microsoft.AspNetCore.Mvc;

namespace AngularLibrary.Server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PublishersController : Controller
{
    private readonly IPublishersService publishersService;

    public PublishersController(IPublishersService publishersService)
    {
        this.publishersService = publishersService;
    }

    [HttpGet]
    public Task<PublisherModel[]> GetAll()
    {
        return Task.FromResult(publishersService.GetAll());
    }
}
