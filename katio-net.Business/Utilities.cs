using System.Net;
using Katio.Data.Dto;
using Katio.Data.Models;
namespace Katio.Business.Utilities;
public static class Utilities
{
    #region BaseMessage Responses
    public static BaseMessage<T> BuildResponse<T>(HttpStatusCode statusCode, string message, List<T>? elements = null )
    where T : class
    {
        return new BaseMessage<T>()
        {
            StatusCode = statusCode,
            Message = message,
            TotalElements = (elements != null && elements.Any()) ? elements.Count : 0,
            ResponseElements = elements ?? new List<T>()
        };
    }
    #endregion
}
