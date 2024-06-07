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
    public class PlayerDataController : ApiController
    {   
        private ApplicationDbContext db = new ApplicationDbContext();
        /// <summary>
        /// A list of all the players in the database.
        /// </summary>
        /// <returns>
        /// An array of the players objects.
        /// </returns>
        /// <example>
        /// GET: api/PlayerData/ListPlayers->[{PlayerId:3, PlayerName:"Cole Palmer", PlayerPosition:"CAM/RW"},
        /// {PlayerId:4, PlayerName:"Djordje Petrovic", PlayerPosition:"GK"}]
        /// </example>

        [HttpGet]
        [Route("api/PlayerData/ListPlayers")]
        public List<PlayerDTO> ListPlayers()
        {   
            //players list output
            List<Player> Players = db.Players.ToList();

            List<PlayerDTO> PlayerDTOs = new List<PlayerDTO>();

            foreach (Player Player in Players)
            {
                PlayerDTO Dto = new PlayerDTO();

                Dto.PlayerName = Player.PlayerName;
                Dto.PlayerId = Player.PlayerId;
                Dto.PlayerPosition = Player.PlayerPosition;
                Dto.TeamName = Player.Team.TeamName;

                PlayerDTOs.Add(Dto);
            }
            return PlayerDTOs;
        }

        //FIND A PLAYER BY ID
        //GET: api/PlayerData/FindPlayer/{id}
        [ResponseType(typeof(Player))]
        [HttpGet]

        public IHttpActionResult FindPlayer(int id)
        {
            Player Player = db.Players.Find(id);
            if (Player == null)
            {
                return NotFound();
            }

            PlayerDTO PlayerDTO = new PlayerDTO()
            {
                PlayerId = Player.PlayerId,
                PlayerName = Player.PlayerName,
                PlayerPosition = Player.PlayerPosition,
                TeamName = Player.Team.TeamName
            };
            return Ok(PlayerDTO);
        }

        //ADDING A PLAYER
        // POST: api/PlayerData/AddPlayer
        [ResponseType(typeof(Player))]
        [HttpPost]
        public IHttpActionResult AddPlayer(Player player)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Players.Add(player);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = player.PlayerId }, player);
        }

        //UPDATE A PLAYER
        // POST: api/PlayerData/UpdatePlayer/{id}
        [ResponseType(typeof(Player))]
        [HttpPost]
        public IHttpActionResult UpdatePlayer(int id, Player player)
        {
            Debug.WriteLine("Update method reached");
            if (!ModelState.IsValid)
            {
                Debug.WriteLine("Model State invalid");
                return BadRequest(ModelState);
            }
            if ( id != player.PlayerId)
            {
                Debug.WriteLine("ID mismatch");
                Debug.WriteLine("GET parameter" + id);
                Debug.WriteLine("POST parameter" +  player.PlayerId);
                Debug.WriteLine("POST parameter" + player.PlayerName);
                Debug.WriteLine("POST parameter" + player.PlayerPosition);
                Debug.WriteLine("POST parameter" + player.PlayerTeamId);
                return BadRequest();
            }
            db.Entry(player).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PlayerExists(id))
                {
                    Debug.WriteLine("Player Not Found");
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

        private bool PlayerExists(int id)
        {
            throw new NotImplementedException();
        }

        // DELETE A PLAYER 
        // POST: api/PlayerData/DeletePlayer/{id}
        [ResponseType(typeof(Player))]
        [HttpPost]
        public IHttpActionResult DeletePlayer(int id)
        {
            Player player = db.Players.Find(id);
            if (player == null)
            {
                return NotFound();
            }

            db.Players.Remove(player);
            db.SaveChanges();

            return Ok();
        }
    }
}
