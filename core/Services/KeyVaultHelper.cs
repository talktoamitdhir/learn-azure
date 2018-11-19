using System.Threading.Tasks;
using Core.Interfaces.CloudServices;
using Microsoft.Azure.Services.AppAuthentication;
using Microsoft.Azure.KeyVault;
using System;
using Microsoft.Azure.KeyVault.Models;
using Core.Config;

namespace Core.Services
{
    public class KeyVaultHelper : IKeyVaultHelper
    {
        private readonly AzureServiceTokenProvider _azureServiceTokenProvider;

        private readonly KeyVaultClient _keyVaultClient;

        public KeyVaultHelper()
        {
            //TODO : Register the Application with the AD to get the token
            // _azureServiceTokenProvider = new AzureServiceTokenProvider();
            // _keyVaultClient = new KeyVaultClient(GetTokenAsync);
            AzureServiceTokenProvider azureServiceTokenProvider = new AzureServiceTokenProvider();
            _keyVaultClient = new KeyVaultClient(new KeyVaultClient.AuthenticationCallback(azureServiceTokenProvider.KeyVaultTokenCallback));
            
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

        public async Task<string> GetSecretAsync(string secretUri)
        {
            try
            {
                SecretBundle secretValue = await _keyVaultClient.GetSecretAsync($"{GetKeyVaultServiceURL()}/secrets/{secretUri}").ConfigureAwait(false);
                return secretValue.Value;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);

            }
            return string.Empty;
        }

        public string GetKeyVaultServiceURL()
        {
            // var keyVaultEndpointUrl = PlatformConfigurationConstants.ReadAppConfig(PlatformConfigurationConstants.KEYVAULT_ENDPOINT_URL);
            var keyVaultEndpointUrl = PlatformConfigurationConstants.KEYVAULT_ENDPOINT_URL;
            if (string.IsNullOrEmpty(keyVaultEndpointUrl))
                throw new InvalidOperationException("KeyVault endpoint url configuration was not found in configuration file");
            return keyVaultEndpointUrl.TrimEnd('/');
        }

        //private string GetKeyVaultClientId()
        //{
        //    var keyVaultEndpointUrl = PlatformConfigurationConstants.ReadAppConfig(PlatformConfigurationConstants.ACTIVE_DIR__KEY_VAULT_CLIENT_ID_KEY);
        //    if (string.IsNullOrEmpty(keyVaultEndpointUrl))
        //        throw new InvalidOperationException("KeyVault ACTIVE_DIR__KEY_VAULT_CLIENT_ID_KEY configuration was not found in configuration file");
        //    return keyVaultEndpointUrl.TrimEnd('/');
        //}
    }
}
