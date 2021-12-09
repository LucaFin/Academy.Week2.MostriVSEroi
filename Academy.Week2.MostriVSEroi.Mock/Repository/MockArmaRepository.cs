using Academy.Week2.MostriVSEroi.Core.Interfaces;
using Academy.Week2.MostriVSEroi.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy.Week2.MostriVSEroi.Mock.Repository
{
    public class MockArmaRepository : IArmaRepository
    {
        public bool Add(Arma item)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Arma> FetchAll(Func<Arma, bool> filter = null)
        {
            if (filter == null)
            {
                return InMemoryStorage.Armi;
            }
            return InMemoryStorage.Armi.Where(filter);
        }

        public bool Remove(Arma item)
        {
            throw new NotImplementedException();
        }
    }
}
