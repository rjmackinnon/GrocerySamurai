namespace MagicHamster.GrocerySamurai.ServiceLayer.Controllers
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using BusinessLayer.Interfaces;
    using Microsoft.AspNetCore.Mvc;
    using Model.Entities;

    [Route("api/[controller]")]
    public class StoreItemController : BaseController<StoreItem>
    {
        public StoreItemController(IBaseProcess<StoreItem> process)
            : base(process)
        {
            childProperties = new List<string> { "Aisle", "Store", "Item" };
        }

        // GET: api/StoreItem/GetAll
        [HttpGet("GetAll")]
        public override Task<IActionResult> GetAll(string userId = null, int? pageSize = 0)
        {
            return getAllHelper(e => e.Id, pageSize);
        }

        // GET: api/StoreItem/Get/1
        [HttpGet("{id:int}", Name = "GetStoreItem")]
        public override Task<IActionResult> Get(int? id)
        {
            return getHelper(id);
        }

        // POST: api/StoreItem/Add
        [HttpPost("Add")]
        public override Task<IActionResult> Add([FromBody]StoreItem record)
        {
            return addHelper(record);
        }

        // PUT: api/StoreItem/Update
        [HttpPut("Update")]
        public override Task<IActionResult> Update([FromBody]StoreItem record)
        {
            return updateHelper(record);
        }

        // DELETE: api/StoreItem/Delete
        [HttpDelete("{id:int}")]
        public override Task<IActionResult> Delete(int id)
        {
            return deleteHelper(id);
        }
    }
}