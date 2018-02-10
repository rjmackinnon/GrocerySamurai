namespace MagicHamster.GrocerySamurai.ServiceLayer.Controllers
{
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Model.Common;

    public interface IBaseController<in T>
        where T : Entity
    {
        Task<IActionResult> GetAll(string userId = null, int? pageSize = 0);

        Task<IActionResult> Get(int? id);

        Task<IActionResult> Add(T record);

        Task<IActionResult> Update(T record);

        Task<IActionResult> Delete(int id);
    }
}