using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MathApp.Controllers
{
    public class MathController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Test(string message)
        {
            if(message == null)
            {
                message = "Query String parameter 'message' not received";
            }
            ViewBag.TheMessage = message;

            return View();
        }

        [HttpGet]
        public IActionResult Calculate()
        {
            return View();
        }

        [HttpPost]
        public IActionResult DoCalculation()
        {
             
            ViewData["selection"] = Request.Form["selection"];
            ViewData["left"] = Request.Form["left"];
            ViewData["right"] = Request.Form["Right"];

            int x, y, z;
            x = y = z = 0;

            if (ViewData["left"] == null || ViewData["right"] == null)
            {
                x = y = z = 0;
            }
            else
            {
                x = Convert.ToInt32(ViewData["left"].ToString());
                y = Convert.ToInt32(ViewData["right"].ToString());
            }

            if (ViewData["selection"].ToString() == "Add")
            {
                z = x + y;

            }else if(ViewData["selection"].ToString() == "Subtract")
            {
                z = x - y;
            }
            else if(ViewData["selection"].ToString() == "Multiply")
            {
                z = x * y;
            }
            else if (ViewData["selection"].ToString() == "Divide")
            {
                z = x / y;
            }
            else if (ViewData["selection"].ToString() == "Modulus")
            {
                z = x % y;
            }

            ViewData["result"] = z.ToString();

            return View();
        }

        public IActionResult Add(string left, string right)
        {
            int x, y, z;
            if(left == null || right == null)
            {
                x = y = z = 0;
            }
            x = Convert.ToInt32(left);
            y = Convert.ToInt32(right);
            z = x + y;
            ViewData["Left"] = x.ToString();
            ViewData["Right"] = y.ToString();
            ViewData["Sum"] = z.ToString();
            return View();
        }

        public IActionResult AddInTheView(string left, string right)
        {
            ViewData["Left"] = left;
            ViewData["Right"] = right;

            return View();
        }

        public IActionResult MathErrorMessage(string message)
        {
            if(message == null) { 
                message = "Nothing was entered";
            }
            ViewData["TheErrorMessage"] = message;
            return View();
        }
    }
}
