using Microsoft.AspNetCore.Mvc;
using RoofStock.CodingExercise.UI.Contracts;
using System.Threading.Tasks;

namespace RoofStock.CodingExercise.UI.Controllers
{
    using Models;
    using System;

    public class PropertiesController : Controller
    {
        private readonly IApiService _api;

        public PropertiesController(IApiService apiService)
        {
            _api = apiService;
        }

        // GET
        public async Task<IActionResult> Index()
        {
            var data = await _api.GetProperties();
            return View(data);
        }

        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var property = await _api.GetProperty(id.Value);

            if (property == null)
            {
                return NotFound();
            }

            return View(property);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,Address,YearBuilt,MonthlyRent,ListPrice")] PropertyModel property)
        {
            if (id != property.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                await _api.UpdateProperty(property);

                return RedirectToAction(nameof(Index));
            }

            return View(property);
        }

        public async Task<IActionResult> Details(Guid id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var property = await _api.GetProperty(id);

            if (property == null)
            {
                return NotFound();
            }

            return View(property);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Address,YearBuilt,MonthlyRent,ListPrice")] PropertyModel property)
        {
            if (ModelState.IsValid)
            {
                await _api.CreateProperty(property);
                return RedirectToAction(nameof(Index));
            }

            return View(property);
        }

        public async Task<IActionResult> Delete(Guid id)
        {
            if (id == null)
            {
                return NotFound();
            }

            await _api.DeleteProperty(id);

            return RedirectToAction(nameof(Index));
        }
    }
}