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
using System.IO;

namespace AppTagger
{
    public partial class Form1 : Form
    {
        static int i = 0;
        public Form1 ( )
        {
            InitializeComponent();
        }

        private void ChargeeImages_Click ( object sender, EventArgs e )
        {
            using (OpenFileDialog ofd = new OpenFileDialog() { Filter = "All files |*.*", ValidateNames = true, Multiselect = true })
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    foreach (string f in ofd.FileNames)
                    {

                        imageList1.Images.Add( Image.FromFile( f ) );
                        ListViewItem item = new ListViewItem();
                        item.Text = Path.GetFileName( f );
                        item.ImageIndex = i++;
                        listView1.Items.Add( item );



                    }
                }
            }

        }

     
        private void listView1_SelectedIndexChanged ( object sender, EventArgs e )
        {
            int i = this.listView1.FocusedItem.Index;

            this.pictureBox1.Image = this.imageList1.Images [i];
        }

        private void pictureBox1_Click ( object sender, EventArgs e )
        {
            Console.WriteLine( this.pictureBox1.Image.Width + "x" + this.pictureBox1.Image.Height );
       

        }
    }
}
