using System;
using System.Collections.Generic;
using System.Text;
using Tickeo.Core;

namespace Tickeo.Repository.Interface
{
    public interface IRepository<T> where T : BaseClass
    {
        IEnumerable<T> GetAll();
        T Get(long id);

        void Insert(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
