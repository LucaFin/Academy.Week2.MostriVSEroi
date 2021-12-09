using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy.Week2.MostriVSEroi.Core.Interfaces
{
    public interface IRepository<T> { 
        IEnumerable<T> FetchAll(Func<T, bool> filter = null);
        bool Add(T item);
        bool Remove(T item);
    }
}
