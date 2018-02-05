namespace MagicHamster.GrocerySamurai.ServiceLayer.Controllers
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using MagicHamster.GrocerySamurai.BusinessLayer.Interfaces;
    using MagicHamster.GrocerySamurai.Model.Entities;
    using Microsoft.AspNetCore.Mvc;

    [Route("api/[controller]")]
    public class GroceryListItemController : BaseController<GroceryListItem>
    {
        public GroceryListItemController(IBaseProcess<GroceryListItem> process)
            : base(process)
        {
            childProperties = new List<string> { "GroceryList", "Item" };
        }

        // GET: api/GroceryListItem/GetAll
        [HttpGet("GetAll")]
        public override Task<IActionResult> GetAll(string userId = null, int? pageSize = 0)
        {
            return getAllHelper(e => e.Id, pageSize);
        }

        // GET: api/GroceryListItem/Get/1
        [HttpGet("{id:int}", Name = "GetGroceryListItem")]
        public override Task<IActionResult> Get(int? id)
        {
            return getHelper(id);
        }

        // POST: api/GroceryListItem/Add
        [HttpPost("Add")]
        public override Task<IActionResult> Add([FromBody]GroceryListItem record)
        {
            return addHelper(record);
        }

        // PUT: api/GroceryListItem/Update
        [HttpPut("Update")]
        public override Task<IActionResult> Update([FromBody]GroceryListItem record)
        {
            return updateHelper(record);
        }

        // DELETE: api/GroceryListItem/Delete
        [HttpDelete("{id:int}")]
        public override Task<IActionResult> Delete(int id)
        {
            return deleteHelper(id);
        }
    }
}