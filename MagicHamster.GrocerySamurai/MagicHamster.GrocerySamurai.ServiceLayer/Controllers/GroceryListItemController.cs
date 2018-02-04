using System.Collections.Generic;
using System.Threading.Tasks;
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
            childProperties = new List<string> { "GroceryList", "Item" };
        }

        // GET: api/GroceryListItem/GetAll
        [HttpGet("GetAll")]
        public override async Task<IActionResult> GetAll(string userId = null, int? pageSize = 0)
        {
            return await getAllHelper(e=> e.Id, pageSize);
        }

        // GET: api/GroceryListItem/Get/1
        [HttpGet("{id:int}", Name = "GetGroceryListItem")]
        public override async Task<IActionResult> Get(int? id)
        {
            return await getHelper(id);
        }

        // POST: api/GroceryListItem/Add
        [HttpPost("Add")]
        public override async Task<IActionResult> Add([FromBody]GroceryListItem record)
        {
            return await addHelper(record);
        }

        // PUT: api/GroceryListItem/Update
        [HttpPut("Update")]
        public override async Task<IActionResult> Update([FromBody]GroceryListItem record)
        {
            return await updateHelper(record);
        }

        // DELETE: api/GroceryListItem/Delete
        [HttpDelete("{id:int}")]
        public override async Task<IActionResult> Delete(int id)
        {
            return await deleteHelper(id);
        }
    }
}