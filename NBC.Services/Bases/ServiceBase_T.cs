using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NBC.DataAccess.Bases;
using NBC.Models;

namespace NBC.Services.Bases
{
    public abstract class ServiceBase<T> : IService<T> where T : class
    {
        //private RootClass _RootClass;
        private readonly IRepository<T> _BaseRepo;

        //public ServiceBase(IRepository<T> baseRepo, RootClass rootClass)
        //{
        //    if (baseRepo == null)
        //    {
        //        throw new ArgumentNullException(nameof(baseRepo));
        //    }
        //    _BaseRepo = baseRepo;
        //    _RootClass = rootClass;
        //}
        public ServiceBase(IRepository<T> baseRepo)
        {
            if (baseRepo == null)
            {
                throw new ArgumentNullException(nameof(baseRepo));
            }
            _BaseRepo = baseRepo;
            
        }
        public virtual void SetModified(T item)
        {
            _BaseRepo.SetModified(item);
        }
        public abstract T Find(params object[] keys);

        public virtual T Add(T item)
        {           
            return _BaseRepo.Add(item);
        }
     
        public virtual IQueryable<T> All() => Query(_ => true);

        public virtual IQueryable<T> Query(Func<T, bool> criteria) => _BaseRepo.Query(criteria);

        public virtual T Remove(T item) => _BaseRepo.Remove(item);

        public virtual int SaveChanges()
        {

            return _BaseRepo.SaveChanges();
        }

    }
}
