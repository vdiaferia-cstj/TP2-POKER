using AtelierOO_101.Classes;
using System;

namespace TP2_Poker
{
    class Program
    {
        static void Main(string[] args)
        {
            RondePoker ronde= new RondePoker();
            Paquet paquet = new Paquet();
            bool go = true;
            string decision;
            while (go)
            {
                ronde.Jouer();
                decision = Console.ReadLine();
                if ( decision.Length > 0 && (decision[0] == 'Q' || decision[0] == 'q') )
                    go = false;
               
                
            }
        }
    }
}

