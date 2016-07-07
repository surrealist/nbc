using NBC.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBC.DataAccess.Bases
{
    public class RepositoryBase<T> : IRepository<T> where T : class
    {

        private readonly DbContext _context;

        public RepositoryBase(DbContext context)
        {
            _context = context;
        }
        public void SetModified(T item)
        {
            _context.Entry(item).State = EntityState.Modified;
        }
        public T Add(T item)
        {
            if (item is IRecord)
            {
                IRecord thisItem = (IRecord)item;
                thisItem.CreatedBy = "xxx";
                thisItem.CreatedDate = DateTime.Now;
                thisItem.ModifiedBy = "xxx";
                thisItem.ModifiedDate = DateTime.Now;
            }
            return _context.Set<T>().Add(item);
        }

        public IQueryable<T> Query(Func<T, bool> criteria)
        {
            return _context.Set<T>().Where(criteria).AsQueryable();
        }

        public IQueryable<T> All()
        {
            return _context.Set<T>().AsQueryable();
        }

        public T Remove(T item)
        {
            return _context.Set<T>().Remove(item);
        }

        public int SaveChanges()
        {
            foreach (var item in _context.Set<T>())
            {
                if (_context.Entry(item).State == EntityState.Modified)
                {
                    if (item is IRecord)
                    {
                        IRecord thisItem = (IRecord)item;
                        thisItem.ModifiedBy = "xxx";
                        thisItem.ModifiedDate = DateTime.Now;
                    }
                }
            }

            return _context.SaveChanges();
        }
    }
}
