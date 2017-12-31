using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MagicHamster.GrocerySamurai.Model.Entities;
using Microsoft.AspNetCore.Authorization;

namespace MagicHamster.GrocerySamurai.PresentationLayer.Controllers
{
    [Authorize]
    public class GroceryListsController : BaseController<GroceryList>
    {
        // GET: GroceryLists
        public async Task<IActionResult> Index()
        {
            addToNavigationHelper();

            var result = await indexHelper();

            if (result is List<GroceryList>)
            {
                ViewBag.NavigationHelper = NavigationHelper;
                return View(result);
            }

            return View("../Shared/Error");
        }

        // GET: GroceryLists/Create
        public IActionResult Create()
        {
            return createGetHelper();
        }

        // POST: GroceryLists/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public override async Task<IActionResult> Create([Bind("StoreId,Name,Description,Id")] GroceryList groceryList)
        {
            return await createPostHelper(groceryList);
        }

        // GET: GroceryLists/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            return await editGetHelper(id);
        }

        // POST: GroceryLists/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public override async Task<IActionResult> Edit([Bind("StoreId,Name,Description,Id")] GroceryList groceryList)
        {
            return await editPostHelper(groceryList);
        }

        // GET: GroceryLists/Delete/5
        public override async Task<IActionResult> Delete(int? id)
        {
            return await deleteHelper(id);
        }

        // GET: Department/Back
        [HttpGet]
        public override ActionResult Back()
        {
            return backHelper();
        }
    }
}
