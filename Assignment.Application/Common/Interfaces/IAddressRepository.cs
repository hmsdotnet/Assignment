using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Assignment.Domain.Entities;

namespace Assignment.Application.Common.Interfaces
{
    public interface IAddressRepository : IRepository<Address>
    {
        void Update(Address entity);
    }
}
