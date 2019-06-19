using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Logic;
using DAL;
using DungeonSurvivor.Models;

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
            var leaderboard = logic
                .getLeaderBoard(DateTime.Today.AddDays(-21), 10)
                .Select(l => new LeaderBoardViewModel {username = l.username, rooms = l.rooms, stepRatio = l.stepratio });

            return View(leaderboard);
        }

        public IActionResult IndexByDate([FromQuery]DateTime minDate)
        {
            var leaderboard = logic
                .getLeaderBoard(minDate, 10)
                .Select(l => new LeaderBoardViewModel { username = l.username, rooms = l.rooms, stepRatio = l.stepratio });

            return View("Index", leaderboard);
        }

    }
}