using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppTagger.modeles.persistance
{
    class PersistanceJson : Persistance
    {
        const string CHEMINHIERARCHIE = @"..\..\bdd\tags.json";
        const string CHEMINPHOTOS = @"..\..\bdd\photos.json";
        const string CHEMINIDSUIVANT = @"..\..\bdd\id_suivant.json";
        public List<string> ChargerGalerie()
        {
            if(!File.Exists(CHEMINPHOTOS))
                this.SauvegarderGalerie( new List<string>( ));

            string contenu = File.ReadAllText( CHEMINPHOTOS );
            return JsonConvert.DeserializeObject<List<string>>( contenu );

        }

        public Tag ChargerHierarchie()
        {
            if (!File.Exists( CHEMINHIERARCHIE ))
            {
                this.SauvergarderHierarchie( HierarchieTag.Instance.Hierarchi );
            }
            string contenu = File.ReadAllText( CHEMINHIERARCHIE );
            if (contenu.Length == 0)
                throw new Exception( "fichier vide" );
            return JsonConvert.DeserializeObject<Tag>( contenu );
            //throw new FileNotFoundException();
        }

        public int ChargerIdSuivant ( )
        {
            if (!File.Exists( CHEMINIDSUIVANT ))
                this.SauvegarderIdSuivant( Tag.IdSuivaant );

            string contenu = File.ReadAllText( CHEMINIDSUIVANT);
            return JsonConvert.DeserializeObject<int>( contenu );
        }

        public void SauvegarderIdSuivant(int idSuivant)
        {
            File.WriteAllText( CHEMINIDSUIVANT, JsonConvert.SerializeObject( idSuivant, Formatting.Indented ) );
        }
        public void SauvegarderGalerie(List<string> cheminsPhoto)
        {
            File.WriteAllText(CHEMINPHOTOS, JsonConvert.SerializeObject(cheminsPhoto, Formatting.Indented));
        }

        public void SauvergarderHierarchie(Tag root)
        {
            File.WriteAllText(CHEMINHIERARCHIE, JsonConvert.SerializeObject(root, Formatting.Indented));
        }
    }
}
