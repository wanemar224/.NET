﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppTagger
{
    public class Tag
    {
        int _id;
        string _nom;
        Tag [] _fils;

        public Tag ( int id, string nom, Tag [] fils )
        {
            this.Id = id;
            this.Nom = nom;
            this.Fils = fils;
        }

        public Tag()
        {
            this.Id = -1;
        }

        public object Clone ( )
        {
            return new Tag( this.Id, this.Nom, (Tag [])this.Fils.Clone() );
        }

        public virtual void Affiche ( string indent )
        {
            Console.WriteLine( "{0}{1} [", indent, this.Nom );
            for (int i = 0; i < this.Fils.Length; i++)
            {
                this.Fils [i].Affiche( indent + "    " );
            }
            Console.WriteLine( "{0}]", indent );
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
