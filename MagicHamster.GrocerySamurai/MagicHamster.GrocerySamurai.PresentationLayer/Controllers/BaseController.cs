#pragma warning disable 1998

namespace MagicHamster.GrocerySamurai.PresentationLayer.Controllers
{
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

    /// <summary>
    /// This works like the generic unit tests. The non-generic controllers have the real web methods, but they are simply wrappers
    /// around the generic methods.
    /// </summary>
    /// <typeparam name="T">Model object type (must be Entity)</typeparam>
    public abstract class BaseController<T> : Controller, IBaseController<T>
        where T : Entity, new()
    {
        private readonly string _defaultType = typeof(T).Name;
        private string _userId;
        private INavigationHelper _navigationHelper;

        public string UserId => _userId ?? (_userId = getUserId());

        public INavigationHelper NavigationHelper
        {
            get
            {
                var json = HttpContext.Session.GetString("NavigationHelper");
                if (json == null)
                {
                    _navigationHelper = new NavigationHelper();
                    saveNavigationHelper();
                }
                else if (_navigationHelper == null)
                {
                    _navigationHelper = GrocerySamurai.NavigationHelper.NavigationHelper.FromJson(json);
                }

                return _navigationHelper;
            }
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

        protected async Task<object> indexHelper(List<string> parameters = null, string actionSuffix = null, string controllerType = null)
        {
            var type = controllerType ?? _defaultType;

            var args = UserId;
            if (parameters != null)
            {
                args = String.Join("/", parameters.ToArray());
            }

            var url = $"{type}/GetAll{actionSuffix}/{args}";

            var response = WebApiHelper.GetWebApiResponseAsHttpResponseMessage(url);
            var responseData = await (await response.ConfigureAwait(false)).Content.ReadAsStringAsync().ConfigureAwait(false);

            if (!response.Result.IsSuccessStatusCode)
            {
                throw new ApplicationException($"{(int)response.Result.StatusCode} {response.Result.ReasonPhrase}: {response.Result.RequestMessage}");
            }

            if (controllerType != null)
            {
                return responseData;
            }

            var records = JsonConvert.DeserializeObject<List<T>>(responseData);
            return records;
        }

        protected async Task<object> detailsHelper(List<string> parameters = null, string actionSuffix = null)
        {
            var args = string.Empty;
            if (parameters != null)
            {
                args = String.Join("/", parameters.ToArray());
            }

            var url = $"{_defaultType}/GetAll{actionSuffix}/{args}";

            var response = WebApiHelper.GetWebApiResponseAsHttpResponseMessage(url);
            var responseData = await (await response.ConfigureAwait(false)).Content.ReadAsStringAsync().ConfigureAwait(false);

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

            ViewBag.NavigationHelper = NavigationHelper;

            return View(item);
        }

        protected async Task<ActionResult> createPostHelper(T item)
        {
            if (!ModelState.IsValid)
            {
                return View(item);
            }

            var url = $"{_defaultType}/Add";

            return await processAction(item, url, true).ConfigureAwait(false);
        }

        protected async Task<ActionResult> editGetHelper(int? id)
        {
            addToNavigationHelper();

            if (!id.HasValue)
            {
                return new BadRequestResult();
            }

            var actionUrl = $"{_defaultType}/Get/{id}";

            var response = WebApiHelper.GetWebApiResponseAsHttpResponseMessage(actionUrl);
            var responseData = await (await response.ConfigureAwait(false)).Content.ReadAsStringAsync().ConfigureAwait(false);

            if (!response.Result.IsSuccessStatusCode)
            {
                throw new ApplicationException($"{(int)response.Result.StatusCode} {response.Result.ReasonPhrase}: {response.Result.RequestMessage}");
            }

            var data = JsonConvert.DeserializeObject<T>(responseData);

            ViewBag.NavigationHelper = NavigationHelper;

            return View(data);
        }

        protected async Task<ActionResult> editPostHelper(T item)
        {
            if (!ModelState.IsValid)
            {
                return View(item);
            }

            var url = $"{_defaultType}/Update";

            return await processAction(item, url, false).ConfigureAwait(false);
        }

        protected async Task<ActionResult> deleteHelper(int? id, string controllerName = null)
        {
            if (!id.HasValue)
            {
                return new BadRequestResult();
            }

            var url = $"{_defaultType}/Delete/{id}";

            var response = WebApiHelper.DeleteWebApiResponseAsHttpResponseMessage(url);
            await (await response.ConfigureAwait(false)).Content.ReadAsStringAsync().ConfigureAwait(false);

            if (!response.Result.IsSuccessStatusCode)
            {
                throw new ApplicationException($"{(int)response.Result.StatusCode} {response.Result.ReasonPhrase}: {response.Result.RequestMessage}");
            }

            return RedirectToAction("Index", controllerName);
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
            if (NavigationHelper.Count == 0)
            {
                return new OkResult();
            }

            TempData["FromBack"] = true;

            var uri = new Uri(NavigationHelper.Remove());
            saveNavigationHelper();
            return Redirect(uri.AbsoluteUri);
        }

        protected void addToNavigationHelper()
        {
            var fromBack = TempData["FromBack"] as bool?;
            if (fromBack == null || !fromBack.Value)
            {
                NavigationHelper.Add(Request.Headers["Referer"].First(), Request.GetDisplayUrl());
                saveNavigationHelper();
            }
        }

        protected string getUserId()
        {
            return HttpContext.Session.GetString("UserId");
        }

        private void saveNavigationHelper()
        {
            var json = _navigationHelper.ToJson();
            HttpContext.Session.SetString("NavigationHelper", json);
        }

        private async Task<ActionResult> processAction(T item, string url, bool doPost)
        {
            var validationError = false;

            var response = doPost ?
                WebApiHelper.PostWebApiResponseAsHttpResponseMessage(url, item) :
                WebApiHelper.PutWebApiResponseAsHttpResponseMessage(url, item);
            var responseData = await (await response.ConfigureAwait(false)).Content.ReadAsStringAsync().ConfigureAwait(false);

            if (response.Result.IsSuccessStatusCode)
            {
                return RedirectToAction("Back");
            }

            ViewBag.NavigationHelper = NavigationHelper;

            if (responseData.Contains("ORA-00001"))
            {
                ModelState.AddModelError("Name", "Name already exists");
                validationError = true;
            }

            if (!processActionResponse(responseData) || validationError)
            {
                return View(item);
            }

            throw new ApplicationException($"{(int)response.Result.StatusCode} {response.Result.ReasonPhrase}: {response.Result.RequestMessage}");
        }
    }
}
