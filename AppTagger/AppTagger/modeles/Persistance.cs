using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;
using System.Drawing;
using System.Drawing.Imaging;
using System.Text.RegularExpressions;

namespace AppTagger.modeles
{
    static class Persistance
    {
        public static Tag chargerTag(string path)
        {
            string contenu = File.ReadAllText( path );
            return JsonConvert.DeserializeObject<Tag>( contenu );
        }

        public static void sauvegarderTag(Tag root, string path)
        {
           File.WriteAllText( path, JsonConvert.SerializeObject( root, Formatting.Indented));
        }

        public static void sauvegarderPhoto(Photo photo, string path)
        {
            System.Text.ASCIIEncoding encoding;
            

            Image image = new Bitmap( photo.Chemin );
            PropertyItem item = image.PropertyItems[0];
            item.Id = 0x9286;

            encoding = new System.Text.ASCIIEncoding();

            //item = image.GetPropertyItem( Convert.ToInt32(0x010E) );
            string ids = "";
            foreach (int tag in photo.Tags)
            {
                ids += tag + ",";
            }
            var data = encoding.GetBytes(ids);
          

            item.Len = data.Length;
            item.Value.DefaultIfEmpty();
            item.Value = data;
            item.Type = 2;
            image.SetPropertyItem(item );
            string cheminASupprimer = photo.Chemin;
            photo.Nom = "c_" + photo.Nom;
            image.Save(photo.Chemin, ImageFormat.Jpeg );

            //Image imageUL = Image.FromFile( photo.Chemin );
            //string valeur = imageUL.GetPropertyItem( Convert.ToInt32( 0x9286 ) ).Value.ToString();
            //Console.WriteLine( "on a réussi halla " + valeur );
            image.Dispose();
            File.Delete( cheminASupprimer );


            File.AppendAllText(path, JsonConvert.SerializeObject( photo.Chemin, Formatting.Indented));
        }

        public static void chargerPhoto(string cheminAbsolu, string nom)
        {
            Image image = new Bitmap( cheminAbsolu + nom );
            PropertyItem item; // = image.PropertyItems [0];
            //item.Id = 0x9286;

            item = image.GetPropertyItem( Convert.ToInt32( 0x9286 ) );
            string description = System.Text.Encoding.UTF8.GetString(item.Value, 0, item.Value.Length);
            List<int> idTags = new List<int>();
            idTags = recupererIdTag(description);
            Photo photo = new Photo( cheminAbsolu, nom );
        }

        private static List<int> recupererIdTag( string description)
        {
            string [] tags = description.Split( ',');
            List<int> res = new List<int>();
            for (int i = 0; i < tags.Length - 1; i++) 
            {
                StringBuilder s = new StringBuilder();

                foreach (char c in tags[i])
                {
                    if (Regex.IsMatch( c.ToString(), "[0-9]" ))
                        s.Append( c.ToString() );
                }
                res.Add(Convert.ToInt32( s.ToString()));               
            }
            return res;
        }

    }
}
