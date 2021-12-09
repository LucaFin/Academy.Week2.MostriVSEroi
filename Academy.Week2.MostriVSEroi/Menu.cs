﻿using Academy.Week2.MostriVSEroi.Core.Interfaces;
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

        }

        private static void Accedi()
        {
            Console.WriteLine("Inserisci Nickname");
            string nickname=Console.ReadLine();
            Console.WriteLine("Inserisci Password");
            string password=Console.ReadLine();
            Utente utente = mainBL.Accedi(nickname,password);

        }
    }
}