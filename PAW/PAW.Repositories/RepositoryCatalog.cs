using PAW.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAW.Repositories
{
    // Por conveción, debe empezar con una I
    public interface IRepositoryCatalog
    {
        Task<bool> UpsertAsync(Catalog entity, bool isUpdating);

        Task<bool> CreateAsync(Catalog entity);

        Task<bool> DeleteAsync(Catalog entity);

        Task<IEnumerable<Catalog>> ReadAsync();

        Task<Catalog> FindAsync(int id);

        Task<bool> UpdateAsync(Catalog entity);

        Task<bool> UpdateManyAsync(IEnumerable<Catalog> entities);

        Task<bool> ExistsAsync(Catalog entity);
        Task<bool> CheckBeforeSavingAsync(Catalog entity);

    }
    public class RepositoryCatalog : RepositoryBase<Catalog>, IRepositoryCatalog
    {
        public async Task<bool> CheckBeforeSavingAsync(Catalog entity)
        {
            var exists = await ExistsAsync(entity);
            if (exists)
            {
                // algo más
            }

            return await UpsertAsync(entity, exists);
        }
    }
}
