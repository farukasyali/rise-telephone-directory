using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhoneBook.Web.Controllers
{
    public class RaporController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
