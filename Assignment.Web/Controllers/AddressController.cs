using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Assignment.Application.Common.Interfaces;
using Assignment.Application.Common.Utility;
using Assignment.Application.Services.Interface;
using Assignment.Domain.Entities;
using Assignment.Infrastructure.Data;
using Assignment.Web.ViewModels;

namespace Assignment.Web.Controllers
{
    [Authorize(Roles = SD.Role_Admin)]
    public class AddressController : Controller
    {
        private readonly IAddressService _addressService;
        private readonly ICustomerService _customerService;

        public AddressController(IAddressService addressService, ICustomerService customerService)
        {
            _addressService = addressService;
            _customerService = customerService;
        }

        public IActionResult Index()
        {
            var amenities = _addressService.GetAllAddresses();
            return View(amenities);
        }

        public IActionResult Create()
        {
            AddressVM addressVM = new()
            {
                CustomerList = _customerService.GetAllCustomers().Select(u => new SelectListItem
                {
                    Text = u.Name,
                    Value = u.Id.ToString()
                })
            };
            return View(addressVM);
        }

        [HttpPost]
        public IActionResult Create(AddressVM obj)
        {

            if (ModelState.IsValid)
            {
                _addressService.CreateAddress(obj.Address);
                TempData["success"] = "The address has been created successfully.";
                return RedirectToAction(nameof(Index));
            }

            obj.CustomerList = _customerService.GetAllCustomers().Select(u => new SelectListItem
            {
                Text = u.Name,
                Value = u.Id.ToString()
            });
            return View(obj);
        }

        public IActionResult Update(int addressId)
        {
            AddressVM addressVM = new()
            {
                CustomerList = _customerService.GetAllCustomers().Select(u => new SelectListItem
                {
                    Text = u.Name,
                    Value = u.Id.ToString()
                }),
                Address = _addressService.GetAddressById(addressId)
            };
            if (addressVM.Address == null)
            {
                return RedirectToAction("Error", "Home");
            }
            return View(addressVM);
        }


        [HttpPost]
        public IActionResult Update(AddressVM addressVM)
        {

            if (ModelState.IsValid)
            {
                _addressService.UpdateAddress(addressVM.Address);
                TempData["success"] = "The address has been updated successfully.";
                return RedirectToAction(nameof(Index));
            }

            addressVM.CustomerList = _customerService.GetAllCustomers().Select(u => new SelectListItem
            {
                Text = u.Name,
                Value = u.Id.ToString()
            });
            return View(addressVM);
        }



        public IActionResult Delete(int addressId)
        {
            AddressVM addressVM = new()
            {
                CustomerList = _customerService.GetAllCustomers().Select(u => new SelectListItem
                {
                    Text = u.Name,
                    Value = u.Id.ToString()
                }),
                Address = _addressService.GetAddressById(addressId)
            };
            if (addressVM.Address == null)
            {
                return RedirectToAction("Error", "Home");
            }
            return View(addressVM);
        }



        [HttpPost]
        public IActionResult Delete(AddressVM addressVM)
        {
            Address? objFromDb = _addressService.GetAddressById(addressVM.Address.Id);
            if (objFromDb is not null)
            {
                _addressService.DeleteAddress(objFromDb.Id);
                TempData["success"] = "The address has been deleted successfully.";
                return RedirectToAction(nameof(Index));
            }
            TempData["error"] = "The address could not be deleted.";
            return View();
        }
    }
}