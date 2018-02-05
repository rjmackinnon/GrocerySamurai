namespace MagicHamster.GrocerySamurai.ServiceLayer.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;
    using System.Net;
    using System.Threading.Tasks;
    using MagicHamster.GrocerySamurai.BusinessLayer.Interfaces;
    using MagicHamster.GrocerySamurai.Model.Common;
    using Microsoft.AspNetCore.Mvc;

    /// <summary>
    /// This works like the generic unit tests. The non-generic controllers have the real web methods, but they are simply wrappers
    /// around the generic methods.
    /// </summary>
    /// <typeparam name="T">Model object type (must be IEntity)</typeparam>
    public abstract class BaseController<T> : Controller, IBaseController<T>
        where T : Entity
    {
        public BaseController()
        {
        }

        public BaseController(IBaseProcess<T> process)
        {
            BusinessProcess = process;
        }

        public IBaseProcess<T> BusinessProcess { get; set; }

#pragma warning disable CA2227 // Collection properties should be read only
        protected List<string> childProperties { get; set; }
#pragma warning restore CA2227 // Collection properties should be read only

        public abstract Task<IActionResult> GetAll(string userId = null, int? pageSize = 0);

        public abstract Task<IActionResult> Get(int? id);

        public abstract Task<IActionResult> Add(T record);

        public abstract Task<IActionResult> Update(T record);

        public abstract Task<IActionResult> Delete(int id);

        protected async Task<IActionResult> getAllHelper(Expression<Func<T, object>> orderBy, int? pageSize)
        {
            try
            {
                var data = await BusinessProcess.GetAll(orderBy, childProperties, pageSize ?? 0)
                    .ConfigureAwait(false);
                return Ok(data);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.GetBaseException().Message);
            }
        }

        protected async Task<IActionResult> getHelper(int? id)
        {
            if (id == null)
            {
                return BadRequest($"No {typeof(T).Name} ID provided.");
            }

            try
            {
                var data = await BusinessProcess.GetById(id.Value, childProperties)
                    .ConfigureAwait(false);
                return Ok(data);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.GetBaseException().Message);
            }
        }

        protected async Task<IActionResult> addHelper(T record)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                await BusinessProcess.AddRecord(record)
                    .ConfigureAwait(false);
                var result = await BusinessProcess.Save()
                    .ConfigureAwait(false);

                return result == 1 ? CreatedAtRoute($"Get{typeof(T).Name}", new { id = record.Id }, record) :
                    StatusCode((int)HttpStatusCode.NotModified, $"No {typeof(T).Name} data was inserted.");
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.GetBaseException().Message);
            }
        }

        protected async Task<IActionResult> updateHelper(T record)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                await BusinessProcess.UpdateRecord(record)
                    .ConfigureAwait(false);
                var result = await BusinessProcess.Save()
                    .ConfigureAwait(false);

                return result == 1 ? Ok($"{typeof(T).Name} was successfully updated.") :
                    StatusCode((int)HttpStatusCode.NotModified, $"No {typeof(T).Name} data was updated.");
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.GetBaseException().Message);
            }
        }

        protected async Task<IActionResult> deleteHelper(int id)
        {
            if (id == 0)
            {
                return BadRequest($"{typeof(T).Name} information was not received.");
            }

            try
            {
                await BusinessProcess.DeleteRecord(id)
                    .ConfigureAwait(false);
                var result = await BusinessProcess.Save()
                    .ConfigureAwait(false);

                return result == 1 ? Ok($"{typeof(T).Name} was successfully deleted.") :
                    StatusCode((int)HttpStatusCode.NotModified, $"No {typeof(T).Name} data was deleted.");
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.GetBaseException().Message);
            }
        }
    }
}
