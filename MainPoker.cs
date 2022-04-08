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

        
        private int _valeur;

        

        private Evaluateur evaluateur;

        

        private string valeurEnFrancais;
        public MainPoker()
        {
            _valeur = 0;
            lesCartes = new Carte[RondePoker.NB_CARTES_PAR_MAIN];
            for(int i=0; i<RondePoker.NB_CARTES_PAR_MAIN; i++)
            {
                lesCartes[i] = new Carte();

            }
        }

        public void AjouterCarte(int indice, Carte c)
        {
            lesCartes[indice] = c;
        }
        public void Evaluer (int nbJoueur)
        {
         
            evaluateur = new Evaluateur(lesCartes);
            _valeur = evaluateur.getValeur();
            valeurEnFrancais = evaluateur.ConvertitValeurEnFrancais(_valeur);
            AfficherValeur(nbJoueur,valeurEnFrancais, 5);
        }

        public void AfficherGagnant(int joueurGagnant)
        {

            evaluateur = new Evaluateur(lesCartes);
            _valeur = evaluateur.getValeur();
            valeurEnFrancais = evaluateur.ConvertitValeurEnFrancais(_valeur);
            AfficherValeur(joueurGagnant, valeurEnFrancais, joueurGagnant);
        }
        public int getValeurMain()
        {
            evaluateur = new Evaluateur(lesCartes);
            int valeur;
            valeur = evaluateur.getValeur();
            return valeur;
        }
        public void Afficher(int numJoueur)
        {
            for (int i = 0; i < RondePoker.NB_CARTES_PAR_MAIN; i++)
            {
                lesCartes[i].Afficher(i, numJoueur);
            }
         //   AfficherValeur(numJoueur);
        }

        public void AfficherValeur(int numJoueur, string message, int nbJoueur)
        {
            int decalageEntete = 4;
            Console.SetCursorPosition(30, decalageEntete + (numJoueur * 4) + 1);
            Console.BackgroundColor = ConsoleColor.Yellow;
            Console.ForegroundColor = ConsoleColor.DarkBlue;

            if (numJoueur == 0)
            {
                if (nbJoueur == 0)
                {
                    Console.BackgroundColor = ConsoleColor.Green;
                    Console.ForegroundColor = ConsoleColor.Black;
                }
                else
                {
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.ForegroundColor = ConsoleColor.Black;
                }
                Console.Write(message);
            }
                if (numJoueur == 1)
            {
                if (nbJoueur == 1)
                {
                    Console.BackgroundColor = ConsoleColor.Green;
                    Console.ForegroundColor = ConsoleColor.Black;
                }
                else
                {
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.ForegroundColor = ConsoleColor.Black;
                }
                Console.Write(message);
            }
            if (numJoueur == 2)
            {
                if (nbJoueur == 2)
                {
                    Console.BackgroundColor = ConsoleColor.Green;
                    Console.ForegroundColor = ConsoleColor.Black;
                }
                else
                {
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.ForegroundColor = ConsoleColor.Black;
                }
                Console.Write(message);
            }
            if (numJoueur == 3)
            {
                if (nbJoueur == 3)
                {
                    Console.BackgroundColor = ConsoleColor.Green;
                    Console.ForegroundColor = ConsoleColor.Black;
                }
                else
                {
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.ForegroundColor = ConsoleColor.Black;
                }
                Console.Write(message);

            }
        }


    }
}
