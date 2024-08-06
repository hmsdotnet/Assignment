using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Assignment.Application.Common.Interfaces;
using Assignment.Application.Services.Interface;
using Assignment.Domain.Entities;
using Assignment.Infrastructure.Data;

namespace Assignment.Web.Controllers
{
    [Authorize]
    public class CustomerController : Controller
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        public IActionResult Index()
        {
            var customers = _customerService.GetAllCustomers();
            return View(customers);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Customer obj)
        {
            
            if (ModelState.IsValid)
            {
                _customerService.CreateCustomer(obj);
                TempData["success"] = "The customer has been created successfully.";
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        public IActionResult Update(int customerId)
        {
            Customer? obj = _customerService.GetCustomerById(customerId);
            if (obj == null)
            {
                return RedirectToAction("Error", "Home");
            }
            return View(obj);
        }

        [HttpPost]
        public IActionResult Update(Customer obj)
        {
            if (ModelState.IsValid && obj.Id > 0)
            {

               _customerService.UpdateCustomer(obj);
                TempData["success"] = "The customer has been updated successfully.";
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        public IActionResult Delete(int customerId)
        {
            Customer? obj = _customerService.GetCustomerById(customerId);
            if (obj is null)
            {
                return RedirectToAction("Error", "Home");
            }
            return View(obj);
        }


        [HttpPost]
        public IActionResult Delete(Customer obj)
        {
         bool deleted = _customerService.DeleteCustomer(obj.Id);
            if (deleted)
            {
                TempData["success"] = "The customer has been deleted successfully.";
                return RedirectToAction(nameof(Index));
            }
            else
            {
                TempData["error"] = "Failed to delete the customer.";
            }
            return View();
        }
    }
}
