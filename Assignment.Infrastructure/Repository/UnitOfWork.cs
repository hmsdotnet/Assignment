using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assignment.Application.Common.Interfaces;
using Assignment.Infrastructure.Data;

namespace Assignment.Infrastructure.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _db;
        public ICustomerRepository Customer { get; private set; }
        public IAddressRepository Address { get; private set; }
        public IApplicationUserRepository User { get; private set; }
        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
            Customer = new CustomerRepository(_db);
            Address = new AddressRepository(_db);
            User = new ApplicationUserRepository(_db);
        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
