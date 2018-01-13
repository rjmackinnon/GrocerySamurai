using System.Threading.Tasks;
using MagicHamster.GrocerySamurai.Model.Common;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace MagicHamster.GrocerySamurai.PresentationLayer.Controllers
{
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