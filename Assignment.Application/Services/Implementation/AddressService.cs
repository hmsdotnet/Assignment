using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assignment.Application.Common.Interfaces;
using Assignment.Application.Services.Interface;
using Assignment.Domain.Entities;

namespace Assignment.Application.Services.Implementation
{
    public class AddressService : IAddressService
    {
        private readonly IUnitOfWork _unitOfWork;
        public AddressService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        public void CreateAddress(Address address)
        {
            ArgumentNullException.ThrowIfNull(address);

            _unitOfWork.Address.Add(address);
            _unitOfWork.Save();
        }

        public bool DeleteAddress(int id)
        {
            try
            {
                var address = _unitOfWork.Address.Get(u => u.Id == id);

                if (address != null)
                {

                    _unitOfWork.Address.Remove(address);
                    _unitOfWork.Save();
                    return true;
                }
                else
                {
                    throw new InvalidOperationException($"Address with ID {id} not found.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return false;
        }

        public IEnumerable<Address> GetAllAddresses()
        {
            return _unitOfWork.Address.GetAll(includeProperties: "Customer");
        }

        public Address GetAddressById(int id)
        {
            return _unitOfWork.Address.Get(u => u.Id == id, includeProperties: "Customer");
        }

        public void UpdateAddress(Address address)
        {
            ArgumentNullException.ThrowIfNull(address);

            _unitOfWork.Address.Update(address);
            _unitOfWork.Save();
        }


    }
}
