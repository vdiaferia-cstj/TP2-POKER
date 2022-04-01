using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtelierOO_101.Classes
{
    class RondePoker
    {
        private static int _couleurTapis = 2; // 2 == vert
        private static int _couleurTexte = 15; // 15 == blanc

        private int _couleurEnteteBack = 4;
        private int _couleurEnteteTexte = 15;

        public const int NB_CARTES_PAR_MAIN = 5;
        public static int NB_JOUEURS = 4;

        private Paquet lePaquet = new Paquet();

        private MainPoker[] MainsDesJoueurs;

        public RondePoker()
        {
            MainsDesJoueurs = new MainPoker[NB_JOUEURS];
            for (int i = 0; i < NB_JOUEURS; i++)
            {
                MainsDesJoueurs[i] = new MainPoker();
            }
        }

        public int Jouer()
        {
            CouleurTapis();
            Console.Clear(); 
            DessinerEnEntete();
              
            lePaquet.Brasser();

            for (int i = 0; i < NB_CARTES_PAR_MAIN * NB_JOUEURS;  i++)
            {
                Carte c = lePaquet.Distribuer();
                int indice = i / NB_JOUEURS;
                MainsDesJoueurs[i % NB_JOUEURS].AjouterCarte(indice, c);
            }

            TricherMainsDesJoueurs();

            for (int i = 0; i < NB_JOUEURS; i++)
            {
                MainsDesJoueurs[i].Afficher(i);
            }
            return 0;
        }

        private void TricherMainsDesJoueurs()
        {
            MainsDesJoueurs[0].lesCartes[0] = new Carte(0, 11);
            MainsDesJoueurs[0].lesCartes[1] = new Carte(0, 10);
            MainsDesJoueurs[0].lesCartes[2] = new Carte(0, 9);
            MainsDesJoueurs[0].lesCartes[3] = new Carte(0, 0);
            MainsDesJoueurs[0].lesCartes[4] = new Carte(1, 0);

            MainsDesJoueurs[1].lesCartes[0] = new Carte(0, 12);
            MainsDesJoueurs[1].lesCartes[1] = new Carte(1, 11);
            MainsDesJoueurs[1].lesCartes[2] = new Carte(1, 10);
            MainsDesJoueurs[1].lesCartes[3] = new Carte(2, 2);
            MainsDesJoueurs[1].lesCartes[4] = new Carte(2, 2);

            MainsDesJoueurs[2].lesCartes[0] = new Carte(0, 9);
            MainsDesJoueurs[2].lesCartes[1] = new Carte(1, 8);
            MainsDesJoueurs[2].lesCartes[2] = new Carte(2, 7);
            MainsDesJoueurs[2].lesCartes[3] = new Carte(1, 6);
            MainsDesJoueurs[2].lesCartes[4] = new Carte(3, 5);

            MainsDesJoueurs[3].lesCartes[0] = new Carte(3, 12);
            MainsDesJoueurs[3].lesCartes[1] = new Carte(3, 9);
            MainsDesJoueurs[3].lesCartes[2] = new Carte(3, 8);
            MainsDesJoueurs[3].lesCartes[3] = new Carte(3, 2);
            MainsDesJoueurs[3].lesCartes[4] = new Carte(3, 0);
        }

        public static void CouleurTapis()
        {
            Console.BackgroundColor = (ConsoleColor)_couleurTapis;
            Console.ForegroundColor = (ConsoleColor)_couleurTexte;
        }

        private void DessinerEnEntete()
        {
            Console.SetCursorPosition(0, 1);
            CouleurEntete();
            Console.Write(" Valeurs des mains au Poker\n      Codé par Alain Martel");
        }
        public void CouleurEntete()
        {
            Console.BackgroundColor = (ConsoleColor)_couleurEnteteBack;
            Console.ForegroundColor = (ConsoleColor)_couleurEnteteTexte;
        }

        public int AfficherLePaquet()
        {
             //lePaquet.Brasser();
             lePaquet.Afficher();
             Console.ReadLine();
            return 0;
        }
    }
}
