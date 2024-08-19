using System;
using System.Collections.Generic;
using System.Linq;
using Katio.Business.Interface;
using Katio.Data.Models;
using Katio.Business.Services;
using Katio.Business.Utilities;

namespace Katio.Business.Services;

public class BookService : IBookService
{
        
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
