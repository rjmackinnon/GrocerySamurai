namespace MagicHamster.GrocerySamurai.PresentationLayer.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Model.Entities;

    [Authorize]
    public class StoreController : BaseController<Store>
    {
        // GET: Store
        public async Task<IActionResult> Index()
        {
            addToNavigationHelper();

            var result = await indexHelper().ConfigureAwait(false);

            if (!(result is List<Store>))
            {
                throw new ApplicationException(result.ToString());
            }

            ViewBag.NavigationHelper = NavigationHelper;
            return View(result);
        }

        // GET: Store/Create
        public IActionResult Create()
        {
            return createGetHelper(s => s.UserId = getUserId());
        }

        // POST: Store/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public override async Task<IActionResult> Create([Bind("Name,Description,UserId,Id")] Store store)
        {
            return await createPostHelper(store).ConfigureAwait(false);
        }

        // GET: Store/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            return await editGetHelper(id).ConfigureAwait(false);
        }

        // POST: Store/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public override async Task<IActionResult> Edit([Bind("Name,Description,UserId,Id")] Store store)
        {
            return await editPostHelper(store).ConfigureAwait(false);
        }

        // GET: Store/Delete/5
        public override async Task<IActionResult> Delete(int? id)
        {
            return await deleteHelper(id).ConfigureAwait(false);
        }

        // GET: Store/SetSelected/5
        [HttpGet]
        public ActionResult SetSelected(int? id)
        {
            if (id != null)
            {
                HttpContext.Session.SetString("StoreSelected", id.Value.ToString("n", CultureInfo.CurrentCulture));
            }

            return new OkResult();
        }

        // GET: Store/Back
        [HttpGet]
        public override ActionResult Back()
        {
            return backHelper();
        }
    }
}
