namespace MagicHamster.GrocerySamurai.ServiceLayer.Controllers
{
    using System.Threading.Tasks;
    using MagicHamster.GrocerySamurai.BusinessLayer.Interfaces;
    using MagicHamster.GrocerySamurai.Model.Entities;
    using Microsoft.AspNetCore.Mvc;

    [Route("api/[controller]")]
    public class AisleController : BaseUserFilterController<Aisle>
    {
        public AisleController(IBaseUserFilterProcess<Aisle> process)
            : base(process)
        {
        }

        // GET: api/Aisle/GetAll
        [HttpGet("GetAll/{userId}")]
        public override Task<IActionResult> GetAll(string userId = null, int? pageSize = 0)
        {
            return getAllHelper(userId, e => e.Id, pageSize);
        }

        // GET: api/Aisle/Get/1
        [HttpGet("{id:int}", Name = "GetAisle")]
        public override Task<IActionResult> Get(int? id)
        {
            return getHelper(id);
        }

        // POST: api/Aisle/Add
        [HttpPost("Add")]
        public override Task<IActionResult> Add([FromBody]Aisle record)
        {
            return addHelper(record);
        }

        // PUT: api/Aisle/Update
        [HttpPut("Update")]
        public override Task<IActionResult> Update([FromBody]Aisle record)
        {
            return updateHelper(record);
        }

        // DELETE: api/Aisle/Delete
        [HttpDelete("{id:int}")]
        public override Task<IActionResult> Delete(int id)
        {
            return deleteHelper(id);
        }
    }
}