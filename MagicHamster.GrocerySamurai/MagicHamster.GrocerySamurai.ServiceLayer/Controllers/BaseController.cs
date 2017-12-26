using System;
using System.Collections.Generic;
using System.Net;
using MagicHamster.GrocerySamurai.BusinessLayer.Interfaces;
using MagicHamster.GrocerySamurai.Model.Common;
using Microsoft.AspNetCore.Mvc;

namespace MagicHamster.GrocerySamurai.ServiceLayer.Controllers
{
    /// <summary>
    /// This works like the generic unit tests. The non-generic controllers have the real web methods, but they are simply wrappers
    /// around the generic methods.
    /// </summary>
    /// <typeparam name="T">Model object type (must be IEntity)</typeparam>
    public abstract class BaseController<T> : Controller, IBaseController<T>
        where T : Entity
    {
        protected List<string> childProperties;
        private IBaseProcess<T> businessProcess;

        //public IBaseProcess<T> BusinessProcess
        //{
        //    get { return businessProcess ?? (businessProcess = new UnityContainerManager().Locate<IBaseProcess<T>>()); }

        //    set { businessProcess = value; }
        //}

        public BaseController()
        {
        }

        public BaseController(IBaseProcess<T> process)
        {
            businessProcess = process;
        }

        protected IActionResult getAllHelper(Func<T, object> orderBy, int? pageSize)
        {
            try
            {
                var data = businessProcess.GetAll(orderBy, childProperties, pageSize ?? 0);
                return Ok(data);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.GetBaseException().Message);
            }
        }

        protected IActionResult getHelper(int? id)
        {
            if (id == null)
            {
                return BadRequest($"No {typeof(T).Name} ID provided.");
            }

            try
            {
                var data = businessProcess.GetById(id.Value, childProperties);
                return Ok(data);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.GetBaseException().Message);
            }
        }

        protected IActionResult addHelper(T record)
        {
            if (record == null)
            {
                return BadRequest($"{typeof(T).Name} information was not received.");
            }

            try
            {
                businessProcess.AddRecord(record);
                var result = businessProcess.Save();

                return result == 1 ? Ok($"{typeof(T).Name} was successfully inserted.") :
                    StatusCode((int)HttpStatusCode.NotModified, $"No {typeof(T).Name} data was inserted.");
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.GetBaseException().Message);
            }
        }

        protected IActionResult updateHelper(T record)
        {
            if (record == null)
            {
                return BadRequest($"{typeof(T).Name} information was not received.");
            }

            try
            {
                businessProcess.UpdateRecord(record);
                var result = businessProcess.Save();

                return result == 1 ? Ok($"{typeof(T).Name} was successfully updated.") :
                    StatusCode((int)HttpStatusCode.NotModified, $"No {typeof(T).Name} data was updated.");
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.GetBaseException().Message);
            }
        }

        protected IActionResult deleteHelper(int id)
        {
            if (id == 0)
            {
                return BadRequest($"{typeof(T).Name} information was not received.");
            }

            try
            {
                businessProcess.DeleteRecord(id);
                var result = businessProcess.Save();

                return result == 1 ? Ok($"{typeof(T).Name} was successfully deleted.") :
                    StatusCode((int)HttpStatusCode.NotModified, $"No {typeof(T).Name} data was deleted.");
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.GetBaseException().Message);
            }
        }

        public abstract IActionResult GetAll(int? pageSize = 0);

        public abstract IActionResult Get(int? id);

        public abstract IActionResult Add(T record);

        public abstract IActionResult Update(T record);

        public abstract IActionResult Delete(int id);
    }
}
