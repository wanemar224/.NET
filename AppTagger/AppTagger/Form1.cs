using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Imaging;

namespace AppTagger
{
    public partial class Form1 : Form
    {
        public Form1 ( )
        {
            InitializeComponent();
        }

        private void btn_print_Click ( object sender, EventArgs e )
        {

            List<string> tags= new List<string>();
            tags.Add( "Italie");
            tags.Add( "tag deux" );
            tags.Add( "tienssss" );

            TaggerImage treviTag = new TaggerImage( @"H:\\trevi.jpg", tags );

            treviTag.AjouterUnTag( "Amoureux" );
            //treviTag.supprimerTag( "Italie" );
            //treviTag.supprimerTousLesTags();

            treviTag.modifierUnTag( "Italie", "Rome" );
            MessageBox.Show( treviTag.toString() );

            try
            {
                System.Text.ASCIIEncoding encoding = new System.Text.ASCIIEncoding();
                // Create an Image object. 
                Image theImage = new Bitmap( "H:\\treviv.jpg" );

                // Get the PropertyItems property from image.
                PropertyItem [] propItems = theImage.PropertyItems;
                
                foreach (PropertyItem item in propItems)
                {
                    
                        Console.WriteLine( "L'id : 0x0" + item.Id.ToString( "x" ) );
                        Console.WriteLine( "Taille du tag :" + item.Len );
                        Console.WriteLine( "valeur du tag$ " + encoding.GetString( item.Value ) );
                }
            }
            catch (Exception)
            {
                MessageBox.Show( "There was an error." +
                    "Make sure the path to the image file is valid." );
            }
            /*
            // Create an Image object. 
            Image image = new Bitmap( @"H:\\trevi.jpg" );
            System.Text.ASCIIEncoding encoding = new System.Text.ASCIIEncoding();


            PropertyItem item = image.GetPropertyItem( Convert.ToInt32(0x010E)  );
            var data = encoding.GetBytes( "Mon tag => Vaccance" );

            item.Len = data.Length;
            item.Value = data;

            image.SetPropertyItem( item );

            
            string description = encoding.GetString( item.Value );
            MessageBox.Show( "L'id : 0x0" + item.Id.ToString( "x" ) + "\n" + "La description de cette image est : " + description +"\n"+ "Taille du tag :" + item.Len );*/
            //Console.WriteLine("L'id : 0x0"+item.Id.ToString("x"));
            //Console.WriteLine( "La description de cette image est : " + description );
            //Console.WriteLine( "Taille du tag :" + item.Len );
        }
    }
}
