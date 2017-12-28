using MagicHamster.GrocerySamurai.BusinessLayer.Interfaces;
using MagicHamster.GrocerySamurai.Model.Entities;
using Microsoft.AspNetCore.Mvc;

namespace MagicHamster.GrocerySamurai.ServiceLayer.Controllers
{
    [Route("api/[controller]")]
    public class AisleController : BaseController<Aisle>
    {
        public AisleController(IBaseProcess<Aisle> process) : base(process)
        {
            //childProperties = new List<string> { "MasterAisle" };
        }

        // GET: api/Aisle/GetAll
        [HttpGet("GetAll")]
        public override IActionResult GetAll(int? pageSize = 0)
        {
            return getAllHelper(e=> e.Id, pageSize);
        }

        // GET: api/Aisle/Get/1
        [HttpGet("{id:int}")]
        public override IActionResult Get(int? id)
        {
            return getHelper(id);
        }

        // POST: api/Aisle/Add
        [HttpPost("Add")]
        public override IActionResult Add([FromBody]Aisle record)
        {
            return addHelper(record);
        }

        // PUT: api/Aisle/Update
        [HttpPut("Update")]
        public override IActionResult Update([FromBody]Aisle record)
        {
            return updateHelper(record);
        }

        // DELETE: api/Aisle/Delete
        [HttpDelete("{id:int}")]
        public override IActionResult Delete(int id)
        {
            return deleteHelper(id);
        }
    }
}