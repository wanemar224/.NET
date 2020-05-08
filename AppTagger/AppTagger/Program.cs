using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Imaging;
using Newtonsoft.Json;
using AppTagger.modeles;
using System.IO;


namespace AppTagger
{
    static class Program
    {

      
        /// <summary>
        /// Point d'entrée principal de l'application.
        /// </summary>
        [STAThread]
        static void Main ( )
        {

            Galerie g = Galerie.Instance;
            g.Charger();
            g.Photos[0].toString();
            
            //Photo p2 = new Photo(@"..\..\galerie", "panda.jpg");

            /*g.AjouterPhoto(p);
            g.AjouterPhoto(p2);

            g.Photos [0].AjouterUnTag( new Tag( "julie", new Tag [] { } ) );
            g.Photos[0].EnregistrerTagDansFichier();
            g.Sauvegarder();*:

            




            /*Tag julie = new Tag("julie", new Tag [] { } );
            Tag pascal = new Tag( "pascal", new Tag [] { } );
            Tag famille = new Tag( "famille", new Tag [] { julie, pascal } );

            Tag dunkerque = new Tag( "dunkerque", new Tag [] { } );
            Tag vacances = new Tag( "vacances", new Tag [] { dunkerque } );


            Tag chien = new Tag( "chien", new Tag [] { } );

            Tag root = new Tag( "root", new Tag [] { famille, vacances, chien } );

            Photo p = new Photo(@"H:\\.NET-master\AppTagger\AppTagger\galerie", "lune.jpg");
            p.toString();
            p.AjouterUnTag( vacances );
            p.AjouterUnTag( famille);
            p.AjouterUnTag(pascal);
            p.toString();

            HierarchieTag ht = HierarchieTag.Instance;
            //ht.Hierarchi = root;
            ht.Charger();
            
            Galerie g = Galerie.Instance;
            g.AjouterPhoto(p);
            g.Sauvegarder();
            g.Charger();
            foreach(Photo photo in g.Photos)
            {
                photo.toString();
            }*/


            //Persistance.sauvegarderTag(root, @"C:\Users\sami-_000\Documents\workspace-visual\.NET\AppTagger\AppTagger\bdd\tags.json");
            //ht.sauvegarderTag(@"C:\Users\sami-_000\Documents\workspace-visual\.NET\AppTagger\AppTagger\bdd\tags.json");
            //ht.chargerTag(@"C:\Users\sami-_000\Documents\workspace-visual\.NET\AppTagger\AppTagger\bdd\tags.json");
            //ht.chargerTag(@"C:\Users\sami-_000\Documents\workspace-visual\.NET\AppTagger\AppTagger\bdd\tags.json");
            //ht.Hierarchi.Affiche("");
            //Persistance.sauvegarderPhoto( p, @"C:\Users\sami-_000\Documents\workspace-visual\.NET\AppTagger\AppTagger\bdd\photos.json");
            //Persistance.chargerPhoto(@"C:\Users\sami-_000\Documents\workspace-visual\.NET\AppTagger\AppTagger\galerie\", "c_lune.jpg");
            //recupererRoot.Affiche( "" );
            //Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault( false );
            //Application.Run( new Form1() );


        }
    }
}
