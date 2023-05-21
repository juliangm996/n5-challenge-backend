using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using N5.Challenge.Api.Domain.QueryHandler;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace N5.Challenge.Api.Controllers
{
    [Route("api/[controller]")]
    public class PermissionController : Controller
    {

        private readonly PermissionQueryHandler permissionQueryHandler;

        public PermissionController(PermissionQueryHandler permissionQueryHandler)
        {
            this.permissionQueryHandler = permissionQueryHandler;
        }


        [HttpGet]
        [Route("[action]")]
        public IActionResult GetPermissions()
        {
            return Ok(permissionQueryHandler.GetPermissions());
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

