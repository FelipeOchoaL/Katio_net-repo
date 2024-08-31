using System.Collections.Generic;
using System.Threading.Tasks;
using Katio.Data.Models;
using Katio.Data.Dto;

namespace Katio.Business.Interface;

public interface IBookService
{
    //Obtener todos los libros
    public Task<BaseMessage<Books>>GetAllBooks();//ya
    //Obtener por ID
    public Task<BaseMessage<Books>>GetById(int id);//ya
    //Obtener por el titulo
    public Task<BaseMessage<Books>> GetByName(String Title);//ya
    public Task<BaseMessage<Books>> GetByAuthor(int AuthorId);
    public Task<BaseMessage<Books>> GetByAuthor(string name);
    //Update
    public Task<BaseMessage<Books>> Update(int Id, Books book);
    Task<BaseMessage<Books>> CreateBook(Books books);   
};

