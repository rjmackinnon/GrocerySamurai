namespace MagicHamster.GrocerySamurai.ServiceLayer.Controllers
{
    using System;
    using System.Linq.Expressions;
    using System.Net;
    using System.Threading.Tasks;
    using BusinessLayer.Interfaces;
    using Microsoft.AspNetCore.Mvc;
    using Model.Common;

    public abstract class BaseUserFilterController<T> : BaseController<T>
        where T : UserFilter
    {
        // ReSharper disable once SuggestBaseTypeForParameter
        protected BaseUserFilterController(IBaseUserFilterProcess<T> process)
            : base(process)
        {
        }

        protected async Task<IActionResult> getAllHelper(string userId, Expression<Func<T, object>> orderBy, int? pageSize)
        {
            if (userId == null)
            {
                return BadRequest("Please include a valid userId.");
            }

            try
            {
                var data = await ((IBaseUserFilterProcess<T>)BusinessProcess).GetAllByUser(userId, orderBy, childProperties, pageSize ?? 0)
                    .ConfigureAwait(false);
                return Ok(data);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.GetBaseException().Message);
            }
        }
    }
}
