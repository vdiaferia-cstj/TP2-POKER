using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP2_POKER;

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

        private int _gagnant;

        private Evaluateur evaluateur;

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
           


            MainsDesJoueurs[0].Evaluer(0);
            MainsDesJoueurs[1].Evaluer(1);
            MainsDesJoueurs[2].Evaluer(2);
            MainsDesJoueurs[3].Evaluer(3);

            _gagnant = Convert.ToInt32(determinerGagnant());
            MainsDesJoueurs[_gagnant].AfficherGagnant(_gagnant);

            for (int i = 0; i < NB_JOUEURS; i++)
            {
                MainsDesJoueurs[i].Afficher(i);
            }
            return 0;
        }

        private void TricherMainsDesJoueurs()
        {
            MainsDesJoueurs[0].lesCartes[0] = new Carte(1, 10);
            MainsDesJoueurs[0].lesCartes[1] = new Carte(2, 10);
            MainsDesJoueurs[0].lesCartes[2] = new Carte(3, 10);
            MainsDesJoueurs[0].lesCartes[3] = new Carte(0, 7);
            MainsDesJoueurs[0].lesCartes[4] = new Carte(2, 8);

            MainsDesJoueurs[1].lesCartes[0] = new Carte(1, 10);
            MainsDesJoueurs[1].lesCartes[1] = new Carte(2, 10);
            MainsDesJoueurs[1].lesCartes[2] = new Carte(3, 10);
            MainsDesJoueurs[1].lesCartes[3] = new Carte(0, 6);
            MainsDesJoueurs[1].lesCartes[4] = new Carte(2, 8);

            MainsDesJoueurs[2].lesCartes[0] = new Carte(0, 9);
            MainsDesJoueurs[2].lesCartes[1] = new Carte(1, 8);
            MainsDesJoueurs[2].lesCartes[2] = new Carte(2, 5);
            MainsDesJoueurs[2].lesCartes[3] = new Carte(1, 6);
            MainsDesJoueurs[2].lesCartes[4] = new Carte(3, 5);

            MainsDesJoueurs[3].lesCartes[0] = new Carte(3, 12);
            MainsDesJoueurs[3].lesCartes[1] = new Carte(3, 9);
            MainsDesJoueurs[3].lesCartes[2] = new Carte(2, 8);
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
            Console.Write(" Valeurs des mains au Poker\n      Codé par Vincent Diaferia");
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



        public int EvaluerMains() //Calcule et initialise la valeur de chaque main des Joueurs
        {
            
            MainsDesJoueurs[0].Evaluer(0);
            MainsDesJoueurs[1].Evaluer(1);
            MainsDesJoueurs[2].Evaluer(2);
            MainsDesJoueurs[3].Evaluer(3);

            return 0;
        }
        public int determinerGagnant()
        {
            int gagnant = 0;
            int[] valeursDesMains = new int[4];
            valeursDesMains[0] = (int)(MainsDesJoueurs[0].getValeurMain());
            valeursDesMains[1] = (int)(MainsDesJoueurs[1].getValeurMain());
            valeursDesMains[2] = (int)(MainsDesJoueurs[2].getValeurMain());
            valeursDesMains[3] = (int)(MainsDesJoueurs[3].getValeurMain());

            gagnant = valeursDesMains.Max();
            

            if (gagnant == valeursDesMains[0])
            {
                gagnant = 0;
            }
            if (gagnant == valeursDesMains[1])
            {
                gagnant = 1;
            }
            if (gagnant == valeursDesMains[2])
            {
                gagnant = 2;
            }
            if (gagnant == valeursDesMains[3])
            {
                gagnant = 3;
            }
            return gagnant;
        }
    }
}
