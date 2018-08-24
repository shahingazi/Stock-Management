using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using StockManagement.Data;

namespace StockManagement.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        private readonly StockManagementContext _context;

        public TransactionController(StockManagementContext context)
        {
            _context = context;
        }

        // GET: api/Transaction
        [HttpGet]
        public IEnumerable<Transaction> Get()
        {
            var result = _context.Transactions.OrderByDescending(x => x.Id);
            return result;
        }

        // GET: api/Transaction/5
        [HttpGet("{id}", Name = "Get")]
        public ActionResult<Transaction> Get(int id)
        {
            var product = _context.Transactions.Find(id);
            if (product == null)
            {
                return NotFound();
            }

            return product;
        }

        // POST: api/Transaction
        [HttpPost]
        public void Post([FromBody] Transaction transaction)
        {
            transaction.CreatedAt = DateTime.Now;
            transaction.CreatedBy = "shahin";
            _context.Transactions.Add(transaction);
            _context.SaveChanges();
        }

        // PUT: api/Transaction/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Transaction formValue)
        {
            var transaction = _context.Transactions.Find(id);
            if (transaction == null)
            {
                return NotFound();
            }

            _context.Transactions.Update(transaction);
            _context.SaveChanges();
            return NoContent();
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var transaction = _context.Transactions.FirstOrDefault(x => x.Id == id);
            if (transaction == null)
            {
                return NotFound();
            }

            _context.Transactions.Remove(transaction);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
