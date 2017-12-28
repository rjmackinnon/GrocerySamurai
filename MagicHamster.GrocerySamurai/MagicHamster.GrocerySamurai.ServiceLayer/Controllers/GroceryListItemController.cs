using MagicHamster.GrocerySamurai.BusinessLayer.Interfaces;
using MagicHamster.GrocerySamurai.Model.Entities;
using Microsoft.AspNetCore.Mvc;

namespace MagicHamster.GrocerySamurai.ServiceLayer.Controllers
{
    [Route("api/[controller]")]
    public class GroceryListItemController : BaseController<GroceryListItem>
    {
        public GroceryListItemController(IBaseProcess<GroceryListItem> process) : base(process)
        {
            //childProperties = new List<string> { "MasterGroceryListItem" };
        }

        // GET: api/GroceryListItem/GetAll
        [HttpGet("GetAll")]
        public override IActionResult GetAll(int? pageSize = 0)
        {
            return getAllHelper(e=> e.Id, pageSize);
        }

        // GET: api/GroceryListItem/Get/1
        [HttpGet("{id:int}")]
        public override IActionResult Get(int? id)
        {
            return getHelper(id);
        }

        // POST: api/GroceryListItem/Add
        [HttpPost("Add")]
        public override IActionResult Add([FromBody]GroceryListItem record)
        {
            return addHelper(record);
        }

        // PUT: api/GroceryListItem/Update
        [HttpPut("Update")]
        public override IActionResult Update([FromBody]GroceryListItem record)
        {
            return updateHelper(record);
        }

        // DELETE: api/GroceryListItem/Delete
        [HttpDelete("{id:int}")]
        public override IActionResult Delete(int id)
        {
            return deleteHelper(id);
        }
    }
}