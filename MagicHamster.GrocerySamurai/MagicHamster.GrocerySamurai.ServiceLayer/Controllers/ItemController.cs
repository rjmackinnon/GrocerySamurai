using System.Threading.Tasks;
using MagicHamster.GrocerySamurai.BusinessLayer.Interfaces;
using MagicHamster.GrocerySamurai.Model.Entities;
using Microsoft.AspNetCore.Mvc;

namespace MagicHamster.GrocerySamurai.ServiceLayer.Controllers
{
    [Route("api/[controller]")]
    public class ItemController : BaseUserFilterController<Item>
    {
        public ItemController(IBaseUserFilterProcess<Item> process) : base(process)
        {
        }

        // GET: api/Item/GetAll
        [HttpGet("GetAll/{userId}")]
        public override async Task<IActionResult> GetAll(string userId = null, int? pageSize = 0)
        {
            return await getAllHelper(userId, e=> e.Id, pageSize);
        }

        // GET: api/Item/Get/1
        [HttpGet("{id:int}")]
        public override async Task<IActionResult> Get(int? id)
        {
            return await getHelper(id);
        }

        // POST: api/Item/Add
        [HttpPost("Add")]
        public override async Task<IActionResult> Add([FromBody]Item record)
        {
            return await addHelper(record);
        }

        // PUT: api/Item/Update
        [HttpPut("Update")]
        public override async Task<IActionResult> Update([FromBody]Item record)
        {
            return await updateHelper(record);
        }

        // DELETE: api/Item/Delete
        [HttpDelete("{id:int}")]
        public override async Task<IActionResult> Delete(int id)
        {
            return await deleteHelper(id);
        }
    }
}