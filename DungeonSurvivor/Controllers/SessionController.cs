using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Logic;
using DAL;

namespace DungeonSurvivor.Controllers
{
    public class SessionController : Controller
    {

        private SessionLogic logic;

        public SessionController()
        {
            logic = new SessionLogic(new SqlSessionContext("Server=localhost;Database=dungeon_survivor;Uid=root;Pwd=test;"));
        }

        public IActionResult Index()
        {
            return View();
        }

    }
}