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
            TrierMain();
            if (quinteCouleur())
            {
                return encodeQuinteCouleur();
               
            }
            if (carree())
            {
                return encodeCarree();
            }
            if (full())
            {
                return encodeFull();              
            }
            if (couleur())
            {
                return encodeCouleur();
            }
            if (quinte())
            {
               
                return encodeQuinte();
            }
            if (brelan())
            {
               
                return encodeBrelan();
            }
            if (doublePaire())
            {
                
                return encodeDoublePaire();
            }
            if (paire())
            {
                
                return encodePaire();
            }
            if (carteHaute())
            {
                return encodeCarteHaute();
            }
            return 0;
            
        }
        private int encodeQuinteCouleur()
        {
            int valeur = 0;
            valeur += (int)(Cartes[0].getValeur() * Math.Pow(13,0));
            
            return valeur + QUINTE_COULEUR;
        }
        private int encodeCarree()
        {
            int valeur =0;
            if (Cartes[0].getValeur() == Cartes[1].getValeur())
            {
                
                valeur += (int)(Cartes[0].getValeur() * Math.Pow(13, 1));
                valeur += (int)(Cartes[4].getValeur() * Math.Pow(13, 0));
            }
            else
            {
                valeur += (int)(Cartes[4].getValeur() * Math.Pow(13, 1));
                valeur += (int)(Cartes[0].getValeur() * Math.Pow(13, 0));
            }
            return valeur + CARREE;
        }
        private int encodeFull()
        {
            int valeur = 0;
            if (Cartes[0].getValeur() == Cartes[1].getValeur()
             && Cartes[1].getValeur() == Cartes[2].getValeur())
            {
                valeur += (int)(Cartes[0].getValeur() * Math.Pow(13, 1));
                valeur += (int)(Cartes[4].getValeur() * Math.Pow(13, 0));
            }
            else
            {
                valeur += (int)(Cartes[4].getValeur() * Math.Pow(13, 1));
                valeur += (int)(Cartes[0].getValeur() * Math.Pow(13, 0));
            }
            return valeur + FULL;
        }
        private int encodeCouleur()
        {
            int valeur = 0;
            valeur += (int)(Cartes[4].getValeur() * Math.Pow(13, 0));
            valeur += (int)(Cartes[3].getValeur() * Math.Pow(13, 1));
            valeur += (int)(Cartes[2].getValeur() * Math.Pow(13, 2));
            valeur += (int)(Cartes[1].getValeur() * Math.Pow(13, 3));
            valeur += (int)(Cartes[0].getValeur() * Math.Pow(13, 4));

            return valeur + COULEUR;
        }

        private int encodeQuinte()
        {
            int valeur = 0;
            valeur = +(int)(Cartes[0].getValeur() * Math.Pow(13, 0));
            return valeur + QUINTE;
        }

        private int encodeBrelan()
        {
            int valeur = 0;

            if (Cartes[0].getValeur() == Cartes[1].getValeur()
             && Cartes[1].getValeur() == Cartes[2].getValeur())
            {
                valeur += (int)(Cartes[4].getValeur() * Math.Pow(13, 0));
                valeur += (int)(Cartes[3].getValeur() * Math.Pow(13, 1));
                valeur += (int)(Cartes[2].getValeur() * Math.Pow(13, 2));
                return valeur + BRELAN;
            }
            if (Cartes[1].getValeur() == Cartes[2].getValeur()
             && Cartes[2].getValeur() == Cartes[3].getValeur())
            {
                valeur += (int)(Cartes[4].getValeur() * Math.Pow(13, 0));
                valeur += (int)(Cartes[0].getValeur() * Math.Pow(13, 1));
                valeur += (int)(Cartes[1].getValeur() * Math.Pow(13, 2));
                return valeur + BRELAN;

            }
            if (Cartes[2].getValeur() == Cartes[3].getValeur()
             && Cartes[3].getValeur() == Cartes[4].getValeur())
            {
                valeur += (int)(Cartes[4].getValeur() * Math.Pow(13, 2));
                valeur += (int)(Cartes[0].getValeur() * Math.Pow(13, 1));
                valeur += (int)(Cartes[1].getValeur() * Math.Pow(13, 0));
                return valeur + BRELAN;

            }
            return valeur + BRELAN;
        }
        private int encodeDoublePaire()
        {
            int valeur = 0;
            if (Cartes[0].getValeur() == Cartes[1].getValeur()
             && Cartes[3].getValeur() == Cartes[4].getValeur())
            {
                valeur += (int)(Cartes[2].getValeur() * Math.Pow(13, 0));
                valeur += (int)(Cartes[3].getValeur() * Math.Pow(13, 1));
                valeur += (int)(Cartes[0].getValeur() * Math.Pow(13, 2));
                return valeur + DOUBLE_PAIRE;
            }
            if (Cartes[1].getValeur() == Cartes[2].getValeur()
             && Cartes[3].getValeur() == Cartes[4].getValeur())
            {
                valeur += (int)(Cartes[0].getValeur() * Math.Pow(13, 0));
                valeur += (int)(Cartes[3].getValeur() * Math.Pow(13, 1));
                valeur += (int)(Cartes[1].getValeur() * Math.Pow(13, 2));
                return valeur + DOUBLE_PAIRE;

            }
            if (Cartes[0].getValeur() == Cartes[1].getValeur()
             && Cartes[2].getValeur() == Cartes[3].getValeur())
            {
                valeur += (int)(Cartes[4].getValeur() * Math.Pow(13, 0));
                valeur += (int)(Cartes[3].getValeur() * Math.Pow(13, 1));
                valeur += (int)(Cartes[0].getValeur() * Math.Pow(13, 2));
                return valeur + DOUBLE_PAIRE;

            }
            return valeur + DOUBLE_PAIRE;
        }
        private int encodePaire()
        {
            int valeur = 0;
            if (Cartes[0].getValeur() == Cartes[1].getValeur())
            {
                valeur += (int)(Cartes[4].getValeur() * Math.Pow(13, 0));
                valeur += (int)(Cartes[3].getValeur() * Math.Pow(13, 1));
                valeur += (int)(Cartes[2].getValeur() * Math.Pow(13, 2));
                valeur += (int)(Cartes[1].getValeur() * Math.Pow(13, 3));

                return valeur + PAIRE;
            }
            if (Cartes[1].getValeur() == Cartes[2].getValeur())
            {
                valeur += (int)(Cartes[4].getValeur() * Math.Pow(13, 0));
                valeur += (int)(Cartes[3].getValeur() * Math.Pow(13, 1));
                valeur += (int)(Cartes[2].getValeur() * Math.Pow(13, 3));
                valeur += (int)(Cartes[0].getValeur() * Math.Pow(13, 2));

                return valeur + PAIRE;

            }
            if (Cartes[2].getValeur() == Cartes[3].getValeur())
            {
                valeur += (int)(Cartes[4].getValeur() * Math.Pow(13, 0));
                valeur += (int)(Cartes[3].getValeur() * Math.Pow(13, 3));
                valeur += (int)(Cartes[1].getValeur() * Math.Pow(13, 1));
                valeur += (int)(Cartes[0].getValeur() * Math.Pow(13, 2));

                return valeur + PAIRE;

            }
            if (Cartes[3].getValeur() == Cartes[4].getValeur())
            {
                valeur += (int)(Cartes[4].getValeur() * Math.Pow(13, 3));
                valeur += (int)(Cartes[2].getValeur() * Math.Pow(13, 0));
                valeur += (int)(Cartes[1].getValeur() * Math.Pow(13, 1));
                valeur += (int)(Cartes[0].getValeur() * Math.Pow(13, 2));

                return valeur + PAIRE;

            }
            return valeur + PAIRE;
        }

        private int encodeCarteHaute()
        {
            int valeur = 0;
            valeur = +(int)(Cartes[0].getValeur() * Math.Pow(13, 0));
            return valeur + CARTE_HAUTE;
        }
        // ConvertitValeurEnFrancais 

        /*(int) :string À partir d’une valeur en paramètre retourne son équivalent en Français */
        public string ConvertitValeurEnFrancais(int valeurDeLaMain)
        {
            string message  = "";
            if (valeurDeLaMain >= QUINTE_COULEUR)
            {
                message = "Quinte couleur avec " + Convert.ToString(ConvertitNombreEnMot(valeurDeLaMain - QUINTE_COULEUR ));
                return message;
            }

            if (valeurDeLaMain >= CARREE)
            {
                valeurDeLaMain = valeurDeLaMain - CARREE;
                int valeurCarree =+ (int)(valeurDeLaMain / Math.Pow(13, 1));
                message = "Carree au " + ConvertitNombreEnMot(valeurCarree) + " avec " + ConvertitNombreEnMot(valeurDeLaMain - valeurCarree*13);
                return message;

            }
            if (valeurDeLaMain >= FULL)
            {
                valeurDeLaMain = valeurDeLaMain - FULL;
                int valeurBrelan =+(int)(valeurDeLaMain / Math.Pow(13, 1));
                int valeurPair =+ valeurDeLaMain - (valeurBrelan * 13);
                message = "Full avec brelan de " + ConvertitNombreEnMot(valeurBrelan) + " et paire de " + ConvertitNombreEnMot(valeurPair);
                return message;
            }
            if (valeurDeLaMain >= COULEUR)
            {
                valeurDeLaMain = valeurDeLaMain - COULEUR;
                int premiere = +(int)(valeurDeLaMain / Math.Pow(13, 4));
                int deuxieme = +(int)((valeurDeLaMain - (premiere * Math.Pow(13, 4))) / Math.Pow(13, 3));
                int troisieme = +(int)((valeurDeLaMain - (premiere * Math.Pow(13, 4)) - (deuxieme * Math.Pow(13, 3))) / Math.Pow(13, 2));
                int quatrieme = +(int)((valeurDeLaMain - (premiere * Math.Pow(13, 4)) - (deuxieme * Math.Pow(13, 3)) - (troisieme * Math.Pow(13, 2))) / Math.Pow(13, 1));
                int cinquieme = +(int)((valeurDeLaMain - (premiere * Math.Pow(13, 4)) - (deuxieme * Math.Pow(13, 3)) - (troisieme * Math.Pow(13, 2))) - (quatrieme * Math.Pow(13, 1)));
                message = "Couleur avec " + ConvertitNombreEnMot(premiere) + ", " 
                                          + ConvertitNombreEnMot(deuxieme) + ", "
                                          + ConvertitNombreEnMot(troisieme) + ", "
                                          + ConvertitNombreEnMot(quatrieme) + ", "
                                          + ConvertitNombreEnMot(cinquieme);
                return message;
            }
            if (valeurDeLaMain >= QUINTE)
            {
                valeurDeLaMain = valeurDeLaMain - QUINTE;
                int carteLaPlusHaute = (int)(valeurDeLaMain / Math.Pow(13, 0));
                message = "Quinte au " + ConvertitNombreEnMot(carteLaPlusHaute);
                return message;
            }
            if (valeurDeLaMain >= BRELAN)
            {
                valeurDeLaMain = valeurDeLaMain - BRELAN;
                int valeurBrelan = +(int)(valeurDeLaMain / Math.Pow(13, 2));
                int premiereCarteHaute =+ (int)(( valeurDeLaMain - (valeurBrelan * Math.Pow(13, 2))) / Math.Pow(13, 1));
                int deuxiemeCarteHaute =+ (int)(valeurDeLaMain - (valeurBrelan * Math.Pow(13, 2)) - (premiereCarteHaute * Math.Pow(13, 1)));
                message = "Brelan de " + ConvertitNombreEnMot(valeurBrelan) + " avec " + ConvertitNombreEnMot(premiereCarteHaute) + " et " + ConvertitNombreEnMot(deuxiemeCarteHaute);
                return message;
            }
            if (valeurDeLaMain >= DOUBLE_PAIRE)
            {
                valeurDeLaMain = valeurDeLaMain - DOUBLE_PAIRE;
                int paireHaute =+ (int)(valeurDeLaMain / Math.Pow(13,2));
                int paireBasse =+ (int)((valeurDeLaMain - (paireHaute * Math.Pow(13, 2))) / Math.Pow(13, 1));
                int derniereCarte =+    (int)(valeurDeLaMain - (paireHaute * Math.Pow(13, 2)) - (paireBasse * Math.Pow(13, 1)));

                message = "Double paire: paire de " + ConvertitNombreEnMot(paireHaute) + " et de " + ConvertitNombreEnMot(paireBasse) + " avec " + ConvertitNombreEnMot(derniereCarte);
                return message;
            }
            if (valeurDeLaMain >= PAIRE)
            {
                valeurDeLaMain = valeurDeLaMain - PAIRE;
                int paire =+ (int)(valeurDeLaMain / Math.Pow(13, 3));
                int carteHaute = +(int)((valeurDeLaMain - (paire * Math.Pow(13, 3))) / Math.Pow(13, 2));
                int carteMilieu =+(int)((valeurDeLaMain - (paire * Math.Pow(13, 3)) - (carteHaute * Math.Pow(13, 2))) / Math.Pow(13,1));
                int carteBasse = +(int)((valeurDeLaMain - (paire * Math.Pow(13, 3)) - (carteHaute * Math.Pow(13, 2)) - (carteMilieu * Math.Pow(13,1))) / Math.Pow(13,0));
                message = "Paire de " + ConvertitNombreEnMot(paire) + " avec " + ConvertitNombreEnMot(carteHaute) + ", " + ConvertitNombreEnMot(carteMilieu) + ", " + ConvertitNombreEnMot(carteBasse);
                return message;
            }
            if (valeurDeLaMain >= CARTE_HAUTE)
            {
                valeurDeLaMain = valeurDeLaMain - CARTE_HAUTE;
                message = "Carte haute au " + ConvertitNombreEnMot(valeurDeLaMain);
                return message;
            }
            return message;
            
        }

        public string ConvertitNombreEnMot(int nombre)
        {
            string mot = "";
            if (nombre == 12)
            {
                mot = "as";
                return mot;
            }
            if (nombre == 11)
            {
                mot = "roi";
                return mot;
            }
            if (nombre == 10)
            {
                mot = "reine";
                return mot;
            }
            if (nombre == 9)
            {
                mot = "valet";
                return mot;
            }
            if (nombre == 8)
            {
                mot = "dix";
                return mot;
            }
            if (nombre == 7)
            {
                mot = "neuf";
                return mot;
            }
            if (nombre == 6)
            {
                mot = "huit";
                return mot;
            }
            if (nombre == 5)
            {
                mot = "sept";
                return mot;
            }
            if (nombre == 4)
            {
                mot = "six";
                return mot;
            }
            if (nombre == 3)
            {
                mot = "cinq";
                return mot;
            }
            if (nombre == 2)
            {
                mot = "quatre";
                return mot;
            }
            if (nombre == 1)
            {
                mot = "trois";
                return mot;
            }
            if (nombre == 0)
            {
                mot = "deux";
                return mot;
            }
            return mot;
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
