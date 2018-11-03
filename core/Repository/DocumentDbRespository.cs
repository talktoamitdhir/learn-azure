using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Azure.Documents.Client;
using Microsoft.Azure.Documents;
using System.Linq;
using Core.Interfaces.Models;
using Core.Interfaces.Repositories;
using Core.Config;

namespace Core.Repository
{
    public class DocumentDbRespository : IRepository
    {
        private readonly IDocumentClient _client;
        private string cosmosDBName;

        public DocumentDbRespository()
        {
            //TODO : Get DocumentDB info from the KeyVault;
            _client = new DocumentClient(new Uri(PlatformConfigurationConstants.DOCUMENT_DB_END_POINT), "DocumentDB_PrimaryKey");
            cosmosDBName = "ABC";
            _client.CreateDatabaseIfNotExistsAsync(new Database { Id = cosmosDBName }).Wait();
        }

        public async Task<bool> AnyAsync<T>(string id) where T : IBaseEntity
        {
            return _client.CreateDocumentQuery<T>
                    (UriFactory.CreateDocumentCollectionUri(cosmosDBName, typeof(T).Name))
                    .Any(x => x.Id == id);
        }

        public async Task<T> GetAsync<T>(string id) where T : IBaseEntity
        {
            return _client.CreateDocumentQuery<T>
                   (UriFactory.CreateDocumentCollectionUri(cosmosDBName, typeof(T).Name))
                   .First(x => x.Id == id);
        }

        public async Task<IList<T>> GetAllAsync<T>() where T : IBaseEntity
        {
            return _client.CreateDocumentQuery<T>
                    (UriFactory.CreateDocumentCollectionUri(cosmosDBName, typeof(T).Name))
                    .ToList();
        }

        public async Task<IList<T>> GetAsync<T>(IList<string> ids) where T : IBaseEntity
        {
            return _client.CreateDocumentQuery<T>
                   (UriFactory.CreateDocumentCollectionUri(cosmosDBName, typeof(T).Name))
                   .Where(x => ids.Contains(x.Id))
                   .ToList();
        }


        /// <summary>
        /// Insert entity to database even though collection for this entity wasn't created yet.
        /// </summary>
        /// <typeparam name="T">Type of entity to insert</typeparam>
        /// <param name="entity">Entity to insert</param>
        public async Task InsertAsync<T>(T entity) where T : IBaseEntity
        {
            await _client.CreateDocumentCollectionIfNotExistsAsync(UriFactory.CreateDatabaseUri(cosmosDBName),
                                                            new DocumentCollection { Id = typeof(T).Name });
            await _client.CreateDocumentAsync(UriFactory.CreateDocumentCollectionUri(cosmosDBName, typeof(T).Name), entity);
        }

        /// <summary>
        /// Insert entities to database even though collection for these entities was not created yet.
        /// </summary>
        /// <typeparam name="T">Type of entity to insert</typeparam>
        /// <param name="entities">Entities to insert</param>
        public async Task InsertAsync<T>(IEnumerable<T> entities) where T : IBaseEntity
        {
            await _client.CreateDocumentCollectionIfNotExistsAsync(UriFactory.CreateDatabaseUri(cosmosDBName),
                new DocumentCollection { Id = typeof(T).Name });

            foreach (var entity in entities)
                await _client.CreateDocumentAsync(UriFactory.CreateDocumentCollectionUri(cosmosDBName, typeof(T).Name), entity);
        }

        public async Task UpsertAsync<T>(T entity) where T : IBaseEntity
        {
            await _client.UpsertDocumentAsync(UriFactory.CreateDocumentCollectionUri(cosmosDBName, typeof(T).Name), entity);
        }



        public async Task DeleteAsync<T>(string id) where T : IBaseEntity
        {
            await _client.DeleteDocumentAsync(UriFactory.CreateDocumentUri(cosmosDBName, typeof(T).Name, id));
        }

    }
}
