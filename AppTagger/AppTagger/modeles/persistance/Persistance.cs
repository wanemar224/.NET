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

        List<Photo> ChargerGalerie();
        void SauvegarderGalerie();
    }
}
