using GridExample.Data;
using GridExample.Models;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GridExample.Controllers
{
    public class GridController : Controller
    {
        private readonly ProduceDataContext _context;

        public GridController(ProduceDataContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<ActionResult> Grid_Read([DataSourceRequest] DataSourceRequest request)
        {
            var products = await _context.Produce.ToDataSourceResultAsync(request);

            return Json(products);
        }
        [HttpPost]
        public async Task<ActionResult> Grid_Create([DataSourceRequest] DataSourceRequest request, [Bind(Prefix = "models")] IEnumerable<Produce> produce)
        {
            var results = new List<Produce>();

            if (produce != null && ModelState.IsValid)
            {
                foreach (var p in produce)
                {
                    _context.Add(p);
                    await _context.SaveChangesAsync();
                }
            }

            var result = await results.ToDataSourceResultAsync(request, ModelState);

            return Json(result);
        }

        [HttpPost]
        public async Task<ActionResult> Grid_Update([DataSourceRequest] DataSourceRequest request, [Bind(Prefix = "models")] IEnumerable<Produce> produce)
        {
            if (produce != null && ModelState.IsValid)
            {
                foreach (var p in produce)
                {
                    _context.Update(p);
                    await _context.SaveChangesAsync();
                }
            }

            var result = await produce.ToDataSourceResultAsync(request, ModelState);

            return Json(result);
        }

        [HttpPost]
        public async Task<ActionResult> Grid_Delete([DataSourceRequest] DataSourceRequest request, [Bind(Prefix = "models")] IEnumerable<Produce> produce)
        {
            if (produce.Any())
            {
                foreach (var p in produce)
                {
                    _context.Produce.Attach(p);
                    _context.Produce.Remove(p);
                    await _context.SaveChangesAsync();
                }
            }
            var result = await produce.ToDataSourceResultAsync(request, ModelState);

            return Json(result);
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
