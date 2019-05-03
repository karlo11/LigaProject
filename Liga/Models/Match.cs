using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Liga.Models
{
    public class Match
    {
        [Key]
        public int ID { get; set; }

        public int? HomeTeamID { get; set; }
        public int? AwayTeamID { get; set; }

        /* [ForeignKey("HomeTeamID")]
         [InverseProperty("Matches")]*/
        public virtual Club HomeClubs { get; set; }

        /*[ForeignKey("AwayTeamID")]*/
        public virtual Club AwayClubs { get; set; }


        [Required]
        [Range(0, 100)]
        public int GoalsScoredHomeTeam { get; set; }

        [Required]
        [Range(0, 100)]
        public int GoalsScoredAwayTeam { get; set; }


        [Required]
        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
        public DateTime GameDateTime { get; set; }

        public string MatchBio
        {
            get
            {
                return HomeClubs.Name + " - " + AwayClubs.Name;
            }
        }

        public string Score
        {
            get
            {
                return GoalsScoredHomeTeam + " : " + GoalsScoredAwayTeam;
            }
        }
    }
}