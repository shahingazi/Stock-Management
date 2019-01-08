using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace StockManagement.API
{
    public class BaseController : ControllerBase
    {
        public int CurrentUserId => int.Parse(User.Identity.Name);
            
    }
}