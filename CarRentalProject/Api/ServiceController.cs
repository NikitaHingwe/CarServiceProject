using CarRentalProject.Models;
using CarRentalProject.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CarRentalProject.Api
{
    public class ServiceController : ApiController
    {
        ApplicationDbContext _context;
        public ServiceController()
        {
            _context = new ApplicationDbContext();
        }

        [HttpGet]
        public IEnumerable<Service> GetServices()
        {
            return _context.Services.ToList();
        }

        [HttpPost]
        public IHttpActionResult PostServices(CarAndServiceViewModel viewModel)
        {
            _context.Services.Add(viewModel.Service);
            _context.SaveChanges();
            return Ok(viewModel);
        }

        [HttpDelete]
        public IHttpActionResult DeleteServices(int id)
        {
            Service service = _context.Services.Find(id);
            _context.Services.Remove(service);
            _context.SaveChanges();
            return Ok(service);     
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
    }
}
