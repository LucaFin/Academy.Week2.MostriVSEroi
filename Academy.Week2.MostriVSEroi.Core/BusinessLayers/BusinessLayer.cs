using Academy.Week2.MostriVSEroi.Core.Interfaces;
using Academy.Week2.MostriVSEroi.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy.Week2.MostriVSEroi.Core.BusinessLayers
{
    public struct LeaderBoard
    {
        public string eroe;
        public int exp;
        public string utente;
    }
    public class BusinessLayer : IBusinessLayer
    {
        public IArmaRepository MockArmaRepository { get; set; }
        public IEroeRepository MockEroeRepository { get; set; }
        public IMostroRepository MockMostroRepository { get; set; }
        public IUtenteRepository MockUtenteRepository { get; set; }
        public BusinessLayer(IArmaRepository mockArmaRepository, IEroeRepository mockEroeRepository, IMostroRepository mockMostroRepository, IUtenteRepository mockUtenteRepository)
        {
            MockArmaRepository = mockArmaRepository;
            MockEroeRepository = mockEroeRepository;
            MockMostroRepository = mockMostroRepository;
            MockUtenteRepository = mockUtenteRepository;
        }

        public Utente Accedi(string? nickname, string? password)
        {
            return MockUtenteRepository.FetchAll(u => u.Nickname == nickname && u.Password==password).FirstOrDefault();
        }

        public bool NicknameExists(string? nickname)
        {
            return !MockUtenteRepository.FetchAll(u=>u.Nickname == nickname).Any();
        }

        public bool Add(Utente user)
        {
            return MockUtenteRepository.Add(user);
        }

        public IEnumerable<Eroe> GetEroi(int id)
        {
            return MockEroeRepository.FetchAll(e => e.IdUtente == id);
        }

        public bool RemoveEroe(Eroe eroe)
        {
            return MockEroeRepository.Remove(eroe);
        }

        public IEnumerable<Arma> GetArmiByCategory(string category)
        {
            TipoArma arma; 
            Enum.TryParse<TipoArma>(category,out arma);
            return MockArmaRepository.FetchAll(a => a.CategoriaArma == arma);
        }

        public bool Add(Eroe eroe)
        {
            return MockEroeRepository.Add(eroe);
        }

        public bool Add(Mostro mostro)
        {
            return MockMostroRepository.Add(mostro);
        }

        public IEnumerable<LeaderBoard> Leaderboard()
        {
            IEnumerable<Eroe> eroi = MockEroeRepository.FetchAll().OrderByDescending(e => e.PuntiAccumulati).Take(10);
            IEnumerable<Utente> utenti = MockUtenteRepository.FetchAll();
            var best = eroi.Join(
                utenti,
                e=>e.IdUtente,
                u=>u.Id,
                (e,u)=> new LeaderBoard()
                {
                    eroe = e.Nome,
                    exp = e.PuntiAccumulati,
                    utente = u.Nickname
                }
                );
            return best;
        }
    }
}
