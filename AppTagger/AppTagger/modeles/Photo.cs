using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppTagger.modeles
{
    class Photo
    {
        private string _cheminAbsolu;
        private string _nom;
        private List<Tag> _tags;

        public Photo(string cheminAbsolu, string nom,  List<Tag> tags)
        {
            this._cheminAbsolu = cheminAbsolu;
            this._tags = tags;
            this.Nom = nom;
        }

        public Photo(string cheminAbsolu, string nom)
        {
            this._cheminAbsolu = cheminAbsolu;
            this._tags = new List<Tag>();
            this.Nom = nom;
        }

        public List<Tag> Tags
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

        public void AjouterUnTag ( Tag tag )
        {
            if (!this.Tags.Contains( tag ))
                this.Tags.Add( tag );
        }

        public void supprimerUnTag(Tag tag)
        {
            if (this.Tags.Contains( tag ))
                this.Tags.Remove( tag );
        }
        public void toString()
        {
            Console.WriteLine( "chemin de la photo :" + this.CheminAbsolu + this.Nom);
            Console.Write( "tags : " );
            foreach(Tag tag in this.Tags)
            {
                Console.Write( tag.Nom + "," );
            }
            Console.Write("\n");
        }

    }
}
