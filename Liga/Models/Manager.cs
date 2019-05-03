using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Liga.Models
{
    public class Manager
    {
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [ForeignKey("Club")]
        public int ID { get; set; }

        public virtual Club Club { get; set; }



        [Required]
        [MinLength(3)]
        public string FirstName { get; set; }

        [Required]
        [MinLength(3)]
        public string LastName { get; set; }

        [Required]
        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
        public DateTime DateOfBirth { get; set; }

        [StringLength(11)]
        public string OIB { get; set; }

        [MinLength(6)]
        public string Email { get; set; }


        public string FullName
        {
            get
            {
                return FirstName + " " + LastName;
            }
        }
    }
}