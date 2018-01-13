using System;
using System.Net;
using MagicHamster.GrocerySamurai.BusinessLayer.Interfaces;
using MagicHamster.GrocerySamurai.Model.Common;
using Microsoft.AspNetCore.Mvc;

namespace MagicHamster.GrocerySamurai.ServiceLayer.Controllers
{
    public abstract class BaseUserFilterController<T> : BaseController<T>
        where T : UserFilter
    {
        public BaseUserFilterController(IBaseUserFilterProcess<T> process) : base(process)
        {
        }

        protected IActionResult getAllHelper(string userId, Func<T, object> orderBy, int? pageSize)
        {
            if (userId == null)
            {
                return BadRequest("Please include a valid userId.");
            }

            try
            {
                var data = ((IBaseUserFilterProcess<T>)BusinessProcess).GetAllByUser(userId, orderBy, childProperties, pageSize ?? 0);
                return Ok(data);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.GetBaseException().Message);
            }
        }
    }
}
