using MagicHamster.GrocerySamurai.Model.Common;
using Microsoft.AspNetCore.Mvc;

namespace MagicHamster.GrocerySamurai.ServiceLayer.Controllers
{
    public interface IBaseController<in T>
        where T : Entity
    {
        IActionResult GetAll(string userId = null, int? pageSize = 0);
        IActionResult Get(int? id);
        IActionResult Add(T record);
        IActionResult Update(T record);
        IActionResult Delete(int id);
    }
}