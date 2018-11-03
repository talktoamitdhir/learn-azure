using System.Threading.Tasks;

namespace Core.Interfaces.CloudServices
{
    public interface IKeyVaultHelper
    {
        Task<string> GetSecretAsync(string secretUri);
    }
}
