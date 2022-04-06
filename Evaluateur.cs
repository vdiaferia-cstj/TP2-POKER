using AtelierOO_101.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP2_POKER
{
    class Evaluateur
    {
        const int QUINTE_COULEUR = 9000000;
        const int CARREE = 8000000;
        const int FULL =   7000000;
        const int COULEUR = 6000000;
        const int QUINTE = 5000000;
        const int BRELAN = 4000000;
        const int DOUBLE_PAIRE = 3000000;
        const int PAIRE = 2000000;
        const int CARTE_HAUTE = 1000000;

        public Carte[] Cartes;
        
        public Evaluateur(Carte[] cartes)
        {
            Cartes = cartes;
        }

    
        public void TrierMain()
        {
            Array.Sort(Cartes, ComparerDeuxCartes);

            
        }
        public int ComparerDeuxCartes (Carte carte1, Carte carte2)
            {
            if (carte1.getValeur() > carte2.getValeur())
            {
                return -1;
            }
            if (carte2.getValeur() > carte1.getValeur())
            {
                return 1;
            }
            return 0;
        }
      //   GetValeur() 
            /*:int Retourne la valeur maximale de la main de cinq cartes */
            public int getValeur()
        {
            int valeurMain;
            int valeurDesCartes;
            TrierMain();
            if (quinteCouleur())
            {
                valeurDesCartes = Cartes[0].getValeur();
                valeurMain = QUINTE_COULEUR + valeurDesCartes;
                return valeurMain;
            }
            if (carree())
            {
                valeurMain = CARREE;
                return valeurMain;
            }
            if (full())
            {
                valeurMain = FULL;
                return valeurMain;
            }
            if (couleur())
            {
                valeurMain = COULEUR;
                return valeurMain;
            }
            if (quinte())
            {
                valeurMain = QUINTE;
                return valeurMain;
            }
            if (brelan())
            {
                valeurMain = BRELAN;
                return valeurMain;
            }
            if (doublePaire())
            {
                valeurMain = DOUBLE_PAIRE;
                return valeurMain;
            }
            if (paire())
            {
                valeurMain = PAIRE;
                return valeurMain;
            }
            if (carteHaute())
            {
                valeurMain = CARTE_HAUTE;
                return valeurMain;
            }
            return 0;
            
        }
   // ConvertitValeurEnFrancais 

   /*(int) :string À partir d’une valeur en paramètre retourne son équivalent en Français */
        public string ConvertitValeurEnFrancais()
        {
            string valeurEnFrancais = "rien";
            int valeurMain = getValeur();
            return valeurEnFrancais;
        }
        private bool quinteCouleur()
        {
            if ((Cartes[0].getSorte() == Cartes[1].getSorte() &&
                Cartes[1].getSorte() == Cartes[2].getSorte() &&
                Cartes[2].getSorte() == Cartes[3].getSorte() &&
                Cartes[3].getSorte() == Cartes[4].getSorte()) 
                &&
                (Cartes[0].getValeur() -4) == Cartes[4].getValeur()
                )
            {
                return true;
            }
            
            return false;
        }

        private bool carree()
        {
            if ((Cartes[0].getValeur() == Cartes[1].getValeur() &&
                Cartes[1].getValeur() == Cartes[2].getValeur() &&
                Cartes[2].getValeur() == Cartes[3].getValeur())
                ||
                (Cartes[1].getValeur() == Cartes[2].getValeur() &&
                Cartes[2].getValeur() == Cartes[3].getValeur() &&
                Cartes[3].getValeur() == Cartes[4].getValeur()))
            {
                return true;
            }
            return false;
        }

        private bool full()
        {
            if ((Cartes[0].getValeur() == Cartes[1].getValeur()
              && Cartes[1].getValeur() == Cartes[2].getValeur()
              && Cartes[3].getValeur() == Cartes[4].getValeur())
              ||
                (Cartes[0].getValeur() == Cartes[1].getValeur()
              && Cartes[2].getValeur() == Cartes[3].getValeur()
              && Cartes[3].getValeur() == Cartes[4].getValeur()))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private bool couleur()

        {
            if (Cartes[0].getSorte() == Cartes[1].getSorte() &&
                Cartes[1].getSorte() == Cartes[2].getSorte() &&
                Cartes[2].getSorte() == Cartes[3].getSorte() &&
                Cartes[3].getSorte() == Cartes[4].getSorte())
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private bool quinte()
        {
            if ((Cartes[0].getValeur() - 4) == Cartes[4].getValeur())
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private bool brelan()
        {
            if ((Cartes[0].getSorte() == Cartes[1].getSorte() &&
                Cartes[1].getSorte() == Cartes[2].getSorte())
                ||
                (Cartes[1].getSorte() == Cartes[2].getSorte() &&
                Cartes[2].getSorte() == Cartes[3].getSorte())
                ||
                (Cartes[2].getSorte() == Cartes[3].getSorte() &&
                Cartes[3].getSorte() == Cartes[4].getSorte()))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private bool doublePaire()
        {
            if ((Cartes[0].getValeur() == Cartes[1].getValeur() &&
                Cartes[2].getValeur() == Cartes[3].getValeur())
                ||
                (Cartes[0].getValeur() == Cartes[1].getValeur() &&
                Cartes[3].getValeur() == Cartes[4].getValeur())
                ||
                (Cartes[1].getValeur() == Cartes[2].getValeur() &&
                Cartes[3].getValeur() == Cartes[4].getValeur())
                )
            {
                return true;
            }
            else
                return false;
        }

        private bool paire()
        {
            if ((Cartes[0].getValeur() == Cartes[1].getValeur())
             || (Cartes[1].getValeur() == Cartes[2].getValeur())
             || (Cartes[2].getValeur() == Cartes[3].getValeur())
             || (Cartes[3].getValeur() == Cartes[4].getValeur()))
            {
                return true;
            }
            else
                return false;
        }
        private bool carteHaute()
        {
            return true;
        }



    }
}
