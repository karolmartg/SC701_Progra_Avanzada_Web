using APW.Architecture;
using Microsoft.AspNetCore.Mvc;
using PAW.Architecture.Providers;
using PAW.Models;

namespace PAW.Mvc.Controllers;

public class CatalogController(IRestProvider restProvider) : Controller
{
    public async Task<IActionResult> Index()
    {
        var result = await restProvider.GetAsync("https://localhost:7252/Catalog/", "1");
        var catalog = JsonProvider.DeserializeSimple<Catalog>(result);
        return View("Index", result);
    }
}