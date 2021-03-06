﻿namespace MagicHamster.GrocerySamurai.ServiceLayer.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Net;
    using System.Threading.Tasks;
    using BusinessLayer.Interfaces;
    using BusinessLayer.Processes;
    using Microsoft.AspNetCore.Mvc;
    using Model.Entities;

    [Route("api/[controller]")]
    public class GroceryListController : BaseController<GroceryList>
    {
        public GroceryListController(IBaseProcess<GroceryList> process)
            : base(process)
        {
            childProperties = new List<string> { "Store" };
        }

        // GET: api/GroceryList/GetAll
        [HttpGet("GetAll")]
        public override Task<IActionResult> GetAll(string userId = null, int? pageSize = 0)
        {
            return getAllHelper(e => e.Id, pageSize);
        }

        // GET: api/GroceryList/GetAllByStore
        [HttpGet("GetAllByStore/{storeId:int}")]
        public async Task<IActionResult> GetAllByStore(int? storeId = null, int? pageSize = 0)
        {
            if (storeId == null)
            {
                return BadRequest("No store ID provided.");
            }

            try
            {
                var data = await ((GroceryListProcess)BusinessProcess).GetAllByStore(storeId.Value, e => e.Id, childProperties, pageSize ?? 0).ConfigureAwait(false);
                return Ok(data);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.GetBaseException().Message);
            }
        }

        // GET: api/GroceryList/Get/1
        [HttpGet("{id:int}", Name = "GetGroceryList")]
        public override Task<IActionResult> Get(int? id)
        {
            return getHelper(id);
        }

        // POST: api/GroceryList/Add
        [HttpPost("Add")]
        public override Task<IActionResult> Add([FromBody]GroceryList record)
        {
            return addHelper(record);
        }

        // PUT: api/GroceryList/Update
        [HttpPut("Update")]
        public override Task<IActionResult> Update([FromBody]GroceryList record)
        {
            return updateHelper(record);
        }

        // DELETE: api/GroceryList/Delete
        [HttpDelete("{id:int}")]
        public override Task<IActionResult> Delete(int id)
        {
            return deleteHelper(id);
        }
    }
}