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

        public Carte[] Cartes = new Carte[5];

        public Evaluateur (Carte[] cartes)
        {
            Cartes = cartes;
        }

    }
}
