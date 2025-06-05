using Microsoft.AspNetCore.Mvc;
using PAW.Business;
using PAW.Models.Entities;

namespace PAW.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CatalogController(IBusinessCatalog businessCatalog) : Controller
    {
        //private readonly IBusinessCatalog businessCatalog = businessCatalog;

        [HttpGet(Name = "GetCatalogs")]
        public async Task<IEnumerable<Catalog>> GetAll()
        {
            return await businessCatalog.GetAllCatalogsAsync();
        }

        [HttpGet("{id:int}")]
        public async Task<Catalog> GetById(int id)
        {
            var catalog = await businessCatalog.GetCatalogAsync(id);
            return catalog;
        }

        [HttpPost]
        public async Task<bool> Save([FromBody] IEnumerable<Catalog> catalogs)
        {
            foreach (var item in catalogs)
            {
                await businessCatalog.SaveCatalogAsync(item);
            }
            return true;    
        }

        [HttpDelete]
        public async Task<bool> Delete(Catalog catalog)
        {
            return await businessCatalog.DeleteCatalogAsync(catalog);
        }
    }
}
