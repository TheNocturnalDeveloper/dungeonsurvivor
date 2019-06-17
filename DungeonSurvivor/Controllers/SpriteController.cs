using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DungeonSurvivor.Models;
using System.IO;
using Microsoft.AspNetCore.Hosting;

namespace DungeonSurvivor.Controllers
{
    [Route("sprite")]
    public class SpriteController : Controller
    {
        private IHostingEnvironment env;

        public SpriteController(IHostingEnvironment env)
        {
            this.env = env;
        }

        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        [Route("product/{name}")]
        public IActionResult Product()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("product/{name}")]
        public IActionResult Product(string name)
        {
            return View();
        }


        [HttpGet]
        [Route("add")]
        public IActionResult AddSprite()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("add")]
        public IActionResult AddSprite(AddSpriteViewModel sprite)
        {
            if(!ModelState.IsValid) return View(sprite);

            var relPath = $@"sprites\{sprite.name}.{sprite.image.FileName.Split('.').Last()}";
            var absPath = $@"{env.WebRootPath}\{relPath}";

            using (var stream = System.IO.File.Create(absPath))
            {

            }


            return View();
        }
    }
}