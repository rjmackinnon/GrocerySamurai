using MagicHamster.GrocerySamurai.BusinessLayer.Interfaces;
using MagicHamster.GrocerySamurai.Model.Entities;
using Microsoft.AspNetCore.Mvc;

namespace MagicHamster.GrocerySamurai.ServiceLayer.Controllers
{
    [Route("api/[controller]")]
    public class AppUserController : BaseController<AppUser>
    {
        public AppUserController(IBaseProcess<AppUser> process) : base(process)
        {
            //childProperties = new List<string> { "MasterAppUser" };
        }

        // GET: api/AppUser/GetAll
        [HttpGet("GetAll")]
        public override IActionResult GetAll(int? pageSize = 0)
        {
            return getAllHelper(e=> e.Id, pageSize);
        }

        // GET: api/AppUser/Get/1
        [HttpGet("{id:int}")]
        public override IActionResult Get(int? id)
        {
            return getHelper(id);
        }

        // POST: api/AppUser/Add
        [HttpPost("Add")]
        public override IActionResult Add([FromBody]AppUser record)
        {
            return addHelper(record);
        }

        // PUT: api/AppUser/Update
        [HttpPut("Update")]
        public override IActionResult Update([FromBody]AppUser record)
        {
            return updateHelper(record);
        }

        // DELETE: api/AppUser/Delete
        [HttpDelete("{id:int}")]
        public override IActionResult Delete(int id)
        {
            return deleteHelper(id);
        }
    }
}