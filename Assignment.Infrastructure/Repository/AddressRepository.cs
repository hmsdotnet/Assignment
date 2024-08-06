using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Assignment.Application.Common.Interfaces;
using Assignment.Domain.Entities;
using Assignment.Infrastructure.Data; 

namespace Assignment.Infrastructure.Repository
{
    public class AddressRepository : Repository<Address>, IAddressRepository
    {
        private readonly ApplicationDbContext _db;

        public AddressRepository(ApplicationDbContext db) : base(db) 
        {
            _db = db;
        }
        
        public void Update(Address entity)
        {
            _db.Addresses.Update(entity);
         //   _db.Addresses.Update(entity);
        }
    }
}
