using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Passion_Project.Models
{
    public class Fixture
    {
        [Key]
        public int MatchId { get; set; }
        public string MatchRound { get; set; }
        public int HomeGoals {  get; set; }
        public int AwayGoals { get; set;}


    }
}