using Katio.Business.Interface;
using Katio.Business.Services;
using Katio.Data.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
//using System.Linq;


[ApiController]
[Route("api/[controller]")]
public class BooksController : ControllerBase
{
    private readonly IBookService _bookService;
    public BooksController(IBookService bookService)
    {
        _bookService = bookService;
    }

    [HttpGet]
    [Route("GetAllBooks")]
    public async Task<IActionResult> Index()
    {
        var response = await _bookService.GetAllBooks();
        return response.Count() > 0 ? Ok(response) : StatusCode(StatusCodes.Status204NoContent, "No lo consegui");
    }

    [HttpGet]
    [Route("SearchById")]
    public async Task<ActionResult> GetById(int id)
    {
        var response = await _bookService.GetById(id);
        return response.Count() > 0 ? Ok(response) : StatusCode(StatusCodes.Status404NotFound, "No lo consegui");
    }

    [HttpGet]
    [Route("GetByName")]
    public async Task<IActionResult> GetByName(string name)
    {
        var response = await _bookService.GetByName(name);
        return response.Count() > 0 ? Ok(response) : StatusCode(StatusCodes.Status404NotFound, "No lo consegui");
    }

    [HttpPost]
    [Route("Update")]
    public async Task<IActionResult> Update(Books book)
    {
        var response = await _bookService.Update(book);
        return response.Count() > 0 ? Ok(response) : StatusCode(StatusCodes.Status404NotFound, "No lo consegui");
    }

    [HttpPost]
    [Route("Create")]
    public async Task<IActionResult> Create(Books books)
    {
        var response = await _bookService.CreateBook(books)
        return response
    }
}
