using Microsoft.AspNetCore.Mvc;
using Assignment.Application.Common.Interfaces;
using Assignment.Application.Common.Utility;
using Assignment.Application.Services.Interface;
using Assignment.Web.ViewModels;

namespace Assignment.Web.Controllers
{
    public class HomeController : Controller
    {

        //private readonly ICustomerService _customerService;
        //private readonly IAddressService _addressService;
        private readonly IWebHostEnvironment _webHostEnvironment;

        //public HomeController(ICustomerService customerService, IAddressService addressService, IWebHostEnvironment webHostEnvironment)
        public HomeController(IWebHostEnvironment webHostEnvironment)
        {
            //_customerService = customerService;
            //_addressService = addressService;
            _webHostEnvironment = webHostEnvironment;
        }

        public IActionResult Index()
        {
            return View();
        }


        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}