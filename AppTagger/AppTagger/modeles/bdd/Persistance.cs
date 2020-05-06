using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppTagger.modeles.bdd
{
    interface Persistance
    {
        Tag chargerHierarchie ( );
        void sauvergarderHierarchie ( );

        Galerie chargerGalerie ( );
        void sauvegarderGalerie ( );
    }
}
