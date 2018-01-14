using System.Threading.Tasks;
using MagicHamster.GrocerySamurai.BusinessLayer.Interfaces;
using MagicHamster.GrocerySamurai.Model.Entities;
using Microsoft.AspNetCore.Mvc;

namespace MagicHamster.GrocerySamurai.ServiceLayer.Controllers
{
    [Route("api/[controller]")]
    public class AisleController : BaseUserFilterController<Aisle>
    {
        public AisleController(IBaseUserFilterProcess<Aisle> process) : base(process)
        {
        }

        // GET: api/Aisle/GetAll
        [HttpGet("GetAll/{userId}")]
        public override async Task<IActionResult> GetAll(string userId = null, int? pageSize = 0)
        {
            return await getAllHelper(userId, e=> e.Id, pageSize);
        }

        // GET: api/Aisle/Get/1
        [HttpGet("{id:int}")]
        public override async Task<IActionResult> Get(int? id)
        {
            return await getHelper(id);
        }

        // POST: api/Aisle/Add
        [HttpPost("Add")]
        public override async Task<IActionResult> Add([FromBody]Aisle record)
        {
            return await addHelper(record);
        }

        // PUT: api/Aisle/Update
        [HttpPut("Update")]
        public override async Task<IActionResult> Update([FromBody]Aisle record)
        {
            return await updateHelper(record);
        }

        // DELETE: api/Aisle/Delete
        [HttpDelete("{id:int}")]
        public override async Task<IActionResult> Delete(int id)
        {
            return await deleteHelper(id);
        }
    }
}