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

    public async Task<BaseMessage<Books>> GetAllBooks()
    {
        var result = _context.Books.ToList();
        return result.Any() ? Utilities.Utilities.BuildResponse<Books>(HttpStatusCode.OK, BaseMessageStatus.OK_200, result):
            Utilities.Utilities.BuildResponse(HttpStatusCode.NotFound, BaseMessageStatus.BOOK_NOT_FOUND, new List<Books>());

    }

    public async Task<BaseMessage<Books>> GetById(int id)
    {
        var result = _context.Books.Where(x => x.Id == id).ToList();
        return result.Any() ? Utilities.Utilities.BuildResponse<Books>(HttpStatusCode.OK, BaseMessageStatus.OK_200, result):
            Utilities.Utilities.BuildResponse(HttpStatusCode.NotFound, BaseMessageStatus.BOOK_NOT_FOUND, new List<Books>());
    }

    public async Task<BaseMessage<Books>> GetByName(string Title)
    {
        var result = _context.Books.Where(x => x.Title.Contains(Title, StringComparison.InvariantCultureIgnoreCase)).ToList();
        return result.Any() ? Utilities.Utilities.BuildResponse<Books>(HttpStatusCode.OK, BaseMessageStatus.OK_200, result):
            Utilities.Utilities.BuildResponse(HttpStatusCode.NotFound, BaseMessageStatus.BOOK_NOT_FOUND, new List<Books>());;
    }

    public async Task<BaseMessage<Books>> Update(int Id, Books book)
    {
        var existingBook = _context.Books.FirstOrDefault(x => x.Id == Id);
        if (existingBook == null)
        {
            return Utilities.Utilities.BuildResponse(HttpStatusCode.NotFound, BaseMessageStatus.BOOK_NOT_FOUND, new List<Books>());
        }
        existingBook.Title = book.Title;
        existingBook.ISBN10 = book.ISBN10;
        existingBook.ISBN13 = book.ISBN13;
        existingBook.Published = book.Published;
        existingBook.Edition = book.Edition;
        existingBook.DeweyIndex = book.DeweyIndex;

        _context.Books.Update(existingBook);
        await _context.SaveChangesAsync();

        return Utilities.Utilities.BuildResponse<Books>(HttpStatusCode.OK, BaseMessageStatus.OK_200, new List<Books>{existingBook});
    }

    // public async Task<IEnumerable<Books>> Update(Books book)
    // {
    //     var ByUpdate = Utilities.Utilities.CreateABooksList();
    //     return ByUpdate;

    // }

    // public async Task<IEnumerable<Books>> SearchByTitle(String Title)
    // {
    //     var result = _books.Where(books => books.Title.Contains(Title, StringComparison.OrdinalIgnoreCase));
    //     return await Task.FromResult(result);
    // }
}
