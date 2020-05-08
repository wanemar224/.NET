using Microsoft.VisualStudio.TestTools.UnitTesting;
using AppTagger;
using AppTagger.modeles;
using System.Collections.Generic;

namespace AppTaggerTest
{
    [TestClass]
    public class UnitTest
    {
        Tag test, nouveauTag;
        Photo photo, photo_2;

        public void init()
        {
            test = new Tag( "tagtest", new Tag [] { } );
            nouveauTag = new Tag( "NouveauTag", new Tag [] { } );

            photo = new Photo( @"H:\\.NET-master\AppTagger\AppTagger\galerie", "panda.jpg", new List<int>() );
            photo_2 = new Photo( @"H:\\.NET-master\AppTagger\AppTagger\galerie", "panda.jpg" );
        }

     

       [TestMethod]
        public void TestConstructeurTag ( )
        {
            init();
            Assert.AreEqual( test.Nom, "tagtest" );
            Assert.AreEqual( test.Fils.Length, 0 );
        }

        [TestMethod]
        public void TestConstructeurPhoto ( )
        {
            this.init();
            Assert.AreEqual( photo_2.Nom, "panda.jpg" );
            Assert.AreEqual( photo.Tags.Count, 0 );
        }

        [TestMethod]
        public void TestTag_AjouterFILS()
        {
            init();
            test.AjouterFils( nouveauTag );
            Assert.AreEqual( test.Fils.Length, 1);
        }

        [TestMethod]
        public void TestAjouterUnTagAUnePhoto()
        {
            init();
            photo.AjouterUnTag( test );
            Assert.AreEqual( photo.Tags.Count, 1 );
        }

        [TestMethod]
        public void TestSupprimerTagAUnePhoto ( )
        {
            init();
            photo.AjouterUnTag( test );
            Assert.AreEqual( photo.Tags.Count, 1 );
            photo.supprimerUnTag( test );
            Assert.AreEqual( photo.Tags.Count, 0 );
        }

        [TestMethod]
        public void TestHierarchie_AjouterTag()
        {
            init();
            HierarchieTag ht = HierarchieTag.Instance;
            ht.AjouterTag(ht.Hierarchi.Nom, test.Nom);
            Assert.ThrowsException<System.Exception>( ( ) => ht.AjouterTag( ht.Hierarchi.Nom, test.Nom ) );

        }
        [TestMethod]
       public void TestGalerie_AjouterPhoto()
        {
             init();
            Galerie g = Galerie.Instance;
            g.AjouterPhoto( photo );
        }

        [TestMethod]
        public void TestGalerie_TrouverPhoto()
        {
            init();
            Galerie g = Galerie.Instance;
            g.AjouterPhoto( photo );

            Assert.IsNotNull( g.TrouverPhoto( "panda.jpg" ) );
        }
        
        [TestMethod]
        public void TestGalerie_SupprimerPhoto()
        {
            init();
            Galerie g = Galerie.Instance;
            int nbPhotoAvantAjout = g.Photos.Count;
            g.AjouterPhoto( photo );

            g.SupprimerPhoto( photo );
            Assert.AreEqual( nbPhotoAvantAjout, g.Photos.Count );
        }

       /* [TestMethod]
        public void TestHierarchieTag_ChargerHierarchie()
        {
            HierarchieTag ht = HierarchieTag.Instance;
            ht.Charger();

            Assert.IsNotNull( ht.Hierarchi );
        }
        */
    }
}
