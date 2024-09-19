using DataAccessLayer.Abstract;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Contract
{
    public class GenericRepository<T> : IGenericRepostory<T> where T : class
    {
        protected readonly DataContext _context;
        public GenericRepository(DataContext context) => _context = context;
       
            public async Task GenericCreate(T entity) => await _context.Set<T>().AddAsync(entity);

            public void GenericDelete(T entity) => _context.Set<T>().Remove(entity);
            public async Task<IEnumerable<T>> GenericRead(bool trackChanges) => await _context.Set<T>().AsNoTracking().ToListAsync();

            public IQueryable<T> GenericReadExpression(Expression<Func<T, bool>> expression, bool trackChanges) =>
           !trackChanges ? _context.Set<T>().Where(expression).AsNoTracking()
                : _context.Set<T>().Where(expression);
            public void GenericUpdate(T entity) => _context.Set<T>().Update(entity);
        
    }
}
