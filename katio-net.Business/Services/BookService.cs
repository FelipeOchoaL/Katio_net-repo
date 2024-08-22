using System;
using System.Collections.Generic;
using System.Linq;
using Katio.Business.Interface;
using Katio.Data.Models;
using Katio.Business.Services;
using Katio.Business.Utilities;
using Katio.Data.Dto;
using Microsoft.EntityFrameworkCore;
using katio_net.Data;
using System.Net;

namespace Katio.Business.Services;

public class BookService : IBookService
{
    private readonly KatioContext _context;
    public BookService(KatioContext context)
    {
        _context = context;
    }
    public async Task<BaseMessage<Books>> CreateBook(Books books)
    {
        var newBook = new Books()
        {
            Title = books.Title,
            ISBN10 = books.ISBN10,
            ISBN13 = books.ISBN13,
            Published = books.Published,
            Edition = books.Edition,
            DeweyIndex = books.DeweyIndex
        };
        try
        {
            await _context.Books.AddAsync(newBook);
            await _context.SaveChangesAsync();

        }
        catch (Exception ex)
        {
            return Utilities.Utilities.BuildResponse<Books>(HttpStatusCode.InternalServerError,$"{BaseMessageStatus.INTERNAL_SERVER_ERROR_500} |{ex.Message}" );
        }
        return Utilities.Utilities.BuildResponse<Books>(HttpStatusCode.OK, BaseMessageStatus.OK_200, new List<Books>{newBook});
    }

    public async Task<IEnumerable<Books>> GetAllBooks()
    {
        var bookList = Utilities.Utilities.CreateABooksList();
        return bookList;
    }

    public async Task<IEnumerable<Books>> GetById(int id)
    {
        var list = Utilities.Utilities.CreateABooksList();
        var ById = list.Where(x => x.Id == id);
        return ById;
    }

    public async Task<IEnumerable<Books>> GetByName(string name)
    {
        var FindTitle = Utilities.Utilities.CreateABooksList()
        .Where(x => x.Title.Contains(name, StringComparison.InvariantCultureIgnoreCase));
        return FindTitle;
    }

    public async Task<IEnumerable<Books>> Update(Books book)
    {
        var ByUpdate = Utilities.Utilities.CreateABooksList();
        return ByUpdate;
        
    }

    // public async Task<IEnumerable<Books>> SearchByTitle(String Title)
    // {
    //     var result = _books.Where(books => books.Title.Contains(Title, StringComparison.OrdinalIgnoreCase));
    //     return await Task.FromResult(result);
    // }
}
