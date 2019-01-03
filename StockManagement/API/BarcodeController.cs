using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using StockManagement.Data;

namespace StockManagement.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class BarcodeController : ControllerBase
    {
        private readonly StockManagementContext _context;

        public BarcodeController(StockManagementContext context)
        {
            _context = context;
        }

        // GET: api/Product
        [HttpGet]
        public IEnumerable<Barcode> Get()
        {
            var result = _context.Barcodes.OrderByDescending(x => x.Id);
            Request.HttpContext.Response.Headers["X-Total-Count"] = result.ToList()?.Count.ToString();
            Request.HttpContext.Response.Headers["Access-Control-Expose-Headers"] = "X-Total-Count";
            return result;
        }

        // GET: api/Product/5
        [HttpGet("{id}")]
        public ActionResult<Barcode> Get(int id)
        {
            var barcode = _context.Barcodes.Find(id);
            if (barcode == null)
            {
                return NotFound();
            }

            return barcode;
        }

        // POST: api/Product
        [HttpPost]
        public ActionResult<Barcode> Post([FromBody] Barcode barcode)
        {
            _context.Barcodes.Add(barcode);
            _context.SaveChanges();
            return barcode;

        }

        // PUT: api/Product/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Barcode formValue)
        {
            var barcode = _context.Barcodes.Find(id);
            if (barcode == null)
            {
                return NotFound();
            }            
            _context.Barcodes.Update(barcode);
            _context.SaveChanges();
            return NoContent();
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var barcode = _context.Barcodes.FirstOrDefault(x => x.Id == id);
            if (barcode == null)
            {
                return NotFound();
            }

            _context.Barcodes.Remove(barcode);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
