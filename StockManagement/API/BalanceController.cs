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
    public class BalanceController : ControllerBase
    {
        private readonly StockManagementContext _context;

        public BalanceController(StockManagementContext context)
        {
            _context = context;
        }

        // GET: api/Transaction
        [HttpGet]
        public IEnumerable<Balance> Get()
        {
            var result = _context.Balances;
            Request.HttpContext.Response.Headers["X-Total-Count"] = result.ToList()?.Count.ToString();
            Request.HttpContext.Response.Headers["Access-Control-Expose-Headers"] = "X-Total-Count";
            return result;
        }        
    }
}
