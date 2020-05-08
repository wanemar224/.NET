using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

        public Photo(string cheminComplet)
        {
            this._tags = new List<int>();
            string[] chemin = cheminComplet.Split('\\');
            if (chemin.Length > 0)
            {
                string c = "";
                for (int i = 0; i < chemin.Length - 1; i++)
                {
                    c += chemin[i]+"\\";
                }
                this.CheminAbsolu = c;
                this.Nom = chemin[chemin.Length - 1];
            }



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

        private void EnregistrerMini()
        {
            Image image = new Bitmap( this.Chemin );
            Image mini = image.GetThumbnailImage( image.Width / 4, image.Height / 4, ( ) => { return true; }, IntPtr.Zero );
            mini.Save( this.CheminMini, ImageFormat.Jpeg );
            image.Dispose();
            mini.Dispose();
        }
        public List<int> Tags
        {
            get { return this._tags; }
            private set { this._tags = value; }
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

        public string CheminMini
        {
            get { return this.CheminAbsolu + "mini_" + this.Nom; }
        }

        public void AjouterUnTag ( Tag tag )
        {
            if (!this.Tags.Contains( tag.Id ))
                this.Tags.Add( tag.Id );
            else
                throw new Exception( "Tag existe déja !" );
        }

        public void SupprimerUnTag(Tag tag)
        {
            if (this.Tags.Contains( tag.Id ))
                this.Tags.Remove( tag.Id );
            else
                throw new Exception( "Tag n'existe pas !" );
        }

        public void RecupererTagDepuisFichier()
        {
            try
            {
                Image image = new Bitmap( this.CheminMini );
                PropertyItem item = image.PropertyItems [0];
                item.Id = 0x9286;

                string description = Encoding.UTF8.GetString( item.Value, 0, item.Value.Length );
                this.Tags = RecupererIdTag( description );
                image.Dispose();
            }
            catch(FileNotFoundException ex)
            {
                this.EnregistrerMini();
            }
           
        }

        private List<int> RecupererIdTag(string idTags)
        {
            string[] tags = idTags.Split(',');
            List<int> res = new List<int>();
            for (int i = 0; i < tags.Length - 1; i++)
            {
                StringBuilder s = new StringBuilder();

                foreach (char c in tags[i])
                {
                    if (Regex.IsMatch(c.ToString(), "[0-9]"))
                        s.Append(c.ToString());
                }
                res.Add(Convert.ToInt32(s.ToString()));
            }
            return res;
        }
        public void EnregistrerTagDansFichier()
        {
            ASCIIEncoding encoding;
            Image image = new Bitmap( this.Chemin );
            Image mini = image.GetThumbnailImage( image.Width / 4, image.Height / 4, ( ) => { return true; }, IntPtr.Zero );
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
            mini.SetPropertyItem( item );

            string cheminMini = this.CheminAbsolu + "mini_" + this.Nom;
            

            mini.Save( cheminMini, ImageFormat.Jpeg );
            image.Dispose();
            mini.Dispose();
        }

        public void toString()
        {
            Console.WriteLine( "chemin de la photo :" + this.CheminMini);
            Console.Write( "tags : " );
            foreach(int tag in this.Tags)
            {
                Console.Write( tag + "," );
            }
            Console.Write("\n");
        }

    }
}
