using PAW.Models;
using PAW.Mvc.Models;

namespace PAW.Mvc.Helper.Converters
{
    public class Converter
    {
        public static CatalogViewModel ToCatalogViewModel(Catalog catalog)
        {
            return new CatalogViewModel
            {
                Id = catalog.Identifier,
                Name = catalog.Name,
                Modified = catalog.Modified,
            };
        }
    }
}