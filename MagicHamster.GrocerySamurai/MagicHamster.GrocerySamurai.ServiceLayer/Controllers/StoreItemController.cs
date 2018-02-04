using System.Collections.Generic;
using System.Threading.Tasks;
using MagicHamster.GrocerySamurai.BusinessLayer.Interfaces;
using MagicHamster.GrocerySamurai.Model.Entities;
using Microsoft.AspNetCore.Mvc;

namespace MagicHamster.GrocerySamurai.ServiceLayer.Controllers
{
    [Route("api/[controller]")]
    public class StoreItemController : BaseController<StoreItem>
    {
        public StoreItemController(IBaseProcess<StoreItem> process) : base(process)
        {
            childProperties = new List<string> { "Aisle", "Store", "Item" };
        }

        // GET: api/StoreItem/GetAll
        [HttpGet("GetAll")]
        public override async Task<IActionResult> GetAll(string userId = null, int? pageSize = 0)
        {
            return await getAllHelper(e=> e.Id, pageSize);
        }

        // GET: api/StoreItem/Get/1
        [HttpGet("{id:int}", Name = "GetStoreItem")]
        public override async Task<IActionResult> Get(int? id)
        {
            return await getHelper(id);
        }

        // POST: api/StoreItem/Add
        [HttpPost("Add")]
        public override async Task<IActionResult> Add([FromBody]StoreItem record)
        {
            return await addHelper(record);
        }

        // PUT: api/StoreItem/Update
        [HttpPut("Update")]
        public override async Task<IActionResult> Update([FromBody]StoreItem record)
        {
            return await updateHelper(record);
        }

        // DELETE: api/StoreItem/Delete
        [HttpDelete("{id:int}")]
        public override async Task<IActionResult> Delete(int id)
        {
            return await deleteHelper(id);
        }
    }
}