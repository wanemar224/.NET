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
             this.Photos.Add(photo);
        }
        public void AjouterPhoto(string cheminAbsolu, string nom)
        {
            this.AjouterPhoto( new Photo( cheminAbsolu, nom ) );
           
        }
        public void SupprimerPhoto(Photo photo)
        {
            if (!this.Photos.Remove(photo))
                throw new ArgumentException("Photo introuvable !");
        }

        public void Sauvegarder()
        {
            Persistance persist = new PersistanceJson();
            List<string> cheminsPhoto = new List<string>();

            foreach(Photo p in this.Photos)
            {
                cheminsPhoto.Add(p.Chemin);
            }
            persist.SauvegarderGalerie(cheminsPhoto);
            this.EnregistrerTagDansFichiers();
        }

        public void Charger()
        {
            //try
           // {
                Persistance p = new PersistanceJson();
                foreach (string chemin in p.ChargerGalerie())
                {
                    Photo photo = new Photo( chemin );
                    photo.RecupererTagDepuisFichier();
                    this.AjouterPhoto( photo );
                }
            //}
            //catch(Exception ex)
            //{
            //    throw ex;
            //}
            
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
