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
            Tag julie = new Tag( 0, "julie", new Tag [] { } );
            Tag pascal = new Tag( 1, "pascal", new Tag [] { } );
            Tag famille = new Tag( 2, "famille", new Tag [] { julie, pascal } );

            Tag dunkerque = new Tag( 3, "dunkerque", new Tag [] { } );
            Tag vacances = new Tag( 403, "Vacances", new Tag [] { dunkerque } );


            Tag chien = new Tag( 5, "chien", new Tag [] { } );

            Tag root = new Tag( 6, "root", new Tag [] { famille, vacances, chien } );

            //root.Affiche( "" );

            Photo p = new Photo( @"H:\\", "trevi.jpg");
            p.toString();
            p.AjouterUnTag( vacances );
            p.AjouterUnTag( famille);
            p.AjouterUnTag(pascal);
            p.toString();

            //Persistance.sauvegarderPhoto( p, @"H:\\C#\AppTagger\AppTagger\bdd\photos.json" );
            Persistance.chargerPhoto(@"H:\\c_trevi.jpg" );
            //recupererRoot.Affiche( "" );
            //Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault( false );
            //Application.Run( new Form1() );


        }
    }
}
