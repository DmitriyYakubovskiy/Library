using AngularLibrary.Server.Models;
using AngularLibrary.Server.Services;
using Microsoft.AspNetCore.Mvc;

namespace AngularLibrary.Server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthorsController : Controller
{
    private readonly IAuthorsService authorsService;

    public AuthorsController(IAuthorsService authorsService)
    {
        this.authorsService = authorsService;
    }

    [HttpGet]
    public Task<AuthorModel[]> GetAll()
    {
        return Task.FromResult(authorsService.GetAll());
    }

    [HttpGet("{id:int}")]
    public IActionResult GetById([FromRoute] int id)
    {
        var author = authorsService.GetById(id);
        if (author == null)
        {
            return NotFound(id);
        }
        return Ok(author);
    }

    [HttpPost]
    public Task Create([FromBody] AuthorModel authorModel)
    {
        authorsService.Create(authorModel);
        return Task.FromResult(Ok());
    }

    [HttpPut]
    public IActionResult Edit([FromBody] AuthorModel authorModel)
    {
        authorsService.Update(authorModel);
        return Ok();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete([FromRoute] int id)
    {
        authorsService.Delete(id);
        return Ok();
    }
}
