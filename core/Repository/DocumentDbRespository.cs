using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Azure.Documents.Client;
using Microsoft.Azure.Documents;
using System.Linq;
using Core.Interfaces.Models;
using Core.Interfaces.Repositories;
using core.Interfaces.Services.CloudServices;

namespace Core.Repository
{
    public abstract class DocumentDbRespository : IRepository
    {
        private readonly IDocumentDBHelper _documentDBHelper;
        private IDocumentClient _documentClient;
        private string cosmosDBName;

        public DocumentDbRespository(IDocumentDBHelper documentDBHelper)
        {
            cosmosDBName = "learn-azure";
            _documentDBHelper = documentDBHelper;
        }

        private async Task GetDBClient()
        {
            if (_documentClient == null)
            {
                _documentClient = await _documentDBHelper.GetDocumentDBClientAsync();
            }
        }

        public async Task<bool> AnyAsync<T>(string id) where T : IBaseEntity
        {
            await GetDBClient();

            return _documentClient.CreateDocumentQuery<T>
                    (UriFactory.CreateDocumentCollectionUri(cosmosDBName, typeof(T).Name))
                    .Any(x => x.Id == id);
        }

        public async Task<T> GetAsync<T>(string id, string collectionName) where T : IBaseEntity
        {
            await GetDBClient();

            return _documentClient.CreateDocumentQuery<T>
                   (UriFactory.CreateDocumentCollectionUri(cosmosDBName, collectionName))
                   .AsEnumerable()
                   .First(x => x.Id == id);
                   //.Where(x => x.Id == id).FirstOrDefault();
                   //.Select(x => x.Id == id).AsEnumerable().FirstOrDefault();
        }

        public async Task<IList<T>> GetAllAsync<T>() where T : IBaseEntity
        {
            await GetDBClient();

            return _documentClient.CreateDocumentQuery<T>
                    (UriFactory.CreateDocumentCollectionUri(cosmosDBName, typeof(T).Name))
                    .ToList();
        }

        public async Task<IList<T>> GetAsync<T>(IList<string> ids) where T : IBaseEntity
        {
            await GetDBClient();

            return _documentClient.CreateDocumentQuery<T>
                   (UriFactory.CreateDocumentCollectionUri(cosmosDBName, typeof(T).Name))
                   .Where(x => ids.Contains(x.Id))
                   .ToList();
        }


        /// <summary>
        /// Insert entity to database even though collection for this entity wasn't created yet.
        /// </summary>
        /// <typeparam name="T">Type of entity to insert</typeparam>
        /// <param name="entity">Entity to insert</param>
        public async Task<bool> InsertAsync<T>(T entity) where T : IBaseEntity
        {
            await GetDBClient();

            await _documentClient.CreateDocumentCollectionIfNotExistsAsync(UriFactory.CreateDatabaseUri(cosmosDBName),
                                                            new DocumentCollection { Id = typeof(T).Name });
            var result = await _documentClient.CreateDocumentAsync(UriFactory.CreateDocumentCollectionUri(cosmosDBName, typeof(T).Name), entity);

            return result.StatusCode == System.Net.HttpStatusCode.Created;
        }

        /// <summary>
        /// Insert entities to database even though collection for these entities was not created yet.
        /// </summary>
        /// <typeparam name="T">Type of entity to insert</typeparam>
        /// <param name="entities">Entities to insert</param>
        public async Task<bool> InsertAsync<T>(IEnumerable<T> entities) where T : IBaseEntity
        {
            await GetDBClient();

            await _documentClient.CreateDocumentCollectionIfNotExistsAsync(UriFactory.CreateDatabaseUri(cosmosDBName),
                new DocumentCollection { Id = typeof(T).Name });

            foreach (var entity in entities)
            {
                var result = await _documentClient.CreateDocumentAsync(UriFactory.CreateDocumentCollectionUri(cosmosDBName, typeof(T).Name), entity);
                if (result.StatusCode != System.Net.HttpStatusCode.Created) return false;
            }
            return true;
        }

        public async Task<bool> UpsertAsync<T>(T entity) where T : IBaseEntity
        {
            await GetDBClient();

            var result = await _documentClient.UpsertDocumentAsync(UriFactory.CreateDocumentCollectionUri(cosmosDBName, typeof(T).Name), entity);
            return result.StatusCode == System.Net.HttpStatusCode.Created;
        }



        public async Task<bool> DeleteAsync<T>(string id) where T : IBaseEntity
        {
            await GetDBClient();

            var result = await _documentClient.DeleteDocumentAsync(UriFactory.CreateDocumentUri(cosmosDBName, typeof(T).Name, id));
            return result.StatusCode == System.Net.HttpStatusCode.Created;
        }

    }
}
