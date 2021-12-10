using Academy.Week2.MostriVSEroi.Core.Interfaces;
using Academy.Week2.MostriVSEroi.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy.Week2.MostriVSEroi.Mock.Repository
{
    public class MockMostroRepository : IMostroRepository
    {
        public bool Add(Mostro mostro)
        {
            int count = InMemoryStorage.Mostri.Count;
            InMemoryStorage.Mostri.Add(mostro);
            return count < InMemoryStorage.Mostri.Count;
        }

        public IEnumerable<Mostro> FetchAll(Func<Mostro, bool> filter = null)
        {
            if (filter == null)
            {
                return InMemoryStorage.Mostri;
            }
            return InMemoryStorage.Mostri.Where(filter);
        }

        public bool Remove(Mostro item)
        {
            throw new NotImplementedException();
        }
    }
}
