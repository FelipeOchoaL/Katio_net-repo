using System.Collections.Generic;
using System.Threading.Tasks;
using Katio.Data.Models;

namespace Katio.Business.Interface;

public interface IBookService
{
    //Obtener todos los libros
    public Task<IEnumerable<Books>>GetAllBooks();
    //Obtener por ID
    public Task<IEnumerable<Books>>GetById(int id);
    //Obtener por el titulo
    public Task<IEnumerable<Books>> GetByName(String Title);
    //Update
    public Task<IEnumerable<Books>> Update(Books book);
     
};

