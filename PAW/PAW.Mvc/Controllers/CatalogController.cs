using PAW.Architecture;
using Microsoft.AspNetCore.Mvc;
using PAW.Mvc.Helper.Converters;
using PAW.Architecture.Providers;
using PAW.Models;
using PAW.Services;

namespace PAW.Mvc.Controllers;

public class CatalogController(ICatalogService catalogService) : Controller
{
    public async Task<IActionResult> Index()
    {
        var catalog = await catalogService.GetCatalogAsync(1);
        var final = Converter.ToCatalogViewModel(catalog);
        return View("~/Views/Catalog/Index.cshtml", final);
    }

    public async Task<IActionResult> All()
    {
        var catalogs = await catalogService.GetCatalogsAsync();
        return View("~/Views/Catalog/All.cshtml", catalogs.Select(Converter.ToCatalogViewModel));
    }
}
