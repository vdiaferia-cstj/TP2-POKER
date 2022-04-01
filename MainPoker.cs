using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP2_POKER;

namespace AtelierOO_101.Classes
{
    class MainPoker
    {
        public Carte[] lesCartes { get; set; }

        private Evaluateur evaluateur;
        public MainPoker()
        {
            lesCartes = new Carte[RondePoker.NB_CARTES_PAR_MAIN];
            for(int i=0; i<RondePoker.NB_CARTES_PAR_MAIN; i++)
            {
                lesCartes[i] = new Carte();
            }
            evaluateur = new Evaluateur(lesCartes);
        }

        public void AjouterCarte(int indice, Carte c)
        {
            lesCartes[indice] = c;
        }

        public void Afficher(int numJoueur)
        {
            for (int i = 0; i < RondePoker.NB_CARTES_PAR_MAIN; i++)
            {
                lesCartes[i].Afficher(i, numJoueur);
            }
            AfficherValeur(numJoueur);
        }

        private void AfficherValeur(int numJoueur)
        {
            int decalageEntete = 4;
            Console.SetCursorPosition(30, decalageEntete + (numJoueur * 4) + 1);
            Console.BackgroundColor = ConsoleColor.Yellow;
            Console.ForegroundColor = ConsoleColor.DarkBlue;

            if (numJoueur == 0)
                Console.Write("Paire de Deux au Roi, Dame, Valet");
            if (numJoueur == 1)
                Console.Write("Paire de Quatre à l'As, Roi, Dame");
            if (numJoueur == 2)
                Console.Write("Séquence au Valet");
            if (numJoueur == 3)
            {
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("Couleur à l'AS, Valet, Dix, Quatre, deux");
            }
        }

    }
}
