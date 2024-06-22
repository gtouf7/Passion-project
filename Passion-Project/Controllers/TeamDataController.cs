using Passion_Project.Migrations;
using Passion_Project.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;


namespace Passion_Project.Controllers
{
    public class TeamDataController : ApiController
    {
            private ApplicationDbContext db = new ApplicationDbContext();
            /// <summary>
            /// A list of all the teams in the database.
            /// </summary>
            /// <returns>
            /// An array of the team objects.
            /// </returns>
            /// <example>
            /// GET: api/TeamData/ListTeams->[{TeamId:4, TeamName:"Olympiacos FC", TeamCountry:"Greece", TeamBudget: "114M" },
            /// </example>

            [HttpGet]
            [Route("api/TeamData/ListTeams")]
            public IHttpActionResult ListTeams()
            {
                //teams list output
                List<Team> Teams = db.Teams.ToList();

                List<TeamDTO> TeamDTOs = new List<TeamDTO>();

                foreach (Team Team in Teams)
                {
                    TeamDTO Dto = new TeamDTO();

                    Dto.TeamName = Team.TeamName;
                    Dto.TeamId = Team.TeamId;
                    Dto.TeamCountry = Team.TeamCountry;
                    Dto.TeamBudget = Team.TeamBudget;

                    TeamDTOs.Add(Dto);
                }
                return Ok(TeamDTOs);
            }

            //FIND A TEAM BY ID
            //GET: api/TeamData/FindTeam/{id}
            [ResponseType(typeof(Team))]
            [HttpGet]
            [Route("api/TeamData/FindTeam/{id}")]

            public IHttpActionResult FindTeam(int id)
            {
                Team Team = db.Teams.Find(id);
                if (Team == null)
                {
                    return NotFound();
                }

                TeamDTO TeamDTO = new TeamDTO()
                {
                    TeamId = Team.TeamId,
                    TeamName = Team.TeamName,
                    TeamCountry = Team.TeamCountry,
                    TeamBudget = Team.TeamBudget
                };
                return Ok(TeamDTO);
            }

            //ADDING A TEAM
            // POST: api/TeamData/AddTeam
            [ResponseType(typeof(Team))]
            [HttpPost]
            public IHttpActionResult AddTeam(Team team)
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                db.Teams.Add(team);
                db.SaveChanges();

                return CreatedAtRoute("DefaultApi", new { id = team.TeamId }, team);
            }
        //UPDATE A TEAM
        // POST: api/TeamData/UpdateTeam/{id}
        [ResponseType(typeof(Team))]
            [HttpPost]
            public IHttpActionResult UpdateTeam(int id, Team team)
            {
                Debug.WriteLine("Update method reached");
                if (!ModelState.IsValid)
                {
                    Debug.WriteLine("Model State invalid");
                    return BadRequest(ModelState);
                }
                if (id != team.TeamId)
                {
                    Debug.WriteLine("ID mismatch");
                    Debug.WriteLine("GET parameter" + id);
                    Debug.WriteLine("POST parameter" + team.TeamId);
                    Debug.WriteLine("POST parameter" + team.TeamName);
                    Debug.WriteLine("POST parameter" + team.TeamCountry);
                    Debug.WriteLine("POST parameter" + team.TeamBudget);
                    return BadRequest();
                }
                db.Entry(team).State = EntityState.Modified;

                try
                {
                    db.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TeamExists(id))
                    {
                        Debug.WriteLine("Team Not Found");
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                Debug.WriteLine("None of the conditions triggered");
                return StatusCode(HttpStatusCode.NoContent);
            }

            private bool TeamExists(int id)
            {
                throw new NotImplementedException();
            }

            // DELETE A TEAM 
            // POST: api/TeamData/DeleteTeam/{id}
            [ResponseType(typeof(Team))]
            [HttpPost]
            public IHttpActionResult DeleteTeam(int id)
            {
                Team team = db.Teams.Find(id);
                if (team == null)
                {
                    return NotFound();
                }

                db.Teams.Remove(team);
                db.SaveChanges();

                return Ok();
            }
    }
}
