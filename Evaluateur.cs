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
                valeurDesCartes =+((int)Math.Pow(Cartes[4].getValeur(),0));
                valeurDesCartes = +((int)Math.Pow(Cartes[3].getValeur(), 1));
                valeurDesCartes = +((int)Math.Pow(Cartes[2].getValeur(), 2));
                valeurDesCartes = +((int)Math.Pow(Cartes[1].getValeur(), 3));
                valeurDesCartes = +((int)Math.Pow(Cartes[0].getValeur(), 4));
                valeurMain = CARREE + valeurDesCartes;
                return valeurMain;
            }
            if (full())
            {
                valeurDesCartes = +((int)Math.Pow(Cartes[4].getValeur(), 0));
                valeurDesCartes = +((int)Math.Pow(Cartes[3].getValeur(), 1));
                valeurDesCartes = +((int)Math.Pow(Cartes[2].getValeur(), 2));
                valeurDesCartes = +((int)Math.Pow(Cartes[1].getValeur(), 3));
                valeurDesCartes = +((int)Math.Pow(Cartes[0].getValeur(), 4));
                
                valeurMain = FULL + valeurDesCartes;
                return valeurMain;
            }
            if (couleur())
            {
                valeurDesCartes = Cartes[0].getValeur();

                valeurMain = COULEUR + valeurDesCartes;
                return valeurMain;
            }
            if (quinte())
            {
                valeurDesCartes = +((int)Math.Pow(Cartes[4].getValeur(), 0));
                
                valeurMain = QUINTE + valeurDesCartes;
                return valeurMain;
            }
            if (brelan())
            {
                valeurDesCartes = +((int)Math.Pow(Cartes[4].getValeur(), 0));
                valeurDesCartes = +((int)Math.Pow(Cartes[3].getValeur(), 1));
                valeurDesCartes = +((int)Math.Pow(Cartes[2].getValeur(), 2));
                valeurDesCartes = +((int)Math.Pow(Cartes[1].getValeur(), 3));
                valeurDesCartes = +((int)Math.Pow(Cartes[0].getValeur(), 4));
                valeurMain = BRELAN + valeurDesCartes;
                return valeurMain;
            }
            if (doublePaire())
            {
                valeurDesCartes = +((int)Math.Pow(Cartes[4].getValeur(), 0));
                valeurDesCartes = +((int)Math.Pow(Cartes[3].getValeur(), 1));
                valeurDesCartes = +((int)Math.Pow(Cartes[2].getValeur(), 2));
                valeurDesCartes = +((int)Math.Pow(Cartes[1].getValeur(), 3));
                valeurDesCartes = +((int)Math.Pow(Cartes[0].getValeur(), 4));
                valeurMain = DOUBLE_PAIRE + valeurDesCartes;
                return valeurMain;
            }
            if (paire())
            {
                valeurDesCartes = +((int)Math.Pow(Cartes[4].getValeur(), 0));
                valeurDesCartes = +((int)Math.Pow(Cartes[3].getValeur(), 1));
                valeurDesCartes = +((int)Math.Pow(Cartes[2].getValeur(), 2));
                valeurDesCartes = +((int)Math.Pow(Cartes[1].getValeur(), 3));
                valeurDesCartes = +((int)Math.Pow(Cartes[0].getValeur(), 4));
                valeurMain = PAIRE + valeurDesCartes;
                return valeurMain;
            }
            if (carteHaute())
            {
                valeurDesCartes = Cartes[0].getValeur();
                valeurMain = CARTE_HAUTE + valeurDesCartes;
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
            if ((Cartes[0].getValeur() - 1) == Cartes[1].getValeur()
             && (Cartes[1].getValeur() - 1) == Cartes[2].getValeur()
             && (Cartes[2].getValeur() - 1) == Cartes[3].getValeur()
             && (Cartes[3].getValeur() - 1) == Cartes[4].getValeur())
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
            if ((Cartes[0].getValeur() == Cartes[1].getValeur() &&
                Cartes[1].getValeur() == Cartes[2].getValeur())
                ||
                (Cartes[1].getValeur() == Cartes[2].getValeur() &&
                Cartes[2].getValeur() == Cartes[3].getValeur())
                ||
                (Cartes[2].getValeur() == Cartes[3].getValeur() &&
                Cartes[3].getValeur() == Cartes[4].getValeur()))
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
