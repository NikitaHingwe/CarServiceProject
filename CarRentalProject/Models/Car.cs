using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CarRentalProject.Models
{
    public class Car
    {
        
        public int Id { get; set; }

        [Required]
        public string VIN { get; set; }

        [Required]
        public string Make { get; set; }

        [Required]
        public string Model { get; set; }

        public string Style { get; set; }

        [Required]
        public int Year { get; set; }

        [Required]
        public double Miles { get; set; }

        public string Color { get; set; }
        
        public Customer Customer{ get; set; }
        public int CustomerId { get; set; }
    }
}