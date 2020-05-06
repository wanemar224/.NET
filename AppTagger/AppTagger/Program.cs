using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Imaging;
using Newtonsoft.Json;
using AppTagger.modeles;
using AppTagger.modeles.bdd;
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
            Tag julie = new Tag("julie", new List<Tag> { } );
            Tag pascal = new Tag( "pascal", new List<Tag> { } );
            Tag famille = new Tag(  "famille", new List<Tag> { julie, pascal } );

            Tag dunkerque = new Tag(  "dunkerque", new List<Tag> { } );
            Tag vacances = new Tag( "vacances", new List<Tag> { dunkerque } );


            Tag chien = new Tag( "chien", new List<Tag> { } );

            Tag root = new Tag( "root", new List<Tag> { famille, vacances, chien } );
           
            

            HierarchieTag ht = HierarchieTag.Instance;
           
            ht.Hierarchi = root;

            Photo p = new Photo( @"H:\\C#\AppTagger\AppTagger\galerie", "automne.jpg" );
            p.ajouterUnTag( "vacances" );
            p.ajouterUnTag( "famille" );

            p.ajouterNouveauTag( "nouveauTag", vacances );

            Galerie g = Galerie.Instance;
            g.ajouterPhoto( p );

            PersistanceJson persistance = new PersistanceJson();
            Tag charger = new Tag();
            charger = persistance.chargerHierarchie();
            Galerie.Instance = persistance.chargerGalerie();
            
            

            /*Tag t = ht.trouveParNom("vacances");
            if (t == null)
                Console.WriteLine("on est bon");
            else t.Affiche("");

            ht.ajouterTag( t, new Tag("NouveauFils", new List<Tag> { } ) );
            t.Affiche( "" );

            ht.Hierarchi.Affiche( "" );

            Photo p = new Photo( @"H:\\C#\AppTagger\AppTagger\galerie", "automne.jpg" );
            p.toString();
            p.ajouterUnTag( "vacances" );
            p.ajouterUnTag( "famille" );

            p.ajouterNouveauTag( "nouveauTag", vacances );

            p.toString();



            ht.Hierarchi.Affiche( "" );*/
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
