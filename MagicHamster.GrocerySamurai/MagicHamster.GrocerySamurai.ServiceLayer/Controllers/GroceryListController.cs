using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using MagicHamster.GrocerySamurai.BusinessLayer.Interfaces;
using MagicHamster.GrocerySamurai.BusinessLayer.Processes;
using MagicHamster.GrocerySamurai.Model.Entities;
using Microsoft.AspNetCore.Mvc;

namespace MagicHamster.GrocerySamurai.ServiceLayer.Controllers
{
    [Route("api/[controller]")]
    public class GroceryListController : BaseController<GroceryList>
    {
        public GroceryListController(IBaseProcess<GroceryList> process) : base(process)
        {
            childProperties = new List<string> { "Store" };
        }

        // GET: api/GroceryList/GetAll
        [HttpGet("GetAll")]
        public override async Task<IActionResult> GetAll(string userId = null, int? pageSize = 0)
        {
            return await getAllHelper(e=> e.Id, pageSize);
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
                var data = await((GroceryListProcess)BusinessProcess).GetAllByStore(storeId.Value, e => e.Id, childProperties, pageSize ?? 0);
                return Ok(data);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.GetBaseException().Message);
            }
        }

        // GET: api/GroceryList/Get/1
        [HttpGet("{id:int}", Name = "GetGroceryList")]
        public override async Task<IActionResult> Get(int? id)
        {
            return await getHelper(id);
        }

        // POST: api/GroceryList/Add
        [HttpPost("Add")]
        public override async Task<IActionResult> Add([FromBody]GroceryList record)
        {
            return await addHelper(record);
        }

        // PUT: api/GroceryList/Update
        [HttpPut("Update")]
        public override async Task<IActionResult> Update([FromBody]GroceryList record)
        {
            return await updateHelper(record);
        }

        // DELETE: api/GroceryList/Delete
        [HttpDelete("{id:int}")]
        public override async Task<IActionResult> Delete(int id)
        {
            return await deleteHelper(id);
        }
    }
}