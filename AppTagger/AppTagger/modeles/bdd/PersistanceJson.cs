using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;

namespace AppTagger.modeles.bdd
{
    class PersistanceJson : Persistance
    {
        const string CHEMINHIERARCHIE = @"H:\\C#\AppTagger\AppTagger\bdd\hierarchie.json";
        const string CHEMINPHOTOS     = @"H:\\C#\AppTagger\AppTagger\bdd\photos.json";
        public Galerie chargerGalerie ( )
        {
            string contenu = File.ReadAllText( CHEMINPHOTOS );
            return JsonConvert.DeserializeObject<Galerie>( contenu );  
        }

        public Tag chargerHierarchie ( )
        {
            string contenu = File.ReadAllText(CHEMINHIERARCHIE);

            return  JsonConvert.DeserializeObject<Tag>( contenu );
        }

        public void sauvegarderGalerie ( )
        {
            File.WriteAllText( CHEMINPHOTOS, JsonConvert.SerializeObject( Galerie.Instance, Formatting.Indented ) );
        }

        public void sauvergarderHierarchie ( )
        {
            File.WriteAllText( CHEMINHIERARCHIE, JsonConvert.SerializeObject( HierarchieTag.Instance, Formatting.Indented ) );
        }
    }
}
