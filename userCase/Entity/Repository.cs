using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using userCase.Entity.Abstract;
using userCase.Models;

namespace userCase.Entity
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private UserContext _dbContext;
        private DbSet<T> _objectSet;
        public Repository(UserContext context)
        {
           _dbContext = context;
           _objectSet = context.Set<T>();
        }
         
        public List<T> List()
        {
            return _objectSet.ToList();
        }
        //public List<T> List(x => x.Id ==3 )
        //Veya
        public List<T> List(Expression<Func<T, bool>> where)
        {
            return _objectSet.Where(where).ToList();
        }

        public IQueryable<T> ListQueryable()
        {
           return _objectSet.AsQueryable<T>();
           // return _objectSet;
        }
        public IQueryable<T> Where(Expression<Func<T, bool>> where)
        {
            return _objectSet.Where(where);
        }

        public IQueryable<T> OrderBy<TKey>(Expression<Func<T, TKey>> orderBy, bool isDesc)
        {
            if (isDesc)
                return _objectSet.OrderByDescending(orderBy);
            return _objectSet.OrderBy(orderBy);
        }

        public int Insert(T obj)
        {
            _objectSet.Add(obj);                
            return Save();
        }

        public int Update(T obj)
        {
            _objectSet.Update(obj);
            return Save();
        }

        public int Delete(T obj)
        { 
            _objectSet.Remove(obj);
            return Save();
        }

        public int Save()
        {
            return _dbContext.SaveChanges();
        }

        public T Find(Expression<Func<T, bool>> where)
        {
            return _objectSet.FirstOrDefault(where);
        } 
    } 
}
