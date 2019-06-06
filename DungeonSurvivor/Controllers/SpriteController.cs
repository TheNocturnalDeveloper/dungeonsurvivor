using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace DungeonSurvivor.Controllers
{
    public class SpriteController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}