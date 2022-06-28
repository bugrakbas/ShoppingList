using Microsoft.EntityFrameworkCore;
using ShoppingList.Application.Common.Interfaces.Repositories;
using ShoppingList.Domain.Entities;
using ShoppingList.Infrastructure.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingList.Infrastructure.Persistence.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        protected readonly ApplicationDbContext _applicationDbContext;
        protected readonly DbSet<T> _dbSet;
        public GenericRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
            _dbSet = _applicationDbContext.Set<T>();
        }
        public async Task Add(T entity)
        {
            await _dbSet.AddAsync(entity);
            await _applicationDbContext.SaveChangesAsync();
        }

        public void Delete(int id)
        {
            var current = _dbSet.FirstOrDefault(x => x.Id == id);
            if (current == null) throw new Exception("");

            _dbSet.Remove(current);
            _applicationDbContext.SaveChanges();
        }

        public IEnumerable<T> Get(Expression<Func<T, bool>> expression)
        {
            return _dbSet.Where(expression);
        }

        public IEnumerable<T> GetAll()
        {
            return _dbSet.AsNoTracking();
        }

        public T GetById(int id)
        {
            var current = _dbSet.FirstOrDefault(x => x.Id == id);
            if (current == null) throw new Exception("");
            return current;
        }

        public  void Update(T entity)
        {
            _dbSet.Update(entity);
            _applicationDbContext.SaveChanges();
        }
    }
}
