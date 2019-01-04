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
            Request.HttpContext.Response.Headers["X-Total-Count"] = result.ToList()?.Count.ToString();
            Request.HttpContext.Response.Headers["Access-Control-Expose-Headers"] = "X-Total-Count";
            return result;
        }

        // GET: api/Transaction/5
        [HttpGet("{id}")]
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
        public IActionResult Post([FromBody] Transaction transaction)
        {
            //todo - refactor whole process

            try
            {
                //get balance
                var balance = _context.Balances.FirstOrDefault(x => x.ProductId == transaction.ProductId);

                if (transaction.Type == TransactionType.SELL && balance.StockQuantity < transaction.Quantity)
                {
                    throw new Exception("This quantity is not available");
                }

                transaction.CreatedAt = DateTime.Now;
                transaction.CreatedBy = "shahin";
                _context.Transactions.Add(transaction);

                if (balance == null)
                {
                    _context.Add(new Balance
                    {
                        ProductId = transaction.ProductId,
                        StockQuantity = transaction.Quantity,
                        TotalQuantity = transaction.Quantity,
                        PurchaseAmount = transaction.Amount,
                    });

                }
                else
                {
                    if (transaction.Type == TransactionType.BUY)
                    {
                        balance.StockQuantity += transaction.Quantity;
                        balance.TotalQuantity += transaction.Quantity;
                        balance.PurchaseAmount += transaction.Amount;

                    }
                    else
                    {
                        balance.StockQuantity -= transaction.Quantity;
                        balance.SellingAmount += transaction.Amount;
                    }
                    _context.Update(balance);
                }

                _context.SaveChanges();

            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.StackTrace);
            }

            return Ok(transaction);

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
