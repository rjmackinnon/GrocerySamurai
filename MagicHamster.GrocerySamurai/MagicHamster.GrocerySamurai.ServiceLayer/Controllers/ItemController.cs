using MagicHamster.GrocerySamurai.BusinessLayer.Interfaces;
using MagicHamster.GrocerySamurai.Model.Entities;
using Microsoft.AspNetCore.Mvc;

namespace MagicHamster.GrocerySamurai.ServiceLayer.Controllers
{
    [Route("api/[controller]")]
    public class ItemController : BaseController<Item>
    {
        public ItemController(IBaseProcess<Item> process) : base(process)
        {
            //childProperties = new List<string> { "MasterItem" };
        }

        // GET: api/Item/GetAll
        [HttpGet("GetAll")]
        public override IActionResult GetAll(int? pageSize = 0)
        {
            return getAllHelper(e=> e.Id, pageSize);
        }

        // GET: api/Item/Get/1
        [HttpGet("{id:int}")]
        public override IActionResult Get(int? id)
        {
            return getHelper(id);
        }

        // POST: api/Item/Add
        [HttpPost("Add")]
        public override IActionResult Add([FromBody]Item record)
        {
            return addHelper(record);
        }

        // PUT: api/Item/Update
        [HttpPut("Update")]
        public override IActionResult Update([FromBody]Item record)
        {
            return updateHelper(record);
        }

        // DELETE: api/Item/Delete
        [HttpDelete("{id:int}")]
        public override IActionResult Delete(int id)
        {
            return deleteHelper(id);
        }
    }
}