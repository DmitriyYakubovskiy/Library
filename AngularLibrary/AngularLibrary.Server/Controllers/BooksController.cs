using AngularLibrary.Server.Models;
using AngularLibrary.Server.Services;
using Microsoft.AspNetCore.Mvc;

namespace AngularLibrary.Server.Controllers;
[Route("api/[controller]")]
[ApiController]
public class BooksController : Controller
{
    private readonly IBooksService booksService;

    public BooksController(IBooksService booksService)
    {
        this.booksService = booksService;
    }

    [HttpGet]
    public Task<BookModel[]> GetAll()
    {
        return Task.FromResult(booksService.GetAll());
    }

    [HttpGet("{id:int}")]
    public IActionResult GetById([FromRoute] int id)
    {
        var book = booksService.GetById(id);
        if (book == null)
        {
            return NotFound(id);
        }
        return Ok(book);
    }

    [HttpPost]
    public Task Create([FromBody] BookModel bookModel)
    {
        booksService.Create(bookModel);
        return Task.FromResult(Ok());
    }

    [HttpPut]
    public IActionResult Edit([FromBody] BookModel bookModel)
    {
        booksService.Update(bookModel);
        return Ok();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete([FromRoute] int id)
    {
        booksService.Delete(id);
        return Ok();
    }
}
