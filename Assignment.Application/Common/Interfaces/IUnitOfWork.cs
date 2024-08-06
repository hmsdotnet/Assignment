using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment.Application.Common.Interfaces
{
    public interface IUnitOfWork
    {
        ICustomerRepository Customer { get; }
        IAddressRepository Address { get; }
        IApplicationUserRepository User { get; }
        void Save();
    }
}
