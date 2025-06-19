using PAW.Models;
using PAW.Repositories;
using PAW.Core.Extensions;


namespace PAW.Business
{
    public interface IBusinessCatalog
    {
        Task<IEnumerable<Catalog>> GetAllCatalogsAsync();
        Task<bool> SaveCatalogAsync(Catalog catalog);
        Task<bool> DeleteCatalogAsync(Catalog catalog);
        Task<Catalog> GetCatalogAsync(int id);
    }

    public class BusinessCatalog(IRepositoryCatalog repositoryCatalog) : IBusinessCatalog
    {
        public async Task<IEnumerable<Catalog>> GetAllCatalogsAsync()
        {
            // Business Rules
            // revisar que sea entre las 7 am y 7 pm
            // tener permisos para leer en el usuario
            return await repositoryCatalog.ReadAsync();
        }

        public async Task<bool> SaveCatalogAsync(Catalog catalog)
        {
            var user = ""; //Identityaw
            catalog.AddAudit(user);
            catalog.AddLogging(catalog.Identifier <= 0 ? Models.Enums.LoggingType.Create: Models.Enums.LoggingType.Update);
            var exists = await repositoryCatalog.ExistsAsync(catalog);
            return await repositoryCatalog.UpsertAsync(catalog, exists);
        }

        public async Task<bool> DeleteCatalogAsync(Catalog catalog)
        {
            return await repositoryCatalog.DeleteAsync(catalog);
        }

        public async Task<Catalog> GetCatalogAsync(int id)
        {
            return await repositoryCatalog.FindAsync(id);
        }

        public Task<IEnumerable<Catalog>> GetAllCatalogs()
        {
            throw new NotImplementedException();
        }
    }
}

