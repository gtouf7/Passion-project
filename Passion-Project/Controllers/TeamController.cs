using Passion_Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace Passion_Project.Controllers
{
    public class TeamController : Controller
    {
        private static readonly HttpClient client;

        static TeamController()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:44300/api/");
        }
        //GET: Team/TeamList
        public ActionResult TeamList()
        {
            string url = "TeamData/ListTeams";
            HttpResponseMessage response = client.GetAsync(url).Result;

            IEnumerable<TeamDTO> teams = response.Content.ReadAsAsync<IEnumerable<TeamDTO>>().Result;
            return View(teams);
        }
    }
}