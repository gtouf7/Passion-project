using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;

namespace Passion_Project.Models
{
    public class MatchxTeams
    {
        [Key]
        public int MatchId { get; set; }

        [ForeignKey("Team")]
        public int TeamId { get; set; }
        public virtual Team Team { get; set; }

        //[ForeignKey("Player")]
       // public int PlayerId { get; set; }
       // public virtual Player Player { get; set; }



        public int Goals { get; set; }

    }
}