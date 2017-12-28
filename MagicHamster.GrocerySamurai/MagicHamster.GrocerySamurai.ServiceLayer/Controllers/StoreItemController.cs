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
            //childProperties = new List<string> { "MasterStoreItem" };
        }

        // GET: api/StoreItem/GetAll
        [HttpGet("GetAll")]
        public override IActionResult GetAll(int? pageSize = 0)
        {
            return getAllHelper(e=> e.Id, pageSize);
        }

        // GET: api/StoreItem/Get/1
        [HttpGet("{id:int}")]
        public override IActionResult Get(int? id)
        {
            return getHelper(id);
        }

        // POST: api/StoreItem/Add
        [HttpPost("Add")]
        public override IActionResult Add([FromBody]StoreItem record)
        {
            return addHelper(record);
        }

        // PUT: api/StoreItem/Update
        [HttpPut("Update")]
        public override IActionResult Update([FromBody]StoreItem record)
        {
            return updateHelper(record);
        }

        // DELETE: api/StoreItem/Delete
        [HttpDelete("{id:int}")]
        public override IActionResult Delete(int id)
        {
            return deleteHelper(id);
        }
    }
}