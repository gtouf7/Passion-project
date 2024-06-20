using System;
using System.COllections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using Passion_Project.Models;

namespace Passion_Project.Controllers
{
  public class TeamController : Controller
  {
    private static readonly HttpClient client;
    static TeamController()
    {
      client = new HttpCLient();
      client.BaseAddress = new Uri("https://localhost:4430/api/");
    }
    //GET: Team/TeamList
    public ActionResult TeamList()
      {
        string url = "TeamData/ListTeams";
        HttpResponseMessage response = client.GetAsAsync<IEnumerable<TeamDTO>>().Result;
        return view(teams);
      }
  }
}
