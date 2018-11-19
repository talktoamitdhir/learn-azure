using Microsoft.Azure.Documents;
using System.Threading.Tasks;

namespace core.Interfaces.Services.CloudServices
{
    public interface IDocumentDBHelper
    {
        Task<IDocumentClient> GetDocumentDBClientAsync();
    }
}
