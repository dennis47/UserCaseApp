using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using userCase.Models;

namespace userCase.Entity
{
   /*   public interface IRepository
    {
        void Create(User user);

        void Edit(User user);

        User GetSingleUser(int id);

        void Delete(User user);

        List<User> GetAllUsers();
    }  
    */
    public interface IRepository<T> where T: class
    {
        List<T> List();
        //public List<T> List(x => x.Id ==3 )
        //Veya
        List<T> List(Expression<Func<T, bool>> where);

        IQueryable<T> ListQueryable(); 
        IQueryable<T> Where(Expression<Func<T, bool>> where);
        IQueryable<T> OrderBy<TKey>(Expression<Func<T, TKey>> orderBy, bool isDesc);
        int Insert(T obj);

        int Update(T obj);

        int Delete(T obj);

        int Save();

        T Find(Expression<Func<T, bool>> where);
    }
}
