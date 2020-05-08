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
        public List<string> ChargerGalerie()
        {
            string contenu = File.ReadAllText(CHEMINPHOTOS);
            return JsonConvert.DeserializeObject<List<string>>(contenu);
        }

        public Tag ChargerHierarchie()
        {
            string contenu = File.ReadAllText(CHEMINHIERARCHIE);
            return JsonConvert.DeserializeObject<Tag>(contenu);
        }

        public void SauvegarderGalerie(List<string> cheminsPhoto)
        {
            File.WriteAllText(CHEMINPHOTOS, JsonConvert.SerializeObject(cheminsPhoto, Formatting.Indented));
        }

        public void SauvergarderHierarchie(Tag root)
        {
            File.WriteAllText(CHEMINPHOTOS, JsonConvert.SerializeObject(root, Formatting.Indented));
        }
    }
}
