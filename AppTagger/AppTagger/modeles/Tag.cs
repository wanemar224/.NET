using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppTagger
{
    public class Tag
    {
        private static int _idSuivant = 0;

        int _id;
        string _nom;
        List<Tag> _fils;

        public Tag (string nom, List<Tag> fils )
        {
            this.Id =idSuivant();
            this.Nom = nom;
            this.Fils = fils;
        }
        public Tag()
        {
            this.Id = idSuivant();
        }

        public object Clone ( )
        {
            return new Tag(this.Nom, this.Fils);
        }

        public virtual void Affiche ( string indent )
        {
            Console.WriteLine( "{0}{1} [", indent, this.Nom );
            for (int i = 0; i < this.Fils.Count; i++)
            {
                this.Fils [i].Affiche( indent + "    " );
            }
            Console.WriteLine( "{0}]", indent );
        }

        public void ajouterNouveauFils(Tag fils)
        {
            if (!this.Fils.Contains( fils ))
                this.Fils.Add( fils );
            //sinon levé une exception
        }

        private static int idSuivant()
        {
            _idSuivant++;
            return _idSuivant;
        }
        /////Propriété/////

        public int Id
        {
            get { return _id; }
            set { this._id = value; }
        }

        public string Nom
        {
            get { return _nom; }
            set { _nom = value; }
        }

        public List<Tag> Fils
        {
            get { return this._fils; }
            set {this._fils = value; }
        }
    }
}
