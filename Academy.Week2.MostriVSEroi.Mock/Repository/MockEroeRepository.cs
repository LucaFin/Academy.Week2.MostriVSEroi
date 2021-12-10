using Academy.Week2.MostriVSEroi.Core.Interfaces;
using Academy.Week2.MostriVSEroi.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy.Week2.MostriVSEroi.Mock.Repository
{
    public class MockEroeRepository : IEroeRepository
    {
        public bool Add(Eroe eroe)
        {
            eroe.Id = InMemoryStorage.Eroe.Max(e => e.Id) + 1;
            eroe.Livello = 1;
            eroe.PuntiVita = 20;
            eroe.PuntiAccumulati = 0;
            int count = InMemoryStorage.Eroe.Count;
            InMemoryStorage.Eroe.Add(eroe);
            return count < InMemoryStorage.Eroe.Count;
        }

        public IEnumerable<Eroe> FetchAll(Func<Eroe, bool> filter = null)
        {
            if (filter == null)
            {
                return InMemoryStorage.Eroe;
            }
            return InMemoryStorage.Eroe.Where(filter);
        }

        public bool Remove(Eroe eroe)
        {
            if (eroe == null)
            {
                return false;
            }
            return InMemoryStorage.Eroe.Remove(eroe);
        }
    }
}
