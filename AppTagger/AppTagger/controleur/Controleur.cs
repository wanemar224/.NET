using AppTagger.modeles;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppTagger.controller
{
    class Controleur
    {
        public Controleur ( ) 
        {
            
            Galerie.Instance.Charger();
            HierarchieTag.Instance.Charger();

        }

        public string TrouvePhotoParNom (string nom )
        {
            return Galerie.Instance.TrouverPhoto( nom ).Chemin;
        }

        public void AjoutePhoto(string chemin )
        {

            Galerie.Instance.AjouterPhoto( Path.GetDirectoryName(chemin), Path.GetFileName(chemin));
        }

        public void MiseAjourTreeView ( TreeView treeView1 )
        {
            treeView1.Nodes.Clear();
            treeView1.Nodes.Add( "root" );
            this.MiseAjourTreeView(HierarchieTag.Instance.Hierarchi, treeView1.Nodes[0].Nodes);
        }

        private void MiseAjourTreeView ( Tag hierarchi, TreeNodeCollection nodes )
        {
           

            //if (hierarchi.Fils.Length == 0)
            //{
              //  nodes.Add( hierarchi.Nom );
            //}
            //else
            //{
                for (int i = 0; i < hierarchi.Fils.Length; i++)
                {
                    nodes.Add( hierarchi.Fils[i].Nom );
                    MiseAjourTreeView( hierarchi.Fils [i], nodes [i].Nodes );
                }
            //}
        }

        public void AjouterTagHierarchi ( string pere, string fils)
        {
            Console.WriteLine( pere + " " + fils );
            Tag t = HierarchieTag.Instance.TrouveParNom( pere );  
            t.AjouterFils( new Tag( fils, new Tag [] { } ) );
            HierarchieTag.Instance.Sauvegarder();
            
        }

        public void SupprimerPhoto(string nom)
        {
            Galerie.Instance.SupprimerPhoto( Galerie.Instance.TrouverPhoto( nom ) );
        }
        public List<string> ListPhoto
        {
            get
            {
                List<string> lp = new List<string>();
                foreach (Photo photo in Galerie.Instance.Photos)
                {
                    lp.Add(photo.Chemin);
                }
                return lp;
            }
        }

        public List<string> GetTagList ( )
        {
            Tag t = HierarchieTag.Instance.Hierarchi;
            List<string> listeTags = new List<string>();
            foreach(Tag tag in t.Fils)
                ConstruireList( listeTags, tag );

            return listeTags;
        }

        public string GetTagPhoto(string chemin )
        {
            StringBuilder s = new StringBuilder();
            List<int> tags = Galerie.Instance.TrouverPhoto( Path.GetFileName( chemin ) ).Tags;
            foreach(int tag in tags)
            {
                s.Append( HierarchieTag.Instance.TrouveParId( tag ).Nom );
                s.Append( ", " );
            }

            return s.ToString();
        }
        private void ConstruireList(List<string> liste , Tag t )
        {
            liste.Add( t.Nom );
            foreach(Tag tag in t.Fils)
            {
                ConstruireList( liste, tag );
            }
        }
    }
}
