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
        //SINGLETON
        private HierarchieTag ( )
        {
            this.root = new Tag( "root", new Tag [] { } );
        }

        public static HierarchieTag Instance { get { return Nested.instance; } }

       
        private class Nested
        {
            static Nested ( ) { }
            internal static readonly HierarchieTag instance = new HierarchieTag();
        }
        
        public Tag TrouveParNom(string nom)
        {
            return Trouve<string>( nom, CompareNom );
        }

        public Tag TrouveParId ( int id )
        {
            return this.Trouve<int>( id, CompareID );
        }

        //DELEGATE
        delegate bool Compare<T> ( Tag tag, T element);
        bool CompareNom(Tag tag, string nom2 )
        {
            return tag.Nom.Equals( nom2 );
        }

        bool CompareID(Tag tag, int id)
        {
            return tag.Id == id;
        }
        //GENERC
        private Tag Trouve<T> (T element, Compare<T>comparer )
        {
            Tag res = null; 
            Trouve<T>( this.root, comparer, element, out res );

            if (res == null)
                throw new Exception( "Tag non trouvé !" );
            return res;
        }

        private void Trouve<T>( Tag tag, Compare<T> comparer, T element, out Tag res)
        {
            res = null;
            if (comparer(tag, element))
                res = tag;
            else
            {
                foreach (Tag fils in tag.Fils)
                {
                    Trouve<T>( fils, comparer, element, out res );
                    if (res != null)
                        break;
                }
            }
        }

        public bool EstPresentDansFils ( string pere, string tagAVerifier )
        {
            Tag t = this.TrouveParNom( pere );
            Tag res = null;
            Trouve<string>( t, CompareNom, tagAVerifier, out res );
            if (res == null)
                return false;
            return true;
        }

        public void AjouterTag(string pere, string fils)
        {
            Tag f = new Tag(fils, new Tag[] { });
            Tag p = this.TrouveParNom(pere);
            p.AjouterFils( f );
        }        

        public void SupprimerTag(string tag )
        {
            Tag pere = this.TrouvePere( tag );
            Console.WriteLine( "Pere :" + pere.Nom + "fils $ " + tag );
            int taille = pere.Fils.Length == 0 ? 0 : pere.Fils.Length - 1;

            Tag [] nouveauFils = new Tag [taille];
            int i = 0;
            foreach (Tag fils in pere.Fils)
            {
                if (!fils.Nom.Equals( tag ))
                {
                    nouveauFils [i] = fils;
                    Console.WriteLine( " fils $ " + nouveauFils [i].Nom );
                    i++; 
                }
            }
            pere.Fils = nouveauFils;
        }

        public void Charger ( )
        {
            try
            {
                Persistance p = new PersistanceJson();
                this.root = p.ChargerHierarchie();
                Tag.IdSuivaant = p.ChargerIdSuivant();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Sauvegarder ( )
        {
            Persistance p = new PersistanceJson();
            p.SauvergarderHierarchie( this.root );

            p.SauvegarderIdSuivant( Tag.IdSuivaant );
        }

        public Tag TrouvePere ( string fils )
        {
            Tag res = null;
            TrouvePere( this.root, fils, out res );

            if (res == null)
                throw new Exception( "Tag non trouvé !" );
            return res;
        }

        private void TrouvePere ( Tag tag, string f, out Tag res )
        {
            res = null;
            foreach (Tag fils in tag.Fils)
            {
                if (fils.Nom.Equals( f ))
                    res = tag;
                else
                {
                    TrouvePere( fils, f, out res );
                    if (res != null)
                        break;
                }
            }
        }
        //PROPRIETE
        Tag root;
        public Tag Hierarchi { get { return root; } set { root = (Tag)value.Clone(); } }
    }
}
