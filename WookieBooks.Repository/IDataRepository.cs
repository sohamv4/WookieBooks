using System.Linq.Expressions;

namespace WookieBooks.Repository
{
    public interface IDataRepository<T> 
    {
        IList<T> GetAll(params Expression<Func<T, object>>[] navigationProperties);
        void Add(params T[] items);
        void Update(params T[] items);
        void Remove(params T[] items);
    }
}