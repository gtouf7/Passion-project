﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Passion_Project.Models
{   
    //Model for holding the team table contents
    public class Team
    {   
        //A team can hold multiple players
        [Key]
        public int TeamId { get; set; }
        public string TeamName { get; set; }
        public string TeamCountry { get; set; }
        public string TeamBudget { get; set; }
    }

    //DTO section
    public class TeamDTO
    {
        public int TeamId { get; set; }
        public string TeamName { get; set; }
        public string TeamCountry { get; set; }
        public string TeamBudget { get; set; }
    }
}