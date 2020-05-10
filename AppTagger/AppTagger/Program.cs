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
            /*HierarchieTag ht = HierarchieTag.Instance;
            //ht.Charger();
            ht.Hierarchi.Affiche("");
            ht.AjouterTag("root", "vacances");
            ht.AjouterTag( "vacances", "marseille" );

            ht.AjouterTag( "marseille", "OM" );
            ht.AjouterTag( "root", "famille" );
            ht.AjouterTag( "famille", "brahim" );
           // ht.TrouveParNom( "bali" ).AjouterFils( new Tag( "grece", new Tag [] { } ) );
            ht.Hierarchi.Affiche("");
            ht.Sauvegarder();*/

            /*
             * List<Photo> test = new List<Photo> {new Photo( @"..\..\galerie", "panda.jpg" ), new Photo( @"..\..\galerie", "lune.jpg" ) };
            Console.WriteLine( !test.Exists( p => p.Nom.Equals("panda.jpg") ) );
             * Galerie g = Galerie.Instance;
            HierarchieTag ht = HierarchieTag.Instance;
            try
            {
                g.Charger();
            }
            catch (Exception ex)
            {
                Console.WriteLine( ex.Message );
            }
            try
            {
                ht.Charger();
            }
            catch (Exception ex)
            {
                Console.WriteLine( ex.Message );
            }*/

            /*ht.AjouterTag( "root", "vacances" );
            ht.AjouterTag( "root", "famille" );
            ht.AjouterTag( "vacances", "bali" );

            ht.Hierarchi.Affiche( "" );

            g.AjouterPhoto( new Photo( @"..\..\galerie\panda.jpg" ) );
            g.TrouverPhoto( "panda.jpg" ).AjouterUnTag( ht.TrouveParNom( "vacances" ) );

            g.TrouverPhoto( "panda.jpg" ).toString();

            ht.Sauvegarder();
            g.Sauvegarder();
            */
            //g.Phoos[0].toString();
            //g.Photos [1].toString();

            //g.Photos [0].AjouterUnTag( new Tag( "marouana", new Tag [] { } ) );
            //g.Sauvegarder();




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
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault( false );
            Application.Run( new Form1() );


        }
    }
}
