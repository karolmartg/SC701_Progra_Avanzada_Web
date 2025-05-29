using APW.Architecture;
using PAW.Architecture.Providers;
using PAW.Models;

namespace PAW.Services
{
    public interface ICatalogService
    {
        Task<Catalog> GetCatalogAsync(int id);
        Task<IEnumerable<Catalog>> GetCatalogsAsync();
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
    }
}
