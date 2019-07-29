using CarRentalProject.Models;
using CarRentalProject.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarRentalProject.Controllers
{
    public class CustomerController : Controller
    {
        ApplicationDbContext _context;

        public CustomerController()
        {
            _context = new ApplicationDbContext();
        }
        // GET: Customer

        public ActionResult Index(string search = "", string option = "")
        {
            if (search.Equals(""))
            {
                var customers = _context.Customers.ToList();
                var viewModel = new SearchBarViewModel
                {
                    Customers = customers
                };
                return View(viewModel);
            }
            else
            {
                if (option.Equals("Email"))
                {
                    var customers = _context.Customers.Where(c => c.Email.Equals(search)).ToList();
                    var viewModel = new SearchBarViewModel
                    {
                        Customers = customers
                    };
                    return View(viewModel);
                }

                else if (option.Equals("PhoneNumber"))
                {
                    var searchMobile = Convert.ToDouble(search);
                    var customers = _context.Customers.Where(c => c.PhoneNumber.Equals(searchMobile)).ToList();
                    var viewModel = new SearchBarViewModel
                    {
                        Customers = customers
                    };
                    return View(viewModel);
                }

                else
                {
                    var customers = _context.Customers.Where(c => c.FirstName.Equals(search)).ToList();
                    var viewModel = new SearchBarViewModel
                    {
                        Customers = customers
                    };
                    return View(viewModel);
                }
            }
        }

        [Authorize(Roles = Role.Admin)]

        public ActionResult CustForm(Customer customer)
        {
            var cars = _context.Cars.ToList();
            var viewModel = new NewCustomerViewModel
            {
                Customer = customer,
                Cars = cars
            };
            return View(viewModel);
        }

        [HttpPost]

        [Authorize(Roles = Role.Admin)]

        public ActionResult Save(Customer customer)
        {

            if (customer.Id == 0)
                _context.Customers.Add(customer);
            else
            {
                var customerInDb = _context.Customers.Single(c => c.Id == customer.Id);
                customerInDb.FirstName = customer.FirstName;
                customerInDb.LastName  = customer.LastName;
                customerInDb.PhoneNumber = customer.PhoneNumber;
                customerInDb.Email = customer.Email;
            }
            _context.SaveChanges();
            return RedirectToAction("Index", "Customer");
        }

        [Authorize(Roles = Role.Admin)]

        public ActionResult Delete(int id)
        {
            Customer customer = _context.Customers.Find(id);
            _context.Customers.Remove(customer);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult CustAndCarForm(Customer customer)
        {
            var cars = _context.Cars.ToList();
            var cust = _context.Customers.Find(customer.Id);
            var viewModel = new NewCustomerViewModel
            {
                Customer = cust,
                Cars = cars
            };
            return View(viewModel);
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

    }
}