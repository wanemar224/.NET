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
        Tag [] _fils;

        public Tag ( string nom, Tag [] fils )
        {
            this.Id = IdSuivant();
            this.Nom = nom;
            this.Fils = fils;
        }

        public Tag()
        {
            this.Id = IdSuivant();
        }

        public object Clone ( )
        {
            return new Tag( this.Nom, (Tag [])this.Fils.Clone() );
        }

        public virtual void Affiche ( string indent )
        {
            Console.WriteLine( "{0}{1} : {2} [", indent, this.Nom, this.Id);
            for (int i = 0; i < this.Fils.Length; i++)
            {
                this.Fils [i].Affiche( indent + "    " );
            }
            Console.WriteLine( "{0}]", indent );
        }

        private static int IdSuivant()
        {
            _idSuivant++;
            return _idSuivant;
        }

        public void AjouterFils( Tag fils)
        {
            if (!this.EstPresent( fils ))
            {
                Tag [] copy = new Tag [this.Fils.Length + 1];
                copy [this.Fils.Length] = fils;
                this.Fils.CopyTo( copy, 0 );
                this.Fils = copy;
            }
            else
                throw new Exception( "Ce tag existe déjà !" );
        }

        private bool EstPresent(Tag tag)
        {
            for(int i=0; i<this.Fils.Length; i++)
            {
                if (this.Fils [i].Nom.Equals( tag.Nom ))
                    return true;
            }
            return false;
        }
        /////Propriété/////

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public string Nom
        {
            get { return _nom; }
            set { _nom = value; }
        }

        public Tag [] Fils
        {
            get { return _fils; }
            set { _fils = (Tag [])value.Clone(); }
        }
    }
}
