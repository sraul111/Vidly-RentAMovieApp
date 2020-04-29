using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class CustomerController : Controller
    {
        private ApplicationDbContext _context;

        public CustomerController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        // GET: Customer
        public ActionResult Index()
        {
            var customers = _context.Customers.Include(c => c.MemberShipType).ToList();
            return View(customers);
        }

        [Route("customer/details/{id}")]
        public ActionResult Details(int id)
        {
            var customer = _context.Customers.ToList().SingleOrDefault(x => x.Id == id);
            if (customer == null)
                return HttpNotFound();

            return View(customer);
        }

        [HttpPost]
        public ActionResult Save(Customer customer)
        {
            if (customer.Id == 0)
                _context.Customers.Add(customer);
            else
            {
                var customerInDb = _context.Customers.Single(c => c.Id == customer.Id);
                customerInDb.Name = customer.Name;
                customerInDb.DOB = customer.DOB;
                customerInDb.IsSubscribedToNewsletter = customer.IsSubscribedToNewsletter;
                customerInDb.MemberShipTypeId = customer.MemberShipTypeId;

            }
            //_context.Customers.Add(customer);
            _context.SaveChanges();
            return RedirectToAction("Index", "Customer");
        }
        public ActionResult New()
        {
            var memberShipTypes = _context.MemberShipTypes.ToList();
            var customerVm = new CustomerFormViewModel
            {
                MemberShipTypes = memberShipTypes,
            };
            return View("CustomerForm",customerVm);
        }

        public List<Customer> GetCustomers()
        {
            return new List<Customer>
            {
                new Customer{Id=1,IsSubscribedToNewsletter = true,Name = "sujit"},
                new Customer{Id=2,IsSubscribedToNewsletter = true,Name = "Prabhu"},
                new Customer{Id=3,IsSubscribedToNewsletter = true,Name = "Bunu"}
            };

        }

        public ActionResult Edit(int id)
        {
            var customer = _context.Customers.SingleOrDefault(x => x.Id == id);
            if (customer == null)
                return HttpNotFound();

            var viewModel = new CustomerFormViewModel
            {
                Customer = customer,
                MemberShipTypes = _context.MemberShipTypes.ToList()
            };

            return View("CustomerForm", viewModel);
        }
    }
}