using core.Interfaces.Services.CloudServices;
using Core.Config;
using Core.Interfaces.CloudServices;
using Microsoft.Azure.Documents;
using Microsoft.Azure.Documents.Client;
using System.Threading.Tasks;

namespace Core.Services
{
    public class DocumentDBHelper : IDocumentDBHelper
    {
        private readonly IKeyVaultHelper _keyVaultHelper;

        public DocumentDBHelper(IKeyVaultHelper keyVaultHelper)
        {
            _keyVaultHelper = keyVaultHelper;
            //var DOCUMENT_DB_END_POINT = await keyVaultHelper.GetSecretAsync(PlatformConfigurationConstants.DOCUMENT_DB_END_POINT);
            //var DOCUMENT_DB_ENDPOINT_KEYVAULT_KEY = await keyVaultHelper.GetSecretAsync(PlatformConfigurationConstants.DOCUMENT_DB_ENDPOINT_KEYVAULT_KEY);
            //var x = new DocumentClient(new System.Uri(DOCUMENT_DB_END_POINT), DOCUMENT_DB_ENDPOINT_KEYVAULT_KEY);
        }

        public async Task<IDocumentClient> GetDocumentDBClientAsync()
        {
            var DOCUMENT_DB_END_POINT = await _keyVaultHelper.GetSecretAsync(PlatformConfigurationConstants.DOCUMENT_DB_END_POINT);
            var DOCUMENT_DB_ENDPOINT_KEYVAULT_KEY = await _keyVaultHelper.GetSecretAsync(PlatformConfigurationConstants.DOCUMENT_DB_ENDPOINT_KEYVAULT_KEY);
            return new DocumentClient(new System.Uri(DOCUMENT_DB_END_POINT), DOCUMENT_DB_ENDPOINT_KEYVAULT_KEY);
        }
    }
}
