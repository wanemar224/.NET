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
        const string CHEMINHIERARCHIE = @"H:\.NET-master\AppTagger\AppTagger\bdd\tags.json";
        const string CHEMINPHOTOS = @"H:\.NET-master\AppTagger\AppTagger\bdd\photos.json";
        public List<Photo> ChargerGalerie()
        {
            string contenu = File.ReadAllText(CHEMINPHOTOS);
            return JsonConvert.DeserializeObject<List<Photo>>(contenu);
        }

        public Tag ChargerHierarchie()
        {
            string contenu = File.ReadAllText(CHEMINHIERARCHIE);
            return JsonConvert.DeserializeObject<Tag>(contenu);
        }

        public void SauvegarderGalerie()
        {
            File.WriteAllText(CHEMINPHOTOS, JsonConvert.SerializeObject(Galerie.Instance.Photos, Formatting.Indented));
        }

        public void SauvergarderHierarchie(Tag root)
        {
            File.WriteAllText(CHEMINPHOTOS, JsonConvert.SerializeObject(root, Formatting.Indented));
        }
    }
}
