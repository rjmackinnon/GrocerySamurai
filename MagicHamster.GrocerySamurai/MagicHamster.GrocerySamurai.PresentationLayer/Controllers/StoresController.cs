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
    public class StoresController : BaseController<Store>
    {
        // GET: Stores
        public async Task<IActionResult> Index()
        {
            try
            {
                addToNavigationHelper();

                var result = await indexHelper();

                if (result is List<Store>)
                {
                    ViewBag.NavigationHelper = navigationHelper;
                    return View(result);
                }

                return View("../Shared/Error");
            }
            catch (Exception ex)
            {
                return View("../Shared/Error");
            }
        }

        // GET: Stores/Create
        public IActionResult Create()
        {
            return createGetHelper(s=> s.UserId = getUserId());
        }

        // POST: Stores/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public override async Task<IActionResult> Create([Bind("Name,Description,UserId,Id")] Store store)
        {
            return await createPostHelper(store);
        }

        // GET: Stores/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            return await editGetHelper(id);
        }

        // POST: Stores/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public override async Task<IActionResult> Edit([Bind("Name,Description,UserId,Id")] Store store)
        {
            return await editPostHelper(store);
        }

        // GET: Stores/Delete/5
        public override async Task<IActionResult> Delete(int? id)
        {
            return await deleteHelper(id);
        }

        // GET: Department/SetSelected/5
        [HttpGet]
        public ActionResult SetSelected(int? id)
        {
            if (id != null)
            {
                HttpContext.Session.SetString("DepartmentSelected", id.Value.ToString());
            }
            return new OkResult();
        }

        // GET: Department/Back
        [HttpGet]
        public override ActionResult Back()
        {
            return backHelper();
        }
    }
}
