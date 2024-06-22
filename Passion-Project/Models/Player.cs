﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;

namespace Passion_Project.Models
{
    //Model for holding the player table contents
    public class Player
    {
        
        [Key]
        public int PlayerId { get; set; }
        public string PlayerName { get; set; }
        public string PlayerPosition { get; set; }

        //foreign key for the player's team
        [ForeignKey("Team")]
        //A player can only be playing for one team
        public int PlayerTeamId { get; set; }
        public virtual Team Team { get; set; }
    }

    //DTO section
    public class PlayerDTO
    {
        public int PlayerId { get; set; }
        public string PlayerName { get; set; }
        public string PlayerPosition { get; set; }
        public string TeamName { get; set; }
    }
}