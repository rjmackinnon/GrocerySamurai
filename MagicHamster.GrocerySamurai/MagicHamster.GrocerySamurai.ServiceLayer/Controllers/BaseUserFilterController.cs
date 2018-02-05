﻿namespace MagicHamster.GrocerySamurai.ServiceLayer.Controllers
{
    using System;
    using System.Linq.Expressions;
    using System.Net;
    using System.Threading.Tasks;
    using MagicHamster.GrocerySamurai.BusinessLayer.Interfaces;
    using MagicHamster.GrocerySamurai.Model.Common;
    using Microsoft.AspNetCore.Mvc;

    public abstract class BaseUserFilterController<T> : BaseController<T>
        where T : UserFilter
    {
        public BaseUserFilterController(IBaseUserFilterProcess<T> process)
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
