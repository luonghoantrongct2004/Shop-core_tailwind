using Microsoft.EntityFrameworkCore;
using ShopDataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ShopDataAccess.Interface
{
    public class Repository<T> : IRepository<T> where T : class, new()
    {
        private readonly ShopDbContext _context;

        public Repository(ShopDbContext context)
        {
            _context = context;
        }

        public async Task<T> AddAsync(T entity)
        {
            await _context.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<List<T>> AddRangeAsync(List<T> entity)
        {
            await _context.AddRangeAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<int> DeleteAsync(int entity)
        {
            _context.Remove(entity);
            return await _context.SaveChangesAsync();
        }

        public async Task<T> GetAsync(Expression<Func<T, bool>> filter = null, CancellationToken cancellationToken = default)
        {
            return await _context.Set<T>().AsNoTracking().FirstOrDefaultAsync(filter, cancellationToken);
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task<List<T>> GetListAsync(Expression<Func<T, bool>> filter = null, CancellationToken cancellationToken = default)
        {
            return await(filter == null ? _context.Set<T>().ToListAsync(cancellationToken) : _context.Set<T>().Where(filter).ToListAsync(cancellationToken));
        }

        public async Task<T> UpdateAsync(T entity)
        {
            _context.Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<List<T>> UpdateRangeAsync(List<T> entity)
        {
            _context.UpdateRange(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
    }
}
