using MvcProject.DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MvcProject.DataAccess.Concrete.Repositories
{
    public class GenericRepository<T> : IRepository<T> where T : class
    {
        Context c = new Context();
        DbSet<T> _object;

        public GenericRepository()
        {
            _object = c.Set<T>();
        }
        public void Delete(T item)
        {
            var deleteItem = c.Entry(item);
            deleteItem.State = EntityState.Deleted;
            c.SaveChanges();
            //_object.Remove(item);
            //c.SaveChanges();
        }

        public T Get(Expression<Func<T, bool>> filter)
        {
            return _object.SingleOrDefault(filter);
        }

        public void Insert(T item)
        {
            var addedItem = c.Entry(item);
            addedItem.State = EntityState.Added;
            c.SaveChanges();
            //_object.Add(item);
            //c.SaveChanges();
        }

        public List<T> List()
        {
            return _object.ToList();
        }

        public List<T> Listtttttt()
        {
            return _object.ToList();
        }

        public List<T> List(Expression<Func<T, bool>> filter)
        {
            return _object.Where(filter).ToList();
        }

        public void Update(T item)
        {
            var updateItem = c.Entry(item);
            updateItem.State = EntityState.Modified;
            c.SaveChanges();
        }
    }
}
