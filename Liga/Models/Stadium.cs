using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Liga.Models
{
    public class Stadium
    {
        [Key]
        public int ID { get; set; }

        public int? ClubID { get; set; }
        [ForeignKey("ClubID")]
        public virtual ICollection<Club> Clubs { get; set; }


        [Required]
        [MinLength(3)]
        public string Name { get; set; }

        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
        public DateTime DateOfBuild { get; set; }

        [Required]
        [MinLength(2)]
        public string City { get; set; }

        [Range(5000, 45000)]
        public int Capacity { get; set; }
    }
}