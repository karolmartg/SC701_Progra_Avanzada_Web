using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APW.Architecture;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using PAW.Models.Entities;
using PAW.Services;
using PAW.Mvc.Helper.Converters;


namespace PAW.Mvc.Controllers
{
    public class CatalogController(ICatalogService catalogService) : Controller
    {

        public async Task<IActionResult> All()
        {
            var catalogs = await catalogService.GetCatalogsAsync();
            return View("~/Views/Catalog/All.cshtml", catalogs.Select(Converter.ToCatalogViewModel));
        }

        // GET: Catalog
        public async Task<IActionResult> Index()
        {
            var catalogs = await catalogService.GetCatalogsAsync();
            return View(catalogs);
        }

        // GET: Catalog/Details/5
        public async Task<IActionResult> Details(int? id)
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

        // GET: Catalog/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Catalog/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Identifier,Name,Modified")] Catalog catalog)
        {
            //if (ModelState.IsValid)
            //{
                var result = await catalogService.SaveCatalogAsync([catalog]);
                return RedirectToAction(nameof(Index));
           // }
            return View(catalog);
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
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Identifier,Name,Modified")] Catalog catalog)
        {
            if (id != catalog.Identifier)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var result = await catalogService.SaveCatalogAsync([catalog]);

                }
                catch
                {
                    throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(catalog);
        }

        // GET: Catalog/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }


            var catalog = await catalogService.GetCatalogAsync((int)id);

            if (catalog == null) return NotFound();

            return View(catalog);
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
