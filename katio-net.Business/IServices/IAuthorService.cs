using System.Collections.Generic;
using System.Threading.Tasks;
using Katio.Data.Models;
using Katio.Data.Dto;

namespace Katio.Business.Interface;

public interface IAuthorService
{
    Task<BaseMessage<Author>> CreateAuthor(Author author);   
    Task<BaseMessage<Author>> GetAllAuthors();
};

