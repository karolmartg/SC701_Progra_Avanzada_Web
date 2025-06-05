using APW.Architecture;
using PAW.Architecture;
using PAW.Architecture.Providers;
using PAW.Models.Entities;

namespace PAW.Services
{
    public interface ICatalogService
    {
        Task<Catalog> GetCatalogAsync(int id);
        Task<IEnumerable<Catalog>> GetCatalogsAsync();
        Task<bool> DeleteCatalogAsync(int id);
        Task<bool> SaveCatalogAsync(IEnumerable<Catalog> catalog);


    }

    public class CatalogService(IRestProvider restProvider) : ICatalogService
    {
        public async Task<Catalog> GetCatalogAsync(int id)
        {
            var result = await restProvider.GetAsync("http://localhost:5251/Catalog/", "1");
            var catalog = JsonProvider.DeserializeSimple<Catalog>(result);
            return catalog;

        }

        public async Task<IEnumerable<Catalog>> GetCatalogsAsync()
        {
            var result = await restProvider.GetAsync("http://localhost:5251/Catalog/", null);
            var catalogs = JsonProvider.DeserializeSimple<IEnumerable<Catalog>>(result);
            return catalogs;

        }

        public async Task<bool> DeleteCatalogAsync(int id)
        {
            var result = await restProvider.DeleteAsync("http://localhost:5251/Catalog/", $"{id}");
            //var isSaved = JsonProvider.DeserializeSimple<bool>(result);
            return true;
        }

        public async Task<bool> SaveCatalogAsync(IEnumerable<Catalog> catalogs)
        {
            var content = JsonProvider.Serialize(catalogs);
            var result = await restProvider.PostAsync("http://localhost:5251/Catalog/", content);
            return true;
        }
    }
}
