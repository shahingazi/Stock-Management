using System;
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
    public class CompanyController : BaseController
    {
        private readonly StockManagementContext _context;
       

        public CompanyController(StockManagementContext context)
        {
            _context = context;
           
        }

        // GET: api/Company
        [HttpGet]
        public IEnumerable<Company> Get()
        {          
            var result = _context.Companies;
            Request.HttpContext.Response.Headers["X-Total-Count"] = result.ToList()?.Count.ToString();
            Request.HttpContext.Response.Headers["Access-Control-Expose-Headers"] = "X-Total-Count";            
            return result;
        }

        // GET: api/Company/5
        [HttpGet("{id}", Name = "Get")]
        public ActionResult<Company> Get(int id)
        {
            var company = _context.Companies.Find(id);

            if (company == null)
            {
                return NotFound();
            }

            return company;
        }

        // POST: api/Company
        [HttpPost]
        public ActionResult<Company> Post([FromBody] Company company)
        {
            _context.Companies.Add(company);
            _context.SaveChanges();
            var accessright = new UserAccessRight
            {
                CompanyId = company.Id,
                DefaultCompany = true,
                IsActive = true,
                Role = AccessRight.Admin,
                UserId = CurrentUserId,
                CreatedAt = DateTime.Now
            };
            _context.Add(accessright);
            _context.SaveChanges();            
            return company;
        }

        // PUT: api/Company/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Company value)
        {
            var company = _context.Companies.Find(id);
            if (company == null)
            {
                return NotFound();
            }

            company.Name = value.Name;
            _context.Companies.Update(company);
            _context.SaveChanges();
            return NoContent();
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var company = _context.Companies.FirstOrDefault(x => x.Id == id);
            if (company == null)
            {
                return NotFound();
            }

            _context.Companies.Remove(company);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
