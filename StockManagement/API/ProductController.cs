﻿using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using StockManagement.Data;
using System.Linq;
using System;

namespace StockManagement.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly StockManagementContext _context;

        public ProductController(StockManagementContext context)
        {
            _context = context;
        }

        // GET: api/Product
        [HttpGet]
        public IEnumerable<Product> Get()
        {
            var result = _context.Products.OrderByDescending(x => x.Id);
            return result;
        }

        // GET: api/Product/5
        [HttpGet("{id}", Name = "Get")]
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
        public void Post([FromBody] Product product)
        {
            product.CratedAt = DateTime.Now;
            product.CreatedBy = "shahin";
            _context.Products.Add(product);
            _context.SaveChanges();
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
