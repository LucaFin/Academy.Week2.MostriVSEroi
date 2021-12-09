using Academy.Week2.MostriVSEroi.Core.Interfaces;
using Academy.Week2.MostriVSEroi.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy.Week2.MostriVSEroi.Mock.Repository
{
    public class MockUtenteRepository : IUtenteRepository
    {
        public IEnumerable<Utente> FetchAll(Func<Utente, bool> filter = null)
        {
            return InMemoryStorage.Utenti.Where(filter);
        }
    }
}
