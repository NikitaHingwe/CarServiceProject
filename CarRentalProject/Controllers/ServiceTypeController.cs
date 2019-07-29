using CarRentalProject.Models;
using CarRentalProject.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarRentalProject.Controllers
{
    public class ServiceTypeController : Controller
    {
        
            ApplicationDbContext _context;

            public ServiceTypeController()
            {
                _context = new ApplicationDbContext();
            }
            // GET: Customer
            public ActionResult Index()
            {
                var servType = _context.ServiceTypes.ToList();
                return View(servType);
            }

        //    public ActionResult ServiceTypeInfo(ServiceType serviceType)
        //    {
        //        var cars = _context.Cars.ToList();
        //        var viewModel = new NewCustomerViewModel
        //        {
        //            Customer = customer,
        //            Cars = cars
        //        };
        //        return View(viewModel);
        //    }

        //[HttpPost]

        //    public ActionResult Save(Customer customer)
        //    {

        //        if (customer.Id == 0)
        //            _context.Customers.Add(customer);
        //        else
        //        {
        //            var customerInDb = _context.Customers.Single(c => c.Id == customer.Id);
        //            customerInDb.FirstName = customer.FirstName;
        //            customerInDb.LastName = customer.LastName;
        //            customerInDb.PhoneNumber = customer.PhoneNumber;
        //            customerInDb.Email = customer.Email;
        //        }
        //        _context.SaveChanges();
        //        return RedirectToAction("Index", "Customer");
        //    }

        //    public ActionResult Delete(int id)
        //    {
        //        Customer customer = _context.Customers.Find(id);
        //        _context.Customers.Remove(customer);
        //        _context.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    public ActionResult CustAndCarForm(Customer customer)
        //    {
        //        var cars = _context.Cars.ToList();
        //        var cust = _context.Customers.Find(customer.Id);
        //        var viewModel = new NewCustomerViewModel
        //        {
        //            Customer = cust,
        //            Cars = cars
        //        };
        //        return View(viewModel);
        //    }

        //    protected override void Dispose(bool disposing)
        //    {
        //        _context.Dispose();
        //    }

        }
    }
