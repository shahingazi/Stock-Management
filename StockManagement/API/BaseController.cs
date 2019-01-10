using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using StockManagement.Data;
using StockManagement.Dtos;

namespace StockManagement.API
{
    public class BaseController : ControllerBase
    {
        private readonly StockManagementContext _context;

        public BaseController(StockManagementContext context)
        {
            _context = context;
        }

        protected List<MyAccessRight> GetMyAccessRights()
        {
            var result = _context.UserAccessRights.Where(x => x.UserId == CurrentUserId);
            return result.Select(x => new MyAccessRight
            {
                CompanyId = x.CompanyId,
                Role = x.Role
            }).ToList();
        }

        public int CurrentUserId => int.Parse(User.Identity.Name);

    }
}