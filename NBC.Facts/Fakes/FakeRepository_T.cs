﻿using NBC.DataAccess.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBC.Facts.Fakes
{
    class FakeRepository<T> : IRepository<T> where T : class
    {

        private HashSet<T> items = new HashSet<T>();

        public T Add(T item)
        {
            items.Add(item);
            return item;
        }

        public IQueryable<T> Query(Func<T, bool> criteria)
        {
            return items.Where(criteria).AsQueryable();
        }

        public T Remove(T item)
        {
            items.Remove(item);
            return item;
        }

        public int SaveChanges()
        {
            return 0;
        }

        public void SetModified(T item)
        {
            //
        }
    }
}
