using CarRentalProject.Models;
using CarRentalProject.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarRentalProject.Controllers
{
    public class CarController : Controller
    {
        ApplicationDbContext _context;

        public CarController()
        {
            _context = new ApplicationDbContext();
        }

        // GET: Car
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CarForm(Customer customer)
        {
            var viewModel = new SingleCarViewModel
            {
                Customer = customer
            };

            return View(viewModel);
        }

        [HttpPost]

        public ActionResult Save(SingleCarViewModel viewModel)
        {
            viewModel.Car.CustomerId = viewModel.Customer.Id;
            var customer = _context.Customers.Find(viewModel.Customer.Id);
            var car = viewModel.Car;
            _context.Cars.Add(car);
            _context.SaveChanges();
              
            return RedirectToAction("CustAndCarForm", "Customer", customer);
        }

        public ActionResult EditForm(Car car)
        {
            var customer = _context.Customers.Find(car.CustomerId);
            var viewModel = new SingleCarViewModel
            {
                Car = car,
                Customer = customer
            };

            return View(viewModel);
        }

        [HttpPost]

        public ActionResult Edit(Car car)
        {
            var carInDb = _context.Cars.Find(car.Id);
            var customer = _context.Customers.Find(carInDb.CustomerId);
            carInDb.VIN = car.VIN;
            carInDb.Make = car.Make;
            carInDb.Model = car.Model;
            carInDb.Color = car.Color;
            carInDb.Year = car.Year;
            carInDb.Miles = car.Miles;
            _context.SaveChanges();

            return RedirectToAction("CustAndCarForm", "Customer", customer);

        }

        public ActionResult Delete(int id)
        {
            Car car = _context.Cars.Find(id);
            var customer = _context.Customers.Find(car.CustomerId);
            _context.Cars.Remove(car);
            _context.SaveChanges();
            return RedirectToAction("CustAndCarForm","Customer", customer);
        }

        public ActionResult AddNewServices(Car car)
        {

            List<Service> service = _context.Services.Where(c => c.CarId == car.Id).ToList();
            List<ServiceType> serviceType = _context.ServiceTypes.ToList();

            var viewModel = new CarAndServiceViewModel
            {
                Car = car,
                Services = service,
                ServiceType = serviceType
            };
          
            return View(viewModel);
        }

        public ActionResult AddServices(CarAndServiceViewModel viewModel)
        {
            viewModel.Service.DateAdded = DateTime.Today;
            viewModel.Service.CarId = viewModel.Car.Id;
            var car = _context.Cars.Find(viewModel.Car.Id);
           
            _context.Services.Add(viewModel.Service);
            _context.SaveChanges();

            return RedirectToAction("AddNewServices", "Car", car);
        }

        public ActionResult Delete1(int id)
        {
            Service service = _context.Services.Find(id);
            var car = _context.Cars.Find(service.CarId);
            _context.Services.Remove(service);
            _context.SaveChanges();
            return RedirectToAction("AddNewServices", "Car", car);
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
    }
}