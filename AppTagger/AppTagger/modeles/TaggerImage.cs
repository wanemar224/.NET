using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Imaging;
using System.Collections.Generic;

namespace AppTagger
{
    class TaggerImage
    {
        private  System.Text.ASCIIEncoding encoding;
        private Image _image;
        private PropertyItem item;
        private List<string> _tags;
       
        public TaggerImage(string path_image, List<string> tags)
        {
            this.tags = tags;
            image = new Bitmap( path_image );
            encoding = new System.Text.ASCIIEncoding();

            this.mettreAjourLesTags();
        }

        private void mettreAjourLesTags()
        {
            this.item = this.image.GetPropertyItem( Convert.ToInt32( 0x010E) );
            string les_tags = "";
            foreach (string tag in this.tags)
            {
                les_tags += tag+" > ";
            }
            var data = encoding.GetBytes( les_tags );
            this.item.Len = data.Length;
            this.item.Value = data;

            image.SetPropertyItem( this.item );
            image.Save( "H:\\treviv.jpg", ImageFormat.Jpeg );
        }

        public List<string> tags
        {
            get { return this._tags; }
            private set { this._tags = value; }
        }

        public Image image
        {
            get { return this._image; }
            set { this._image = value; }
        }
        public void AjouterUnTag(string tag)
        {
            this.tags.Add( tag );
            this.mettreAjourLesTags();
        }

        public bool supprimerTag(string tag)
        {
            if (this.tags.Remove( tag ))
            {
                this.mettreAjourLesTags();
                return true;
            }
            else
                return false;
            
        }

        public void supprimerTousLesTags()
        {
            this.tags.Clear();
            this.mettreAjourLesTags();
        }

        public void modifierUnTag(string ancienTag, string nouveauTag)
        {
            int index = this.tags.FindIndex( item => item.Equals(ancienTag) );
            if (index != -1)
            {
                this.tags [index] = nouveauTag;
            }
            this.mettreAjourLesTags();
        }
        public void modifierTousLesTags(List<string> nouveauxTags)
        {
            this.tags = nouveauxTags;
            this.mettreAjourLesTags();
        }
        public string toString()
        {
            return "L'id : 0x0" + item.Id.ToString( "x" ) + "\n" + "La description de cette image est : " + encoding.GetString( item.Value ) + "\n" + "Taille de l'ensemble des tags :" + item.Len;
        }
    }
}
