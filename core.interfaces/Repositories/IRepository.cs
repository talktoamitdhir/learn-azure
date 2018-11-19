using Core.Interfaces.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.Interfaces.Repositories
{
    public interface IRepository
    {
        Task<bool> AnyAsync<T>(string id) where T : IBaseEntity;
        Task<T> GetAsync<T>(string id, string collectionName) where T : IBaseEntity;
        Task<IList<T>> GetAllAsync<T>() where T : IBaseEntity;
        Task<IList<T>> GetAsync<T>(IList<string> ids) where T : IBaseEntity;
        Task<bool> InsertAsync<T>(T entity) where T : IBaseEntity;
        Task<bool> InsertAsync<T>(IEnumerable<T> entities) where T : IBaseEntity;
        Task<bool> UpsertAsync<T>(T entity) where T : IBaseEntity;
        Task<bool> DeleteAsync<T>(string id) where T : IBaseEntity;
    }
}
