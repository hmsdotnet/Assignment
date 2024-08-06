using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assignment.Domain.Entities;

namespace Assignment.Application.Services.Interface
{
    public interface IAddressService
    {
        IEnumerable<Address> GetAllAddresses();
        void CreateAddress(Address address);
        void UpdateAddress(Address address);
        Address GetAddressById(int id);
        bool DeleteAddress(int id);
    }
}