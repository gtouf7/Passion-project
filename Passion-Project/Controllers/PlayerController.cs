using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using Passion_Project.Models;

namespace Passion_Project.Controllers
{
    public class PlayerController : Controller
    {
        private static readonly HttpClient client;
        static PlayerController()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:44300/api/");
        }
        // GET: Player/PlayerList
        public ActionResult PlayerList()
        {
            string url = "/PlayerData/ListPlayers";
            HttpResponseMessage response = client.GetAsync(url).Result;

            IEnumerable<PlayerDTO> players = response.Content.ReadAsAsync<IEnumerable<PlayerDTO>>().Result;

            return View(players);
        }
    }
}