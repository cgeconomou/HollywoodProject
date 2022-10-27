using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FinalApp.Areas.Admin.Controllers
{
    
    public class ProductController : Controller
    {
        // GET: Admin/Product
        public ActionResult ProductIndex()
        {
            return View();
        }

        public ActionResult ProductChartBar()
        {
            return View();
        }
    }
}