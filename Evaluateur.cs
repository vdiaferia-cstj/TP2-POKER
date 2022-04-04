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

        public Carte[] Cartes;
        
        public Evaluateur(Carte[] cartes)
        {
            Cartes = cartes;
        }

        //    TrierMain() 
        /*Met les cartes d’une main en ordre décroissant de valeur */
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
            TrierMain();
            quinteCouleur();
            carree();
            couleur();
            brelan();

            return 0;
            
        }
   // ConvertitValeurEnFrancais 

   /*(int) :string À partir d’une valeur en paramètre retourne son équivalent en Français */

        bool quinteCouleur()
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

        bool carree()
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

         bool couleur()

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

        bool brelan()
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

    }
}
