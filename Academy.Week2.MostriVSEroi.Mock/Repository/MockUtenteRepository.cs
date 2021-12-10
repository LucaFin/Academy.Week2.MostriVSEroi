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
        public bool Add(Utente user)
        {
            user.IsAdmin = false;
            user.Id = InMemoryStorage.Utenti.Max(u => u.Id) + 1;
            int count = InMemoryStorage.Utenti.Count;
            InMemoryStorage.Utenti.Add(user);
            return count < InMemoryStorage.Utenti.Count;
        }

        public IEnumerable<Utente> FetchAll(Func<Utente, bool> filter = null)
        {
            if (filter == null)
            {
                return InMemoryStorage.Utenti;
            }
            return InMemoryStorage.Utenti.Where(filter);
        }

        public bool Remove(Utente item)
        {
            throw new NotImplementedException();
        }
    }
}
