﻿using MagicHamster.GrocerySamurai.BusinessLayer.Interfaces;
using MagicHamster.GrocerySamurai.Model.Entities;
using Microsoft.AspNetCore.Mvc;

namespace MagicHamster.GrocerySamurai.ServiceLayer.Controllers
{
    [Route("api/[controller]")]
    public class GroceryListController : BaseController<GroceryList>
    {
        public GroceryListController(IBaseProcess<GroceryList> process) : base(process)
        {
            //childProperties = new List<string> { "MasterGroceryList" };
        }

        // GET: api/GroceryList/GetAll
        [HttpGet("GetAll")]
        public override IActionResult GetAll(int? pageSize = 0)
        {
            return getAllHelper(e=> e.Id, pageSize);
        }

        // GET: api/GroceryList/Get/1
        [HttpGet("{id:int}")]
        public override IActionResult Get(int? id)
        {
            return getHelper(id);
        }

        // POST: api/GroceryList/Add
        [HttpPost("Add")]
        public override IActionResult Add([FromBody]GroceryList record)
        {
            return addHelper(record);
        }

        // PUT: api/GroceryList/Update
        [HttpPut("Update")]
        public override IActionResult Update([FromBody]GroceryList record)
        {
            return updateHelper(record);
        }

        // DELETE: api/GroceryList/Delete
        [HttpDelete("{id:int}")]
        public override IActionResult Delete(int id)
        {
            return deleteHelper(id);
        }
    }
}