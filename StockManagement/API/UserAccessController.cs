using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StockManagement.Data;

namespace StockManagement.API
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UserAccessController : ControllerBase
    {
        private readonly StockManagementContext _context;

        public UserAccessController(StockManagementContext context)
        {
            _context = context;
        }

        // GET: api/Product
        [HttpGet]
        public IEnumerable<UserAccessRight> Get()
        {
            var result = _context.UserAccessRights.OrderByDescending(x => x.Id);
            Request.HttpContext.Response.Headers["X-Total-Count"] = result.ToList()?.Count.ToString();
            Request.HttpContext.Response.Headers["Access-Control-Expose-Headers"] = "X-Total-Count";
            return result;
        }

        // GET: api/Product/5
        [HttpGet("{id}")]
        public ActionResult<UserAccessRight> Get(int id)
        {
            var userAccessRight = _context.UserAccessRights.Find(id);
            if (userAccessRight == null)
            {
                return NotFound();
            }

            return userAccessRight;
        }

        // POST: api/Product
        [HttpPost]
        public ActionResult<UserAccessRight> Post([FromBody] UserAccessRight userAccessRight)
        {
            _context.UserAccessRights.Add(userAccessRight);
            _context.SaveChanges();
            return userAccessRight;

        }

        // PUT: api/Product/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Product formValue)
        {
            var userAccessRight = _context.UserAccessRights.Find(id);
            if (userAccessRight == null)
            {
                return NotFound();
            }
            
            _context.UserAccessRights.Update(userAccessRight);
            _context.SaveChanges();
            return NoContent();
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var userAccessRight = _context.UserAccessRights.FirstOrDefault(x => x.Id == id);
            if (userAccessRight == null)
            {
                return NotFound();
            }

            _context.UserAccessRights.Remove(userAccessRight);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
