using Katio.Business.Interface;
using Katio.Business.Services;
using Katio.Data.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
//using System.Linq;

[Route("api/[controller]")]
[ApiController]

public class AuthorController : ControllerBase
{
    private readonly IAuthorService _authorService;
    public AuthorController(IAuthorService authorService)
    {
        _authorService = authorService;
    }

    
    [HttpGet]
    [Route("GetAllAuthors")]
    public async Task<IActionResult> Index()
    {
        var response = await _authorService.GetAllAuthors();
        return response.TotalElements > 0 ? Ok(response) : StatusCode(StatusCodes.Status404NotFound, response);
    }

}