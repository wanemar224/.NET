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
using AppTagger.controller;
using AppTagger.modeles;

namespace AppTagger
{
    public partial class Form1 : Form
    {
        Controleur controleur;
        static int i = 0;
        public Form1 ( )
        {
            InitializeComponent();
            controleur = new Controleur();
            this.MiseAJourImageList();
            this.MiseAJourTagList();
            controleur.MiseAjourTreeView(this.treeView1);



        }

        private void ChargeeImages_Click ( object sender, EventArgs e )
        {
            using (OpenFileDialog ofd = new OpenFileDialog() { Filter = "All files |*.*", ValidateNames = true, Multiselect = true })
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    foreach (string f in ofd.FileNames)
                    {
                        Console.WriteLine( f );
                        AjoutePhoto( f );

                    }
                }
            }

        }
        private void AjoutePhoto(string chemin )
        {
            Console.WriteLine( chemin );
            controleur.AjoutePhoto( chemin );
            this.MiseAJourImageList();

        }

        private void MiseAJourImageList ( )
        {
            imageList1.Images.Clear();
            listView1.Items.Clear();
            Form1.i = 0;
            foreach(string chemin in controleur.ListPhoto)
            {
                imageList1.Images.Add( Path.GetFileName(chemin), Image.FromFile( chemin ) );
                ListViewItem item = new ListViewItem();
                item.Text = Path.GetFileName( chemin );
                item.ImageIndex = i++;
                listView1.Items.Add( item );       
            }
            controleur.Sauvegarder();
        }

        private void MiseAJourTagList ( )
        {
            checkedListBox1.Items.Clear();
            comboBox1.Items.Clear();
            List<string> tags = controleur.GetTagList();
            foreach(string tag in tags)
            {
                comboBox1.Items.Add( tag );
                checkedListBox1.Items.Add( tag );
            }
            controleur.Sauvegarder();
        }

        private void MiseAJourLabelTag(string nom )
        {
            string s = controleur.GetTagPhoto( nom );
            chaineTag.Text = "Tags : " + s;
        }

 


        private void listView1_SelectedIndexChanged ( object sender, EventArgs e )
        {
            int i = this.listView1.FocusedItem.Index;
            string chemin = this.controleur.TrouvePhotoParNom(this.listView1.Items [i].Text);
           // string chemin = this.imageList1.Images[i].
            this.pictureBox1.Image = Image.FromFile(chemin);
            string s = controleur.GetTagPhoto( Path.GetFileName(chemin ));
            chaineTag.Text = "Tags : " + s;

        }

        private void pictureBox1_Click ( object sender, EventArgs e )
        {
          
        }

        private void supprimer_Click ( object sender, EventArgs e )
        {
           foreach( ListViewItem item in this.listView1.SelectedItems)
           {
                this.SupprimerPhoto( item.Text );
           }
           //pictureBox1.
        }

        private void SupprimerPhoto(string nom ) 
        {
            controleur.SupprimerPhoto( nom );
            this.MiseAJourImageList();
        }

        private void comboBox1_SelectedIndexChanged ( object sender, EventArgs e )
        {
           
        }

        private void checkedListBox1_SelectedIndexChanged ( object sender, EventArgs e )
        {
            // parcour les tags selectionnés pour le filtre
            for( int i = 0; i<checkedListBox1.SelectedItems.Count; i++)
            {
                //parcour les itemes(photo) de la listView
                foreach(ListViewItem photo in listView1.Items)
                {
                    //parcours: chaque tag associé à photo, si il est égale à tag sélectionné ou il est fils de tag sélectionnée.
                    //if(!controleur.FiltreParTag( photo.Text ))
                       
                    
                }
            }
        }

        private void Form1_Load ( object sender, EventArgs e )
        {

        }

        private void AjouterTag_Click ( object sender, EventArgs e )
        {
            try
            {
                controleur.AjouterTagHierarchi( treeView1.SelectedNode.Text, TextAjouterTag.Text );
                controleur.MiseAjourTreeView( this.treeView1 );
                this.MiseAJourTagList();
            }
            catch (Exception ex)
            {
                MessageBox.Show( ex.Message );
            }
        }

        private void AjouterTagAImage_Click ( object sender, EventArgs e )
        {
            try
            {
                controleur.AjouterTagDansPhoto( this.listView1.Items [this.listView1.FocusedItem.Index].Text, comboBox1.SelectedItem.ToString() );
                int i = this.listView1.FocusedItem.Index;
                string chemin = this.controleur.TrouvePhotoParNom( this.listView1.Items [i].Text );
                this.MiseAJourLabelTag( Path.GetFileName( chemin ) );
            }
            catch(Exception ex)
            {
                MessageBox.Show( "Veuillez sélectionner un tag et une image s'il vous plaît !");
            }
            
           
        }

        private void SupprimerTagImage_Click ( object sender, EventArgs e )
        {
            try
            {
                controleur.SupprimerUnTagDansPhoto( this.listView1.Items [this.listView1.FocusedItem.Index].Text, comboBox1.SelectedItem.ToString() );
                int i = this.listView1.FocusedItem.Index;
                string chemin = this.controleur.TrouvePhotoParNom( this.listView1.Items [i].Text );
                this.MiseAJourLabelTag( Path.GetFileName( chemin ) );
            }
            catch(Exception ex)
            {
                MessageBox.Show( ex.Message );
            }
        }

        private void ModifierTag_Click ( object sender, EventArgs e )
        {
            try
            {
                controleur.ModifierTagDansHierarchi( treeView1.SelectedNode.Text, TextModifierTag.Text );
                controleur.MiseAjourTreeView( this.treeView1 );
                this.MiseAJourTagList();
            }
            catch (Exception ex)
            {
                MessageBox.Show( ex.Message );
            }
        }
    }
}
