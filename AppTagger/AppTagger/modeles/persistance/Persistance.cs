using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppTagger.modeles.persistance
{
    interface Persistance
    {
        Tag ChargerHierarchie();
        void SauvergarderHierarchie(Tag root);

        List<string> ChargerGalerie();
        void SauvegarderGalerie(List<string> cheminsPhoto) ;

        int ChargerIdSuivant ( );
        void SauvegarderIdSuivant ( int idSuivant );
    }
}
