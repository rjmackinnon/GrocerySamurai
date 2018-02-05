namespace MagicHamster.GrocerySamurai.ServiceLayer.Controllers
{
    using System.Threading.Tasks;
    using MagicHamster.GrocerySamurai.BusinessLayer.Interfaces;
    using MagicHamster.GrocerySamurai.Model.Entities;
    using Microsoft.AspNetCore.Mvc;

    [Route("api/[controller]")]
    public class StoreController : BaseUserFilterController<Store>
    {
        public StoreController(IBaseUserFilterProcess<Store> process)
            : base(process)
        {
        }

        // GET: api/Store/GetAll
        [HttpGet("GetAll/{userId}")]
        public override Task<IActionResult> GetAll(string userId = null, int? pageSize = 0)
        {
            return getAllHelper(userId, e => e.Id, pageSize);
        }

        // GET: api/Store/Get/1
        [HttpGet("{id:int}", Name = "GetStore")]
        public override Task<IActionResult> Get(int? id)
        {
            return getHelper(id);
        }

        // POST: api/Store/Add
        [HttpPost("Add")]
        public override Task<IActionResult> Add([FromBody]Store record)
        {
            return addHelper(record);
        }

        // PUT: api/Store/Update
        [HttpPut("Update")]
        public override Task<IActionResult> Update([FromBody]Store record)
        {
            return updateHelper(record);
        }

        // DELETE: api/Store/Delete
        [HttpDelete("Delete/{id:int}")]
        public override Task<IActionResult> Delete(int id)
        {
            return deleteHelper(id);
        }
    }
}