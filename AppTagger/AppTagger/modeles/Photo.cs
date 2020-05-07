using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
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

        public Photo() 
        {
            this._tags = new List<int>();
        }
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
            get { return this.CheminAbsolu + "\\" + this.Nom; }
        }

        public void AjouterUnTag ( Tag tag )
        {
            if (!this.Tags.Contains( tag.Id ))
                this.Tags.Add( tag.Id );
            else
                throw new Exception( "Tag existe déja !" );
        }

        public void supprimerUnTag(Tag tag)
        {
            if (this.Tags.Contains( tag.Id ))
                this.Tags.Remove( tag.Id );
            else
                throw new Exception( "Tag n'existe pas !" );
        }

        public void EnregistrerTagDansFichier()
        {
            ASCIIEncoding encoding;


            Image image = new Bitmap( this.Chemin );
            PropertyItem item = image.PropertyItems [0];
            item.Id = 0x9286;

            encoding = new ASCIIEncoding();

            string ids = "";
            foreach (int tag in this.Tags)
            {
                ids += tag + ",";
            }
            var data = encoding.GetBytes( ids );


            item.Len = data.Length;
            item.Value.DefaultIfEmpty();
            item.Value = data;
            item.Type = 2;
            image.SetPropertyItem( item );

            this.Nom = "photoTagger_" + this.Nom;

            image.Save( this.Chemin, ImageFormat.Jpeg );
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
