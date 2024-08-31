using System.ComponentModel.DataAnnotations.Schema;
using katio_net.Data.Models;

namespace Katio.Data.Models;
public class Books : BaseEntity<int>
{
    public string Title{get;set;} = "";//siempre va a estar vacio
    public string ISBN10{get;set;} = "";
    public string ISBN13{get;set;} = "";
    public DateTime Published;
    public string Edition{get;set;} = "";
    public string DeweyIndex{get;set;} = "";

    [ForeignKey("Author")]
    public int AuthorId {get;set;} 

    public virtual Author? Author{get;set;}
}