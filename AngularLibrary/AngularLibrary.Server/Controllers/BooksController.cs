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
        var product = booksService.GetById(id);
        if (product == null)
        {
            return NotFound(id);
        }
        return Ok(product);
    }

    [HttpPost]
    public IActionResult Create([FromBody] BookModel bookModel)
    {
        booksService.Create(bookModel);
        return Ok();
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
