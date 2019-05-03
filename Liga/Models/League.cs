using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Liga.Models
{
    public class League
    {
        [Key]
        public int ID { get; set; }

        public virtual ICollection<Club> Clubs { get; set; }

        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
        public DateTime DateOfFoundation { get; set; }

        [Required]
        [MinLength(3)]
        public string Country { get; set; }

        [Required]
        [MinLength(3)]
        public string Name { get; set; }
    }
}