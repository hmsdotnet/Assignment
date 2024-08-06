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
    public class CustomerRepository : Repository<Customer>, ICustomerRepository
    {
        private readonly ApplicationDbContext _db;

        public CustomerRepository(ApplicationDbContext db) : base(db) 
        {
            _db = db;
        }
        
        public void Update(Customer entity)
        {
            _db.Customers.Update(entity);
        }
    }
}
