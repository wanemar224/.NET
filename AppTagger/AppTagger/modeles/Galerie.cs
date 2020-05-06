using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppTagger.modeles
{
    public sealed class Galerie
    {
        List<Photo> _photos;
        private Galerie() 
        {
            this._photos = new List<Photo>();
        }
        public static Galerie Instance { get { return Nested.instance; } set { Nested.instance = value; } }

        public List<Photo> Photos { get { return _photos; } set { this._photos = value; } }
        private class Nested
        {
            static Nested ( ) { }
            internal static Galerie instance = new Galerie();
        }

        public Photo trouverUnePhoto(string nom)
        {
            foreach(Photo photo in this.Photos)
            {
                if(photo.Nom.Equals(nom))
                {
                    return photo;
                }
            }
            return null;
        }
        public void ajouterPhoto(Photo photo)
        {
            if (!Photos.Contains( photo ))
                this.Photos.Add( photo );
            else
                throw new ArgumentException( "Cette photo existe déjà !" );
        }
        public void ajouterPhoto(string cheminAbsolu, string nom)
        {
            this.ajouterPhoto( new Photo( cheminAbsolu, nom ) );
        }
        public void supprimerPhoto(Photo photo)
        {
            if (!this.Photos.Remove( photo ))
                throw new ArgumentException( "Photo introuvable" );
        }
    }
}
