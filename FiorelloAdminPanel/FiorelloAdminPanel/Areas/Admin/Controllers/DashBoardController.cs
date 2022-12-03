using FiorelloAdminPanel.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace FiorelloAdminPanel.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class DashboardController : Controller
    {
        
        public  IActionResult Index()
        {
            
            return View();
        }
    }
}
