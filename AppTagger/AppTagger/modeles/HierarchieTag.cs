using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace AppTagger.modeles
{
    public sealed class HierarchieTag 
    {
        Tag root;
        private HierarchieTag() { }
        public static HierarchieTag Instance { get { return Nested.instance; } }

        public Tag Hierarchi { get { return root; } set { root = (Tag)value.Clone(); } }
        private class Nested
        {
            static Nested() { }
            internal static readonly HierarchieTag instance = new HierarchieTag();
        }

        public void chargerTag(string path)
        {
            string contenu = File.ReadAllText(path);
            this.root = JsonConvert.DeserializeObject<Tag>(contenu);
        }

        public void sauvegarderTag(string path)
        {
            File.WriteAllText(path, JsonConvert.SerializeObject(this.root, Formatting.Indented));
        }
        public Tag trouveParNom(string nom)
        {
            return trouveParNom(this.root, nom);
        }
        private Tag trouveParNom(Tag tag, string nom)
        {
            if (tag.Nom.Equals(nom))
                return tag;
            if (tag.Fils.Count == 0)
                return null;
            Tag res = new Tag();
            foreach (Tag fils in tag.Fils)
            {
                res = trouveParNom(fils, nom);
                if (res != null) return fils;
            }
            
            return res;
                
        }

        private Tag trouve( Tag tag, Predicate<Tag> trouve)
        {
            return null;
        }

        public void ajouterTag(Tag pere, Tag fils)
        {
            Tag p = this.trouveParNom( pere.Nom );
            if (p != null)
                p.ajouterNouveauFils( fils );

        }

    }
}
