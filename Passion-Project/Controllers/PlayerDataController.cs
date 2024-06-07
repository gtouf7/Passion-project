using Passion_Project.Migrations;
using Passion_Project.Models;
using System;
using System.Collections.Generic;
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

        //GET: api/PlayerData/FindPlayer/{id}
        [ResponseType(typeof(Player))]
        [HttpGet]

        public IHttpActionResult FindPlayer(int id)
        {
            Player Player = db.Players.Find(id);

            PlayerDTO PlayerDTO = new PlayerDTO()
            {
                PlayerId = Player.PlayerId,
                PlayerName = Player.PlayerName,
                PlayerPosition = Player.PlayerPosition,
                TeamName = Player.Team.TeamName
            };

            if (Player == null)
            {
                return NotFound();
            }

            return Ok(PlayerDTO);
        }
    }
}
