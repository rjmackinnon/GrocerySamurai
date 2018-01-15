using System.Threading.Tasks;
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
        public override async Task<IActionResult> GetAll(string userId = null, int? pageSize = 0)
        {
            return await getAllHelper(userId, e=> e.Id, pageSize);
        }

        // GET: api/Store/Get/1
        [HttpGet("{id:int}", Name = "GetStore")]
        public override async Task<IActionResult> Get(int? id)
        {
            return await getHelper(id);
        }

        // POST: api/Store/Add
        [HttpPost("Add")]
        public override async Task<IActionResult> Add([FromBody]Store record)
        {
            return await addHelper(record);
        }

        // PUT: api/Store/Update
        [HttpPut("Update")]
        public override async Task<IActionResult> Update([FromBody]Store record)
        {
            return await updateHelper(record);
        }

        // DELETE: api/Store/Delete
        [HttpDelete("Delete/{id:int}")]
        public override async Task<IActionResult> Delete(int id)
        {
            return await deleteHelper(id);
        }
    }
}