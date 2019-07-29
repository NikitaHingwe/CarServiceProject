using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CarRentalProject.Models
{
    public class Service
    {
        public int Id { get; set; }
        public double Miles { get; set; }
        public double Price { get; set; }
        public string Details { get; set; }


        [DisplayFormat(DataFormatString = "{0:d}")]
        public DateTime DateAdded { get; set; }

        public Car Car { get; set; }
        public int CarId { get; set; }

        public ServiceType ServiceType { get; set; }
        public int ServiceTypeId { get; set; }
    }
}