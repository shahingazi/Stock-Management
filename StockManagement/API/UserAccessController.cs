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
    public class UserAccessController : BaseController
    {
        private readonly StockManagementContext _context;

        public UserAccessController(StockManagementContext context) : base(context)
        {
            _context = context;
        }

        // GET: api/Product
        [HttpGet]
        public IEnumerable<UserAccessRight> Get()
        {
            var result = _context.UserAccessRights
                .Where(x => GetMyAccessRights().Select(z => z.CompanyId)
                    .Contains(x.CompanyId));

            Request.HttpContext.Response.Headers["X-Total-Count"] = result.ToList()?.Count.ToString();
            Request.HttpContext.Response.Headers["Access-Control-Expose-Headers"] = "X-Total-Count";
            return result;
        }

        // GET: api/Product/5
        [HttpGet("{id}")]
        public ActionResult<UserAccessRight> Get(int id)
        {
            //todo access right
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
        public IActionResult Put(int id, [FromBody] UserAccessRight formValue)
        {
            //todo access right
            var userAccessRight = _context.UserAccessRights.Find(id);
            if (userAccessRight == null)
            {
                return NotFound();
            }

            userAccessRight.IsActive = formValue.IsActive;
            userAccessRight.Role = formValue.Role;
            userAccessRight.CompanyId = formValue.CompanyId;
            userAccessRight.DefaultCompany = formValue.DefaultCompany;
            _context.UserAccessRights.Update(userAccessRight);
            _context.SaveChanges();
            return NoContent();
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            //todo access right
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
