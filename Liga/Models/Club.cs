using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace Liga.Models
{
    public class Club
    {
        [Key]
        public int ID { get; set; }


        public int? LeagueID { get; set; }
        [ForeignKey("LeagueID")]
        public virtual League League { get; set; }

        /* public int? ManagerID { get; set; }
         [ForeignKey("ManagerID")]*/
        public virtual Manager Manager { get; set; }

        public int? StadiumID { get; set; }
        [ForeignKey("StadiumID")]
        public virtual Stadium Stadium { get; set; }




        [Required]
        [MinLength(3)]
        public string Name { get; set; }

        [MinLength(6)]
        public string Email { get; set; }

        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
        public DateTime DateOfFoundation { get; set; }

        [MinLength(8)]
        public string PhoneNumber { get; set; }
    }
}