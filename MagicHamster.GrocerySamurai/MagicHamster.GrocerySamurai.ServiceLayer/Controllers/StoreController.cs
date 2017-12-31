using MagicHamster.GrocerySamurai.BusinessLayer.Interfaces;
using MagicHamster.GrocerySamurai.Model.Entities;
using Microsoft.AspNetCore.Mvc;

namespace MagicHamster.GrocerySamurai.ServiceLayer.Controllers
{
    [Route("api/[controller]")]
    public class StoreController : BaseUserFilterController<Store>
    {
        public StoreController(IBaseUserFilterProcess<Store> process) : base(process)
        {
        }

        // GET: api/Store/GetAll
        [HttpGet("GetAll/{userId}")]
        public override IActionResult GetAll(string userId = null, int? pageSize = 0)
        {
            return getAllHelper(userId, e=> e.Id, pageSize);
        }

        // GET: api/Store/Get/1
        [HttpGet("Get/{id:int}")]
        public override IActionResult Get(int? id)
        {
            return getHelper(id);
        }

        // POST: api/Store/Add
        [HttpPost("Add")]
        public override IActionResult Add([FromBody]Store record)
        {
            return addHelper(record);
        }

        // PUT: api/Store/Update
        [HttpPut("Update")]
        public override IActionResult Update([FromBody]Store record)
        {
            return updateHelper(record);
        }

        // DELETE: api/Store/Delete
        [HttpDelete("{id:int}")]
        public override IActionResult Delete(int id)
        {
            return deleteHelper(id);
        }
    }
}