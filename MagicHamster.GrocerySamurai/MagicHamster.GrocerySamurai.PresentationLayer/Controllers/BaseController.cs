using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MagicHamster.GrocerySamurai.Model.Common;
using MagicHamster.GrocerySamurai.NavigationHelper;
using MagicHamster.GrocerySamurai.PresentationLayer.Exceptions;
using MagicHamster.GrocerySamurai.PresentationLayer.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace MagicHamster.GrocerySamurai.PresentationLayer.Controllers
{
    /// <summary>
    /// This works like the generic unit tests. The non-generic controllers have the real web methods, but they are simply wrappers
    /// around the generic methods.
    /// </summary>
    /// <typeparam name="T">Model object type (must be Entity)</typeparam>
    public abstract class BaseController<T> : Controller, IBaseController<T>
        where T : Entity, new()
    {
        private readonly string defaultType = typeof(T).Name;

        private string userId;

        public string UserId => userId ?? (userId = getUserId());

        protected INavigationHelper navigationHelper
        {
            get
            {
                if (HttpContext.Session.GetString("NavigationHelper") == null)
                {
                    HttpContext.Session.SetString("NavigationHelper", JsonConvert.SerializeObject(new NavigationHelper.NavigationHelper()));
                }

                return JsonConvert.DeserializeObject<NavigationHelper.NavigationHelper>(HttpContext.Session.GetString("NavigationHelper"));
            }
        }

        protected async Task<object> indexHelper(List<string> parameters = null, string actionSuffix = null, string controllerType = null)
        {
            var type = controllerType ?? defaultType;

            var args = "";
            if (parameters != null)
            {
                args = String.Join("/", parameters.ToArray());
            }
            var url = $"{type}/GetAll{actionSuffix}/{getUserId()}/{args}";

            var response = WebApiHelper.GetWebApiResponseAsHttpResponseMessage(url);
            var responseData = await response.Result.Content.ReadAsStringAsync();

            if (!response.Result.IsSuccessStatusCode)
            {
                return responseData;
            }

            if (controllerType != null)
            {
                return responseData;
            }

            var records = JsonConvert.DeserializeObject<List<T>>(responseData);
            return records;
        }

        protected object detailsHelper(List<string> parameters = null, string actionSuffix = null)
        {
            var args = "";
            if (parameters != null)
            {
                args = String.Join("/", parameters.ToArray());
            }
            var url = $"{defaultType}/GetAll{actionSuffix}/{args}";

            var response = WebApiHelper.GetWebApiResponseAsHttpResponseMessage(url);
            var responseData = response.Result.Content.ReadAsStringAsync().Result;

            if (!response.Result.IsSuccessStatusCode)
            {
                return responseData;
            }

            var records =
                JsonConvert.DeserializeObject<List<T>>(responseData);

            if (records.Count > 1)
            {
                throw new TooManyRecordsFoundException();
            }

            return records.FirstOrDefault();
        }

        protected ActionResult createGetHelper(Action<T> createAction = null)
        {
            addToNavigationHelper();

            var item = new T();

            createAction?.Invoke(item);

            ViewBag.NavigationHelper = navigationHelper;

            return View(item);
        }

        protected async Task<ActionResult> createPostHelper(T item)
        {
            if (!ModelState.IsValid)
            {
                return View(item);
            }

            try
            {
                var url = $"{defaultType}/Add";

                return await processAction(item, url, true);
            }
            catch (Exception)
            {
                return View("../Shared/Error");
            }
        }

        private async Task<ActionResult> processAction(T item, string url, bool doPost)
        {
            var validationError = false;

            var response = doPost ? 
                WebApiHelper.PostWebApiResponseAsHttpResponseMessage(url, item) : 
                WebApiHelper.PutWebApiResponseAsHttpResponseMessage(url, item);
            var responseData = await response.Result.Content.ReadAsStringAsync();

            if (response.Result.IsSuccessStatusCode)
            {
                return RedirectToAction("Back");
            }

            ViewBag.NavigationHelper = navigationHelper;

            if (responseData.Contains("ORA-00001"))
            {
                ModelState.AddModelError("Name", "Name already exists");
                validationError = true;
            }

            if (!processActionResponse(responseData) || validationError)
            {
                return View(item);
            }

            return View("../Shared/Error");
        }

        protected async Task<ActionResult> editGetHelper(int? id)
        {
            addToNavigationHelper();

            if (!id.HasValue)
            {
                return new BadRequestResult();
            }

            var actionUrl = $"{defaultType}/Get/{id}";

            var response = WebApiHelper.GetWebApiResponseAsHttpResponseMessage(actionUrl);
            var responseData = await response.Result.Content.ReadAsStringAsync();

            if (!response.Result.IsSuccessStatusCode)
            {
                return View("../Shared/Error");
            }

            var data = JsonConvert.DeserializeObject<T>(responseData);

            ViewBag.NavigationHelper = navigationHelper;

            return View(data);
        }

        protected async Task<ActionResult> editPostHelper(T item)
        {
            if (!ModelState.IsValid)
            {
                return View(item);
            }

            try
            {
                var url = $"{defaultType}/Update";

                return await processAction(item, url, false);
            }
            catch (Exception)
            {
                return View("../Shared/Error");
            }
        }

        protected async Task<ActionResult> deleteHelper(int? id, string controllerName = null)
        {
            if (!id.HasValue)
            {
                return new BadRequestResult();
            }

            try
            {
                var url = $"{defaultType}/Delete/{id}";

                var response = WebApiHelper.DeleteWebApiResponseAsHttpResponseMessage(url);
                var result = await response.Result.Content.ReadAsStringAsync();
            }
            catch (Exception)
            {
                return View("../Shared/Error");
            }
            return RedirectToAction("Index", controllerName);
        }

        public virtual async Task<IActionResult> Create(T item)
        {
            return null;
        }

        public virtual async Task<IActionResult> Edit(T item)
        {
            return null;
        }

        public virtual async Task<IActionResult> Delete(int? id)
        {
            return null;
        }

        public virtual async Task<IActionResult> Details(int? id)
        {
            return null;
        }
        
        public virtual ActionResult Back()
        {
            return null;
        }

        /// <summary>
        /// Use this method to do additional validation
        /// </summary>
        /// <param name="responseData">Response from the API call</param>
        /// <returns>true to continue default processing, false to display page with validation messages</returns>
        protected virtual bool processActionResponse(string responseData)
        {
            return true;
        }

        protected ActionResult backHelper()
        {
            if (navigationHelper.Count == 0)
            {
                return new OkResult();
            }

            TempData["FromBack"] = true;

            return Redirect(navigationHelper.Remove().AbsoluteUri);
        }

        protected void addToNavigationHelper()
        {
            var fromBack = TempData["FromBack"] as bool?;
            if (fromBack == null || !fromBack.Value)
            {
                navigationHelper.Add(Request.Headers["Referer"].ToString(), Request.GetDisplayUrl());
            }
        }

        protected string getUserId()
        {
            return HttpContext.Session.GetString("UserId");
        }
    }
}
