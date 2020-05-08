using AppTagger.modeles.persistance;
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
        private HierarchieTag() 
        { 
            this.root = new Tag("root", new Tag [] { } );
        }

        public static HierarchieTag Instance { get { return Nested.instance; } }

        public Tag Hierarchi { get { return root; } set { root = (Tag)value.Clone(); } }
        private class Nested
        {
            static Nested() { }
            internal static readonly HierarchieTag instance = new HierarchieTag();
        }

        public void Charger()
        {
            try
            {
                Persistance p = new PersistanceJson();
                this.root = p.ChargerHierarchie();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }

        public void Sauvegarder()
        {
            Persistance p = new PersistanceJson();
            p.SauvergarderHierarchie(this.root);
        }
        public Tag TrouveParNom(string nom)
        {
            return TrouveParNom(this.root, nom);
        }
        private Tag TrouveParNom(Tag tag, string nom)
        {
            if (tag.Nom.Equals(nom))
                return tag;
            Tag res = new Tag();
            foreach (Tag fils in tag.Fils)
            {
                return TrouveParNom(fils, nom);
            }
            throw new Exception( "Tag non trouvé !" );

        }

        private Tag Trouve( Tag tag, Predicate<Tag> trouve)
        {
            return null;
        }

        public void AjouterTag(string pere, string fils)
        {
            Tag f = new Tag(fils, new Tag[] { });
            Tag p = this.TrouveParNom(pere);
            p.AjouterFils( f );
        }
    }
}
