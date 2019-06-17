using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace DungeonSurvivor.Controllers
{
    [Route("sprite")]
    public class SpriteController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        [Route("product/{name}/")]
        public IActionResult Product()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("product/{name}/purchase")]
        public IActionResult Product(string name)
        {
            return View();
        }
    }
}