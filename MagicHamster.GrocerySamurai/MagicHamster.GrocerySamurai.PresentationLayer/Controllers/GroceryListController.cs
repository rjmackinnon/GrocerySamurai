using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MagicHamster.GrocerySamurai.Model.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MagicHamster.GrocerySamurai.PresentationLayer.Controllers
{
    [Authorize]
    public class GroceryListController : BaseController<GroceryList>
    {
        // GET: GroceryList
        public async Task<IActionResult> Index()
        {
            if (!Int32.TryParse(HttpContext.Session.GetString("StoreSelected"), out var storeId))
            {
                throw new ApplicationException("No store selected");
            }

            var result = await indexHelper(new List<string>{ storeId.ToString()}, "ByStore");

            if (!(result is List<GroceryList>))
            {
                throw new ApplicationException(result.ToString());
            }

            ViewBag.NavigationHelper = NavigationHelper;
            return PartialView(result);
        }

        // GET: GroceryList/Create
        public IActionResult Create()
        {
            if (!Int32.TryParse(HttpContext.Session.GetString("StoreSelected"), out var storeId))
            {
                throw new ApplicationException("No store selected");
            }

            return createGetHelper(l => l.StoreId = storeId);
        }

        // POST: GroceryList/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public override async Task<IActionResult> Create([Bind("StoreId,Name,Description,Id")] GroceryList store)
        {
            return await createPostHelper(store);
        }

        // GET: GroceryList/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            return await editGetHelper(id);
        }

        // POST: GroceryList/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public override async Task<IActionResult> Edit([Bind("StoreId,Name,Description,Id")] GroceryList store)
        {
            return await editPostHelper(store);
        }

        // GET: GroceryList/Delete/5
        public override async Task<IActionResult> Delete(int? id)
        {
            return await deleteHelper(id);
        }
    }
}
