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
        //CONSTRUCTEUR
        public Controleur ( ) 
        { 
            Galerie.Instance.Charger();
            HierarchieTag.Instance.Charger();
        }

        //METHODES
        public void AjoutePhoto ( string chemin ) { Galerie.Instance.AjouterPhoto( Path.GetDirectoryName( chemin ), Path.GetFileName( chemin ) ); }
        public void AjouterTagHierarchi ( string pere, string fils )
        {
            Tag t = HierarchieTag.Instance.TrouveParNom( pere );
            t.AjouterFils( new Tag( fils, new Tag [] { } ) );
            HierarchieTag.Instance.Sauvegarder();
        }
        public void AjouterTagDansPhoto ( string nomPhoto, string tag )
        {
            Galerie.Instance.TrouverPhoto( nomPhoto ).AjouterUnTag( HierarchieTag.Instance.TrouveParNom( tag ) );
        }


        public void ModifierTagDansHierarchi ( string tag, string nouveauNom )
        {
            HierarchieTag.Instance.TrouveParNom( tag ).Nom = nouveauNom;
        }

        public void SupprimerUnTagDansPhoto ( string nomPhoto, string tag )
        {
            Galerie.Instance.TrouverPhoto( nomPhoto ).SupprimerUnTag( HierarchieTag.Instance.TrouveParNom( tag ) );
        }
        public void SupprimerPhoto ( string nom )
        {
            Galerie.Instance.SupprimerPhoto( Galerie.Instance.TrouverPhoto( nom ) );
        }

        public void SupprimerTag ( string tag )
        {
            HierarchieTag.Instance.SupprimerTag( tag );
            Galerie.Instance.MiseAjourTag();
        }

        public string TrouvePhotoParNom (string nom ) { return Galerie.Instance.TrouverPhoto( nom ).Chemin; }

        public List<string> ListPhotoFiltre(CheckedListBox checkedList)
        {
            List<string> lpf = new List<string>();
            foreach (Photo photo in Galerie.Instance.Photos)
            {
                for (int i = 0; i < checkedList.CheckedItems.Count; i++)
                    foreach(string tag in GetTagPhoto(photo.Nom))
                        if (EstPresent( checkedList.CheckedItems [i].ToString(), Path.GetFileName( tag ) ))
                            if(!lpf.Contains(photo.Chemin))
                                lpf.Add( photo.Chemin );              
            }
            return lpf;
        }

        internal bool EstPresent ( string tag, string tagAVerifier )
        {
            if (tag.Equals( tagAVerifier ))
                return true;
            return HierarchieTag.Instance.EstPresentDansFils( tag, tagAVerifier );
        }

        public List<string> GetTagList ( )
        {
            Tag t = HierarchieTag.Instance.Hierarchi;
            List<string> listeTags = new List<string>();
            foreach(Tag tag in t.Fils)
                ConstruireList( listeTags, tag );

            return listeTags;
        }

        public List<string> GetTagPhoto(string nom )
        {
            List<string>  s = new List<string>();
            List<int> tags = Galerie.Instance.TrouverPhoto( nom ).Tags;
            foreach(int tag in tags)
            {
                s.Add( HierarchieTag.Instance.TrouveParId( tag ).Nom );
            }

            return s;
        }

        private void ConstruireList(List<string> liste , Tag t )
        {
            liste.Add( t.Nom );
            foreach(Tag tag in t.Fils)
                ConstruireList( liste, tag );
            
        }


        public void MiseAjourTreeView ( TreeView treeView1 )
        {
            treeView1.Nodes.Clear();
            treeView1.Nodes.Add( "root" );
            this.MiseAjourTreeView( HierarchieTag.Instance.Hierarchi, treeView1.Nodes [0].Nodes );
        }

        private void MiseAjourTreeView ( Tag hierarchi, TreeNodeCollection nodes )
        {
            for (int i = 0; i < hierarchi.Fils.Length; i++)
            {
                nodes.Add( hierarchi.Fils [i].Nom );
                MiseAjourTreeView( hierarchi.Fils [i], nodes [i].Nodes );
            }
        }

        public void Sauvegarder ( )
        {
            HierarchieTag.Instance.Sauvegarder();
            Galerie.Instance.Sauvegarder();
        }

        //PROPRIETE
        public List<string> ListPhoto
        {
            get
            {
                List<string> lp = new List<string>();
                foreach (Photo photo in Galerie.Instance.Photos)
                    lp.Add( photo.Chemin );

                return lp;
            }
        }
    }
}
