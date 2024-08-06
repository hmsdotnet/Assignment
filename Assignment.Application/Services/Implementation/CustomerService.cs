using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assignment.Application.Common.Interfaces;
using Assignment.Application.Common.Utility;
using Assignment.Application.Services.Interface;
using Assignment.Domain.Entities;
using Microsoft.AspNetCore.Authorization;

namespace Assignment.Application.Services.Implementation
{
    [Authorize]
    public class CustomerService : ICustomerService
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public CustomerService(IUnitOfWork unitOfWork, IWebHostEnvironment webHostEnvironment)
        {
            _unitOfWork = unitOfWork;
            _webHostEnvironment = webHostEnvironment;
        }

        public void CreateCustomer(Customer customer)
        {
            if (customer.Image != null)
            {
                string fileName = Guid.NewGuid().ToString() + Path.GetExtension(customer.Image.FileName);
                string imagePath = Path.Combine(_webHostEnvironment.WebRootPath, @"images\CustomerImage");

                using var fileStream = new FileStream(Path.Combine(imagePath, fileName), FileMode.Create);
                customer.Image.CopyTo(fileStream);

                customer.ImageUrl = @"\images\CustomerImage\" + fileName;
            }
            else
            {
                customer.ImageUrl = "https://placehold.co/600x400";
            }

            _unitOfWork.Customer.Add(customer);
            _unitOfWork.Save();
        }

        public bool DeleteCustomer(int id)
        {
            try
            {
                Customer? objFromDb = _unitOfWork.Customer.Get(u => u.Id == id);
                if (objFromDb is not null)
                {
                    if (!string.IsNullOrEmpty(objFromDb.ImageUrl))
                    {
                        var oldImagePath = Path.Combine(_webHostEnvironment.WebRootPath, objFromDb.ImageUrl.TrimStart('\\'));

                        if (System.IO.File.Exists(oldImagePath))
                        {
                            System.IO.File.Delete(oldImagePath);
                        }
                    }
                    _unitOfWork.Customer.Remove(objFromDb);
                    _unitOfWork.Save();

                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }   
        }

        public IEnumerable<Customer> GetAllCustomers()
        {
            return _unitOfWork.Customer.GetAll(includeProperties: "CustomerAddress");
        }

        public Customer GetCustomerById(int id)
        {
            return _unitOfWork.Customer.Get(u => u.Id == id, includeProperties: "CustomerAddress");
        }
             
        public void UpdateCustomer(Customer customer)
        {
            if (customer.Image != null)
            {
                string fileName = Guid.NewGuid().ToString() + Path.GetExtension(customer.Image.FileName);
                string imagePath = Path.Combine(_webHostEnvironment.WebRootPath, @"images\CustomerImage");

                if (!string.IsNullOrEmpty(customer.ImageUrl))
                {
                    var oldImagePath = Path.Combine(_webHostEnvironment.WebRootPath, customer.ImageUrl.TrimStart('\\'));

                    if (System.IO.File.Exists(oldImagePath))
                    {
                        System.IO.File.Delete(oldImagePath);
                    }
                }

                using var fileStream = new FileStream(Path.Combine(imagePath, fileName), FileMode.Create);
                customer.Image.CopyTo(fileStream);

                customer.ImageUrl = @"\images\CustomerImage\" + fileName;
            }

            _unitOfWork.Customer.Update(customer);
            _unitOfWork.Save();
        }
    }
}
