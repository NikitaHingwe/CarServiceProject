using CarRentalProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarRentalProject.ViewModel
{
    public class SearchBarViewModel
    {
        public Customer Customer { get; set; }
        public IEnumerable<Customer> Customers { get; set; }
        public int? CheckInteger { get; set; }
    }
}