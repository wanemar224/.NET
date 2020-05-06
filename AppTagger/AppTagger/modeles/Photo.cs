using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppTagger.modeles
{
    public class Photo
    {
        private string _cheminAbsolu;
        private string _nom;
        private List<int> _tags;

        public Photo(string cheminAbsolu, string nom,  List<int> tags)
        {
            this._cheminAbsolu = cheminAbsolu;
            this._tags = tags;
            this.Nom = nom;
        }

        public Photo(string cheminAbsolu, string nom)
        {
            this._cheminAbsolu = cheminAbsolu;
            this._tags = new List<int>();
            this.Nom = nom;
        }

        public List<int> Tags
        {
            get { return this._tags; }
            //private set { this._tags = value; }
        }

        public string  CheminAbsolu
        {
            get { return this._cheminAbsolu; }
            set { this._cheminAbsolu = value; }
        }

        public string Nom
        {
            get;
            set;
        }

        public string Chemin
        {
            get { return this.CheminAbsolu + this.Nom; }
        }

        public void ajouterUnTag ( Tag tag )
        {
            if (!this.Tags.Contains( tag.Id ))
                this.Tags.Add( tag.Id );
        }
        public void ajouterUnTag(string nom)
        {
            HierarchieTag ht = HierarchieTag.Instance;
            Tag t = ht.trouveParNom( nom );

            if (t != null)
                this.ajouterUnTag( t );
        }

        public void ajouterNouveauTag ( string nom, Tag pere)
        {
            Tag nouveau = new Tag(nom, new List<Tag>() );
            HierarchieTag ht = HierarchieTag.Instance;
            ht.ajouterTag( pere, nouveau );

            this.ajouterUnTag( nouveau );
        }
        public void supprimerUnTag(Tag tag)
        {
            if (this.Tags.Contains( tag.Id ))
                this.Tags.Remove( tag.Id );
        }
        public void toString()
        {
            Console.WriteLine( "chemin de la photo :" + this.CheminAbsolu + this.Nom);
            Console.Write( "tags : " );
            foreach(int tag in this.Tags)
            {
                Console.Write( tag + "," );
            }
            Console.Write("\n");
        }

    }
}
