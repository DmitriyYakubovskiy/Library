using Library.Models;
using Library.Services;
using Microsoft.AspNetCore.Mvc;

namespace Library.Controllers;
[Route("books")]
public class BooksController : Controller
{
    private readonly IBooksService booksService;
    private AuthorModel[] authors;
    private PublisherModel[] publishers;

    public BooksController(IBooksService booksService)
    {
        this.booksService = booksService;
        authors = booksService.GetAuthors();
        publishers = booksService.GetPublisher();
    }

    [Route("/")]
    [HttpGet("list")]
    public IActionResult BookList(string searchString="")
    {
        ViewBag.Title = "Всемирная библиотека";
        var books = booksService.GetAll().ToList();
        if (!String.IsNullOrEmpty(searchString))
        {
            books=books.Where(book =>
            book.Name.Contains(searchString, StringComparison.OrdinalIgnoreCase) ||
            (book.Author.FirstName + " " + book.Author.LastName).Contains(searchString, StringComparison.OrdinalIgnoreCase) ||
            book.Genre.Contains(searchString, StringComparison.OrdinalIgnoreCase) ||
            book.Publisher.Name.Contains(searchString, StringComparison.OrdinalIgnoreCase) ||
            book.Year.Contains(searchString, StringComparison.OrdinalIgnoreCase)
            ).ToList();
        }

        return View(books.ToArray());
    }

    [HttpGet("{id:int}")]
    public IActionResult GetById([FromRoute] int id)
    {
        var model = booksService.GetById(id);
        if (model == null) return NotFound(id);
        return View("BookDetails", model);
    }

    [HttpGet("create")]
    public IActionResult Create()
    {
        var bookViewModel = new BookVeiwModel()
        {
            Authors = authors,
            Publishers = publishers
        };
        return View("BookCreate", bookViewModel);
    }

    [HttpPost("create")]
    public IActionResult Create([FromForm(Name = "Book")] BookModel bookModel)
    {
        booksService.Create(bookModel);
        return RedirectToAction(nameof(BookList));
    }

    [HttpGet("edit/{id}")]
    public IActionResult Edit([FromRoute] int id)
    {
        var bookModel = booksService.GetById(id);
        var bookViewModel = new BookVeiwModel()
        {
            Book = bookModel,
            Authors = authors,
            Publishers = publishers
        };
        return View("BookEdit", bookViewModel);
    }

    [HttpPost("edit")]
    public IActionResult Edit([FromForm(Name = "Book")] BookModel bookModel)
    {
        booksService.Update(bookModel);
        return RedirectToAction(nameof(BookList));
    }

    [HttpDelete("{id}")]
    public IActionResult Delete([FromRoute] int id)
    {
        booksService.Delete(id);
        return Ok();
    }
}
