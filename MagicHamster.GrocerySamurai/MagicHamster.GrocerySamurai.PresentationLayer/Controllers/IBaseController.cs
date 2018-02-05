namespace MagicHamster.GrocerySamurai.PresentationLayer.Controllers
{
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.ModelBinding;
    using Model.Common;

    public interface IBaseController<in T>
        where T : Entity, new()
    {
        ControllerContext ControllerContext { get; set; }

        dynamic ViewBag { get; }

        ModelStateDictionary ModelState { get; }

        Task<IActionResult> Create(T item);

        Task<IActionResult> Delete(int? id);

        Task<IActionResult> Details(int? id);

        Task<IActionResult> Edit(T item);

        ActionResult Back();
    }
}