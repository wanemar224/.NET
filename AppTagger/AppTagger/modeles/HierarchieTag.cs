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
            Tag res = null; //new Tag( "pas bon", new Tag[]{ } ) ;
            TrouveParNom(this.root, nom, out res);

            if (res == null )
                throw new Exception( "Tag non trouvé !" );
            return res;
        }
        private void TrouveParNom(Tag tag, string nom,  out Tag res)
        {
            res = null;
            Console.WriteLine( "pere $ " + tag.Nom + ", nom $ " + nom );
            if (tag.Nom.Equals( nom ))
            {
                Console.WriteLine( "RENTRER DANS IF" );
                res = tag;
                Console.WriteLine( res.Nom );
            }
              
            else
            {
                foreach (Tag fils in tag.Fils)
                {
                    TrouveParNom( fils, nom,  out res );
                    if (res != null)
                        break;
                }
            }
           
           

        }

        public Tag TrouveParId ( int id )
        {
            return TrouveParId( this.root,  id );
        }

        private Tag TrouveParId (Tag tag, int id )
        {
            if (tag.Id.Equals( id ))
                return tag;
            Tag res = new Tag();
            foreach (Tag fils in tag.Fils)
            {
                return TrouveParId( fils, id );
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
