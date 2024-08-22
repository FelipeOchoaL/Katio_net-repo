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
    public static List<Books>CreateABooksList()
    {
        List<Books> booksList = new List<Books>()
        {
            new Books
            {
            Id = 1,
            Title = "El principito",
            ISBN10 = "1234567890",
            ISBN13 = "1234567890123",
            Published = new DateTime(1943, 4, 6),
            Edition = "ElColombiano",
            DeweyIndex = "813.54",
            },
            new Books
            {
            Title = "Cien años de soledad",
            ISBN10 = "0123456789",
            ISBN13 = "0123456789012",
            Edition = "Sudamericana",
            DeweyIndex = "863.44",
            Published = new DateTime(1967, 5, 30),
            Id = 2
            },
            new Books
            {
            Title = "Don Quijote de la Mancha",
            ISBN10 = "9876543210",
            ISBN13 = "9876543210123",
            Edition = "Francisco de Robles",
            DeweyIndex = "863.3",
            Published = new DateTime(1605, 1, 16),
            Id = 3
            },
            new Books
            {
            Title = "1984",
            ISBN10 = "6789012345",
            ISBN13 = "6789012345678",
            Edition = "Secker & Warburg",
            DeweyIndex = "823.912",
            Published = new DateTime(1949, 6, 8),
            Id = 4
            },
            new Books
            {
            Title = "Matar a un ruiseñor",
            ISBN10 = "5432109876",
            ISBN13 = "5432109876543",
            Edition = "J.B. Lippincott & Co.",
            DeweyIndex = "813.54",
            Published = new DateTime(1960, 7, 11),
            Id = 5
            },
            new Books
            {
            Title = "Orgullo y prejuicio",
            ISBN10 = "1098765432",
            ISBN13 = "1098765432109",
            Edition = "T. Egerton",
            DeweyIndex = "823.7",
            Published = new DateTime(1813, 1, 28),
            Id = 6
            },

        
        };
        return booksList;    
    }   
    
}
