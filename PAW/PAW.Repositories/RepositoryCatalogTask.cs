using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PAW.Data.Models;
using PAW.Models;
using PAW.Models.Entities;
using PAW.Repositories;


namespace PAW.Repositories
{
    public interface IRepositoryCatalogTask
    {
        Task<bool> UpsertAsync(CatalogTask entity, bool isUpdating);

        Task<bool> CreateAsync(CatalogTask entity);

        Task<bool> DeleteAsync(CatalogTask entity);

        Task<IEnumerable<CatalogTask>> ReadAsync();

        Task<CatalogTask> FindAsync(int id);

        Task<bool> UpdateAsync(CatalogTask entity);

        Task<bool> UpdateManyAsync(IEnumerable<CatalogTask> entities);

        Task<bool> ExistsAsync(CatalogTask entity);
        Task<bool> CheckBeforeSavingAsync(CatalogTask entity);

    }

    public class RepositoryCatalogTask : RepositoryBase<CatalogTask>, IRepositoryCatalogTask
    {
        public Task<bool> CheckBeforeSavingAsync(CatalogTask entity)
        {
            throw new NotImplementedException();
        }
    }
}
