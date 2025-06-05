using PAW.Models.Entities;

internal interface IBusinessCatalog
{
    Task<bool> DeleteCatalogAsync(Catalog catalog);
    Task<IEnumerable<Catalog>> GetAllCatalogAsync();
    Task<Catalog> GetCatalogAsync(int id);
    Task<bool> SaveCatalogAsync(Catalog catalog);

}