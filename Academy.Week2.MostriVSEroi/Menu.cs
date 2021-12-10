using Academy.Week2.MostriVSEroi.Core.Interfaces;
using Academy.Week2.MostriVSEroi.Core.BusinessLayers;
using Academy.Week2.MostriVSEroi.Mock.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Academy.Week2.MostriVSEroi.Core.Models;

namespace Academy.Week2.MostriVSEroi.Client
{
    public class Menu
    {
        private static readonly IBusinessLayer mainBL = new BusinessLayer(new MockArmaRepository(), new MockEroeRepository(), new MockMostroRepository(), new MockUtenteRepository());
        internal static void Start()
        {
            Console.WriteLine("Benvenuto!");

            char choice;

            do
            {
                Console.WriteLine("[1] Accedi" +
                    "\n[2] Registrati"+
                    "\n[q] Esci");

                choice = Console.ReadKey().KeyChar;
                Console.WriteLine();

                switch (choice)
                {
                    case '1':
                        Accedi();
                        break;
                    case '2':
                        Registrati();
                        break;
                    case 'q':
                        Console.WriteLine("\n Alla prossima partita");
                        return;
                    default:
                        Console.WriteLine("Scelta non disponibile. Riprova!");
                        break;
                }

            } while (!(choice == 'q'));
        }

        private static void Registrati()
        {
            string nickname;
            bool var;
            do
            {
                Console.WriteLine("Inserisci Nickname");
                nickname = Console.ReadLine();
                var = mainBL.NicknameExists(nickname);
                if (!var)
                {
                    Console.WriteLine("Nickname già preso, sei arrivato tardi");
                }
            } while (!var);
            Console.WriteLine("Inserisci Password");
            string password = Console.ReadLine();
            Utente user = new Utente();
            user.Nickname = nickname;
            user.Password = password;
            if (mainBL.Add(user))
            {
                Console.WriteLine("Registrazione avvenuta con successo");
                UserMenu(user);
            }

        }

        private static void Accedi()
        {
            Console.WriteLine("Inserisci Nickname");
            string nickname=Console.ReadLine();
            Console.WriteLine("Inserisci Password");
            string password=Console.ReadLine();
            Utente utente = mainBL.Accedi(nickname,password);
            if(utente == null)
            {
                Console.WriteLine("\nnickname e/o password errati");
            }
            else
            {
                if (utente.IsAdmin)
                {
                    AdminMenu(utente);
                }
                else
                {
                    UserMenu(utente);
                }
            }
        }

        private static void AdminMenu(Utente utente)
        {
            char choice;
            do
            {
                Console.WriteLine("[1] Gioca" +
                    "\n[2] Crea Nuovo Eroe" +
                    "\n[3] Elimina Eroe" +
                    "\n[4] Crea Mostro" +
                    "\n[5] Mostra classifica" +
                    "\n[q] Esci");

                choice = Console.ReadKey().KeyChar;
                Console.WriteLine();

                switch (choice)
                {
                    case '1':
                        Gioca(utente);
                        break;
                    case '2':
                        CreaEroe(utente);
                        break;
                    case '3':
                        EliminaEroe(utente);
                        break;
                    case '4':
                        CreaMostro();
                        break;
                    case '5':
                        LeaderBoard();
                        break;
                    case 'q':
                        return;
                    default:
                        Console.WriteLine("Scelta non disponibile. Riprova!");
                        break;
                }

            } while (!(choice == 'q'));
        }

        private static void LeaderBoard()
        {
            IEnumerable<LeaderBoard> best = mainBL.Leaderboard();
            foreach (LeaderBoard item in best)
            {
                Console.WriteLine($"NomeEroe:{item.eroe}, Punteggio:{item.exp}, Proprietario:{item.utente}");
            }
        }

        private static void StampaMigliori(IEnumerable<(string, int, string)> best)
        {
            
        }

        private static void CreaMostro()
        {
            Console.WriteLine("Inserire nome del mostro");
            string nomeMostro = Console.ReadLine();
            Console.WriteLine("Seleziona Categoria");
            int i = 1;
            foreach (string categoria in Enum.GetNames(typeof(CategoriaMostro)))
            {
                Console.WriteLine(i + " " + categoria);
                i++;
            }
            int category;
            while (!int.TryParse(Console.ReadLine(), out category) || category >= i)
            {
                Console.WriteLine("Inserisci un valore valido");
            }
            Console.WriteLine("Seleziona id Arma");
            CategoriaMostro tipoArma = (CategoriaMostro)category;
            string arma = $"Arma{tipoArma}";
            IEnumerable<Arma> armi = mainBL.GetArmiByCategory(arma);
            StampaArma(armi);
            int IdArma;
            while (!int.TryParse(Console.ReadLine(), out IdArma) || !armi.Where(a => a.Id == IdArma).Any())
            {
                Console.WriteLine("Inserisci un valore valido");
            }
            int livello;
            Console.WriteLine("Seleziona livello mostro");
            while (!int.TryParse(Console.ReadLine(), out livello) || (livello < 1 || livello > 5))
            {
                Console.WriteLine("Inserisci un valore valido tra 0 e 5");
            }
            Mostro mostro = new Mostro();
            mostro.Nome = nomeMostro;
            mostro.Livello = livello;
            mostro.IdArma = IdArma;
            mostro.Categoria = (CategoriaMostro)category;
            mostro.PuntiVita = livello * 20;
            mainBL.Add(mostro);
        }

        private static void UserMenu(Utente utente)
        {

            char choice;
            do
            {
                Console.WriteLine("[1] Gioca" +
                    "\n[2] Crea Nuovo Eroe" +
                    "\n[3] Elimina Eroe" +
                    "\n[q] Esci");

                choice = Console.ReadKey().KeyChar;
                Console.WriteLine();

                switch (choice)
                {
                    case '1':
                        Gioca(utente);
                        break;
                    case '2':
                        CreaEroe(utente);
                        break;
                    case '3':
                        EliminaEroe(utente);
                        break;
                    case 'q':
                        return;
                    default:
                        Console.WriteLine("Scelta non disponibile. Riprova!");
                        break;
                }

            } while (!(choice == 'q'));
        }

        private static void EliminaEroe(Utente utente)
        {
            IEnumerable<Eroe> eroes = mainBL.GetEroi(utente.Id);
            StampaEroi(eroes);
            Console.WriteLine("inserisci id dell'eroe da eliminare");
            int id;
            while (!int.TryParse(Console.ReadLine(), out id))
            {
                Console.WriteLine("Inserisci un valore valido");
            }
            if (mainBL.RemoveEroe(eroes.Where(e => e.Id == id).FirstOrDefault()))
            {
                Console.WriteLine("L'eroe è stato cancellato");
            }
        }

        private static void StampaEroi(IEnumerable<Eroe> eroi)
        {
            if(eroi.Count() == 0)
            {
                Console.WriteLine("Non possiedi eroi");
            }
            foreach (Eroe e in eroi)
            {
                Console.WriteLine(e.ToString());
            }
        }

        private static void CreaEroe(Utente utente)
        {
            Console.WriteLine("Inserire nome dell'eroe");
            string nomeEroe=Console.ReadLine();
            Console.WriteLine("Seleziona Categoria");
            int i = 1;
            foreach(string categoria in Enum.GetNames(typeof(CategoriaEroe)))
            {
                Console.WriteLine(i + " " + categoria);
                i++;
            }
            int category;
            while (!int.TryParse(Console.ReadLine(), out category) || category>=i)
            {
                Console.WriteLine("Inserisci un valore valido");
            }
            Console.WriteLine("Seleziona id Arma");
            CategoriaEroe tipoArma = (CategoriaEroe)category;
            string arma = $"Arma{tipoArma}";
            IEnumerable<Arma>  armi = mainBL.GetArmiByCategory(arma);
            StampaArma(armi);
            int IdArma;
            while (!int.TryParse(Console.ReadLine(), out IdArma) || !armi.Where(a=>a.Id==IdArma).Any())
            {
                Console.WriteLine("Inserisci un valore valido");
            }
            Eroe eroe = new Eroe();
            eroe.IdArma= IdArma;
            eroe.Nome = nomeEroe;
            eroe.Categoria = (CategoriaEroe)category;
            eroe.IdUtente = utente.Id;
            mainBL.Add(eroe);
        }

        private static void StampaArma(IEnumerable<Arma> armi)
        {
            foreach(Arma arma in armi)
            {
                Console.WriteLine(arma.ToString());
            }
        }

        private static void Gioca(Utente utente)
        {
            IEnumerable<Eroe> eroes = mainBL.GetEroi(utente.Id);
            StampaEroi(eroes);
            Eroe eroe;
            Console.WriteLine("inserisci id dell'eroe con cui giocare");
            do
            {
                int id;
                while (!int.TryParse(Console.ReadLine(), out id))
                {
                    Console.WriteLine("Inserisci un valore valido");
                }
                eroe = eroes.Where(e => e.Id == id).FirstOrDefault();
                if(eroe == null)
                {
                    Console.WriteLine("non esiste un eroe con quell'id");
                }
            }while(eroe== null);
            //TODO gameplay
        }
    }
}
