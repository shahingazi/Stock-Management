using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using StockManagement.Data;
using System.Linq;
using System;
using Microsoft.AspNetCore.Authorization;

namespace StockManagement.API
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ProductController : BaseController
    {
        private readonly StockManagementContext _context;

        public ProductController(StockManagementContext context): base(context)
        {
            _context = context;
        }

        // GET: api/Product
        [HttpGet]
        public IEnumerable<Product> Get(int? companyId)
        {
            if(companyId == null)
            {
                companyId = GetMyAccessRights().FirstOrDefault(x => x.DefaultCompany).CompanyId;
            }

            var result = _context.Products.Where( x => GetMyAccessRights().Select(z => z.CompanyId)
                    .Contains(x.CompanyId) && x.CompanyId == companyId).OrderByDescending(x => x.Id);
            Request.HttpContext.Response.Headers["X-Total-Count"] = result.ToList()?.Count.ToString();
            Request.HttpContext.Response.Headers["Access-Control-Expose-Headers"] = "X-Total-Count";
            return result;
        }

        // GET: api/Product/5
        [HttpGet("{id}")]
        public ActionResult<Product> Get(int id)
        {
            var product = _context.Products.Find(id);
            if (product == null)
            {
                return NotFound();
            }

            return product;
        }

        // POST: api/Product
        [HttpPost]
        public ActionResult<Product> Post([FromBody] Product product)
        {
            product.CreatedAt = DateTime.Now;
            product.CreatedBy = "shahin";
            _context.Products.Add(product);
            _context.SaveChanges();
            return product;

        }

        // PUT: api/Product/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Product formValue)
        {
            var product = _context.Products.Find(id);
            if (product == null)
            {
                return NotFound();
            }

            product.Name = formValue.Name;
            product.CompanyId = formValue.CompanyId;
            _context.Products.Update(product);
            _context.SaveChanges();
            return NoContent();
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var product = _context.Products.FirstOrDefault(x => x.Id == id);
            if (product == null)
            {
                return NotFound();
            }

            _context.Products.Remove(product);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
