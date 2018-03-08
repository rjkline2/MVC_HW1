using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC_HW1.Models
{
    public class SuperHeroModel
    {
        [Key]
        public int SuperHeroID { get; set; }

        public string SuperHeroName { get; set; }
        public int SuperHeroFlightSpeed { get; set; }
        public int SuperHeroStrenghtLevel { get; set; }
        public string SuperHeroAlignment { get; set; }
    }
}