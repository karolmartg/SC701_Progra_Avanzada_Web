using Microsoft.AspNetCore.Mvc;
using PAW.Business;
using PAW.Models;

namespace PAW.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CatalogController(IBusinessCatalog businessCatalog) : Controller
    {
        private readonly IBusinessCatalog businessCatalog = businessCatalog;

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
        public async Task<bool> Save([FromBody] Catalog catalog)
        {
            return await businessCatalog.SaveCatalogAsync(catalog);
        }

        [HttpDelete]
        public async Task<bool> Delete(Catalog catalog)
        {
            return await businessCatalog.DeleteCatalogAsync(catalog);
        }
    }
}
