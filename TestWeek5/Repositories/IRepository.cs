using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestWeek5.Repositories
{
    public interface IRepository<T>
    {
        public IList<T> GetAll();
        public T GetByID(int value);
        public bool Add(T item);
    }
}
