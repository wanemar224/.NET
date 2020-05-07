using AppTagger.modeles.persistance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppTagger.modeles
{
    public class Galerie
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
            static Nested() { }
            internal static Galerie instance = new Galerie();
        }

        public Photo TrouverPhoto(string nom)
        {
            foreach (Photo photo in this.Photos)
            {
                if (photo.Nom.Equals(nom))
                {
                    return photo;
                }
            }
            return null;
        }
        public void AjouterPhoto(Photo photo)
        {
            if (!Photos.Contains(photo))
                this.Photos.Add(photo);
            else
                throw new ArgumentException("Cette photo existe déjà !");
        }
        public void AjouterPhoto(string cheminAbsolu, string nom)
        {
            this.AjouterPhoto(new Photo(cheminAbsolu, nom));
        }
        public void SupprimerPhoto(Photo photo)
        {
            if (!this.Photos.Remove(photo))
                throw new ArgumentException("Photo introuvable !");
        }

        public void Sauvegarder()
        {
            Persistance p = new PersistanceJson();
            p.SauvegarderGalerie();
        }

        public void Charger()
        {
            Persistance p = new PersistanceJson();
            this.Photos = p.ChargerGalerie();
        }

        public void EnregistrerTagDansFichiers ( )
        {
            foreach(Photo p in this.Photos)
            {
                p.EnregistrerTagDansFichier();
            }
        }
    }
}
