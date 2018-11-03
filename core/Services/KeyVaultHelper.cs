using System.Threading.Tasks;
using Core.Interfaces.CloudServices;
using Microsoft.Azure.Services.AppAuthentication;
using Microsoft.Azure.KeyVault;
using System;

namespace Core.Services
{
    public class KeyVaultHelper : IKeyVaultHelper
    {
        private readonly AzureServiceTokenProvider _azureServiceTokenProvider;

        public KeyVaultClient KeyVaultClient { get; }

        public KeyVaultHelper()
        {
            //TODO : Register the Application with the AD to get the token
            _azureServiceTokenProvider = new AzureServiceTokenProvider();
            KeyVaultClient = new KeyVaultClient(GetTokenAsync);
        }

        private async Task<string> GetTokenAsync(string authority, string resource, string scope)
        {
            for (var i = 0; i < 5; i++)
            {
                try
                {
                    return await _azureServiceTokenProvider.KeyVaultTokenCallback(authority, resource, scope).ConfigureAwait(false);
                }
                catch (AzureServiceTokenProviderException)
                {
                    await Task.Delay(TimeSpan.FromSeconds(10)).ConfigureAwait(false);
                }
            }

            return await _azureServiceTokenProvider.KeyVaultTokenCallback(authority, resource, scope).ConfigureAwait(false);
        }

        public Task<string> GetSecretAsync(string secretUri)
        {
            throw new System.NotImplementedException();
        }

    }
}
