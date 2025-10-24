using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talabat.Core.Entities;
using Talabat.Core.repositories;
using Talabat.Repository.Data;

namespace Talabat.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        private readonly StoreContext dbcontext;

        public GenericRepository(StoreContext dbcontext)
        {
            this.dbcontext = dbcontext;
        }
        public async Task<IEnumerable<T>> GetAllAsync()
        { if (typeof(T) == typeof(Product))
                return (IEnumerable<T>) await dbcontext.Products.Include(P => P.ProductBrand).Include(P => P.ProductType)
                                                     .ToListAsync();
            else
                return await dbcontext.Set<T>().ToListAsync(); }

        public async Task<T> GetByIdAsync(int id)
        { 
            return await dbcontext.Set<T>().FindAsync(id);
        }
    }
}
