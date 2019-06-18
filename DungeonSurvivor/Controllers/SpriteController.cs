using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DungeonSurvivor.Models;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using DAL;
using Logic;
using System.Security.Claims;

namespace DungeonSurvivor.Controllers
{
    [Route("sprite")]
    public class SpriteController : Controller
    {
        private IHostingEnvironment env;
        private SpriteLogic logic;

        public SpriteController(IHostingEnvironment env)
        {
            this.env = env;

            logic = new SpriteLogic(new SqlSpriteContext("Server=localhost;Database=dungeon_survivor;Uid=root;Pwd=test;"));
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
            var username = HttpContext.User.FindFirstValue("username");

            if (!logic.canBuySprite(username, name))
            {

            }

            logic.unlockSprite(username, name);

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
            
            var filename =  $"{sprite.name}.{sprite.image.FileName.Split('.').Last()}";
            var absPath = Path.Join(env.WebRootPath, "sprites", filename);

            if (logic.getSpriteByName(sprite.name) != null)
            {
                ModelState.AddModelError("name", "sprite name already exists");
                return View(sprite);
            }


            

            using (var stream = System.IO.File.Create(absPath))
            {
                sprite.image.CopyTo(stream);
                stream.Flush();
            }

            logic.AddSprite(sprite.name, filename, sprite.price);
            

            return View();
        }
    }
}