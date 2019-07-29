using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CarRentalProject.Models
{
    public class Customer
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Customer Name is Mandatory")]
       
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public double PhoneNumber { get; set; }

        public string Email { get; set; }

    }
}