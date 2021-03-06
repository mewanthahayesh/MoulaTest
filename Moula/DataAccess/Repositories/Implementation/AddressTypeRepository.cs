using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories
{
    public class AddressTypeRepository:RepositoryBase<AddressType>,IAddressTypeRepository
    {
        public CustomerDbContext dbContext { get; }

        public AddressTypeRepository(CustomerDbContext dbContext) : base(dbContext)
        {
            this.dbContext = dbContext;
        }
        
        public AddressType GetAddressTypeWithAddress(int typeId)
        {
           return dbContext.AddressType.Include(d => d.Address).FirstOrDefault(d => d.Id == typeId);
        }

        public IEnumerable<AddressType> GetAllAddressTypesWithAddresses()
        {
           return dbContext.AddressType.Include(s => s.Address).AsNoTracking().ToList();
        }
        public IEnumerable<AddressType> GetAddressTypesWithAddressesByFilter(Expression<Func<AddressType,bool>> expression)
        {
            return dbContext.AddressType.Include(s => s.Address).Where(expression).AsNoTracking().ToList();
        }
    }
}