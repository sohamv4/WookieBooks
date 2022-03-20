using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace WookieBooks.Repository
{
    public class EFGenericRepository<T> : IDataRepository<T> where T : class
    {
        private BooksDbContext _mycontext;
        public EFGenericRepository()
        {
            _mycontext = new BooksDbContext();

        }
        public void Add(params T[] items)
        {
            //array T and loop through the array and foreach of those since entry is one to one and set the enum entity state added ~4
            foreach (var item in items)
            {
                _mycontext.Entry(item).State = EntityState.Added;
            }
            _mycontext.SaveChanges();
        }

        public IList<T> GetAll(params Expression<Func<T, object>>[] navigationProperties)
        {
            //building an expression tree which is an IQueryable
            IQueryable<T> dbQuery = _mycontext.Set<T>();
            foreach (var navigationProperty in navigationProperties)
            {
                dbQuery = dbQuery.Include<T, object>(navigationProperty);
            }
            return dbQuery.ToList<T>();
        }

        public void Remove(params T[] items)
        {
            foreach (T item in items)
            {
                _mycontext.Entry(item).State = EntityState.Deleted;
            }
            _mycontext.SaveChanges();
        }

        public void Update(params T[] items)
        {
            foreach (T item in items)
            {
                _mycontext.Entry(item).State = EntityState.Modified;
            }
            _mycontext.SaveChanges();
        }
        public T GetSingle(Func<T, bool> where, params Expression<Func<T, object>>[] navigationProperties)
        {
            IQueryable<T> dbQuery = _mycontext.Set<T>();
            foreach (Expression<Func<T, object>> navigationproperty in navigationProperties)
            {
                dbQuery = dbQuery.Include<T, object>(navigationproperty);
            }
            return dbQuery.FirstOrDefault(where);

        }
    }
}
