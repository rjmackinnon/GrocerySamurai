namespace MagicHamster.GrocerySamurai.PresentationLayer.Controllers
{
    using System.Threading.Tasks;
    using JetBrains.Annotations;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.ModelBinding;
    using Model.Common;

    public interface IBaseController<in T>
        where T : Entity, new()
    {
        [UsedImplicitly]
        ControllerContext ControllerContext { get; set; }

        [UsedImplicitly]
        dynamic ViewBag { get; }

        [UsedImplicitly]
        ModelStateDictionary ModelState { get; }

        Task<IActionResult> Create(T item);

        Task<IActionResult> Delete(int? id);

        Task<IActionResult> Details([UsedImplicitly] int? id);

        Task<IActionResult> Edit(T item);

        ActionResult Back();
    }
}