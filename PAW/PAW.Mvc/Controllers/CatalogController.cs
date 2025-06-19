using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APW.Architecture;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using PAW.Models;
using PAW.Services;
using PAW.Mvc.Helper.Converters;


namespace PAW.Mvc.Controllers
{
    public class CatalogController(ICatalogService catalogService) : Controller
    {
        // GET: Catalog
        public async Task<IActionResult> Index()
        {
            try
            {
                //throw new Exception("lalalala");

                var catalogs = await catalogService.GetCatalogsAsync();
                return View(catalogs);
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $@"An unexpected error has occured. Double check with your IT Admnin. Detail: {ex.Message}";
                Console.WriteLine(ex.ToString());

                return View(Enumerable.Empty<Catalog>());
            }
        }

        // GET: Catalog/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }


            var catalog = await catalogService.GetCatalogAsync(id ?? 0);

            if (catalog == null)
            {
                return NotFound();
            }
            return View(catalog);
        }

        // POST: Catalog/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public async Task<IActionResult> Save([FromBody] Catalog catalog)
        {
            try
            {
                var result = await catalogService.SaveCatalogAsync([catalog]);

                if (result) TempData["ErrorMessage"] = $@"ITem has been saved succesfully";
            }
            catch
            {
                throw;
            }
            return await Index();

        }

        // POST: Catalog/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var found = await catalogService.GetCatalogAsync(id);

            if (found != null)
            {
                var result = await catalogService.DeleteCatalogAsync(id);
            }
            return RedirectToAction(nameof(Index));


        }
    }
}
