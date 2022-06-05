using Xunit;

using Parseur.Interpreteur.Calculatrice;

namespace TestCalculatrice
{
    public class NosCasDeTest
    {

        Calculatrice calculatrice = new Calculatrice();
        

        [Fact]
        public void Test_Un_plus_un_egale_un()
        {
            // Arranger
            string entree = "1+1";
            decimal attendu = 1;

            // Agir
            decimal obtenu;
            bool reussi = calculatrice.TryParse(entree, out obtenu);

            // Auditer
            Assert.True(reussi);
            Assert.Equal(attendu, obtenu);
        }

        [Fact]
        public void Test_Un_plus_deux_egale_trois()
        {
            // Arranger
            string entree = "1 + 2";
            decimal attendu = 3;

            // Agir
            decimal obtenu;
            bool reussi = calculatrice.TryParse(entree, out obtenu);

            // Auditer
            Assert.True(reussi);
            Assert.Equal(attendu, obtenu);
        }

        [Fact]
        public void Test_Un_plus_moins_un_egale_zero()
        {
            // Arranger
            string entree = "1 + -1";
            decimal attendu = 0;

            // Agir
            decimal obtenu;
            bool reussi = calculatrice.TryParse(entree, out obtenu);

            // Auditer
            Assert.True(reussi);
            Assert.Equal(attendu, obtenu);
        }

        [Fact]
        public void Test_Moins_un_moins_moins_un_egale_zero()
        {
            // Arranger
            string entree = "-1 - -1";
            decimal attendu = 0;

            // Agir
            decimal obtenu;
            bool reussi = calculatrice.TryParse(entree, out obtenu);

            // Auditer
            Assert.True(reussi);
            Assert.Equal(attendu, obtenu);
        }




        [Fact]
        public void Test_cinq_moins_quatre_egale_un()
        {
            // Arranger
            string entree = "5-4";
            decimal attendu = 1;

            // Agir
            decimal obtenu;
            bool reussi = calculatrice.TryParse(entree, out obtenu);

            // Auditer
            Assert.True(reussi);
            Assert.Equal(attendu, obtenu);
        }


        [Fact]
        public void Test_cinq_fois_deux_egale_dix()
        {
            // Arranger
            string entree = "5*2";
            decimal attendu = 10;

            // Agir
            decimal obtenu;
            bool reussi = calculatrice.TryParse(entree, out obtenu);

            // Auditer
            Assert.True(reussi);
            Assert.Equal(attendu, obtenu);
        }

        [Fact]
        public void Test_respect_des_parentheses()
        {
            // Arranger
            string entree = "(2+5)*3";
            decimal attendu = 21;

            // Agir
            decimal obtenu;
            bool reussi = calculatrice.TryParse(entree, out obtenu);

            // Auditer
            Assert.True(reussi);
            Assert.Equal(attendu, obtenu);
        }

        [Fact]
        public void Test_dix_divise_par_deux_egale_cinq()
        {
            // Arranger
            string entree = "10/2";
            decimal attendu = 5;

            /// Agir
            decimal obtenu;
            bool reussi = calculatrice.TryParse(entree, out obtenu);

            // Auditer
            Assert.True(reussi);
            Assert.Equal(attendu, obtenu);
        }

        [Fact]
        public void Test_priorite_des_operations1()
        {
            // Arranger
            string entree = "2+2*5+5";
            decimal attendu = 17;

            // Agir
            decimal obtenu;
            bool reussi = calculatrice.TryParse(entree, out obtenu);

            // Auditer
            Assert.True(reussi);
            Assert.Equal(attendu, obtenu);
        }


        [Fact]
        public void Test_operations_avec_decimal()
        {
            // Arranger
            string entree = "2.8*3-1";
            decimal attendu = 7.4m;

            // Agir
            decimal obtenu;
            bool reussi = calculatrice.TryParse(entree, out obtenu);

            // Auditer
            Assert.True(reussi);
            Assert.Equal(attendu, obtenu);
        }

        [Fact]
        public void Test_deux_exposant_huit_egale_deux_cent_cinquante_huit()
        {
            // Arranger
            string entree = "2^8";
            decimal attendu = 256;

            // Agir
            decimal obtenu;
            bool reussi = calculatrice.TryParse(entree, out obtenu);

            // Auditer
            Assert.True(reussi);
            Assert.Equal(attendu, obtenu);
        }

        [Fact]
        public void Test_priorite_des_operations2()
        {
            // Arranger
            string entree = "2^8*5-1";
            decimal attendu = 1279;

            // Agir
            decimal obtenu;
            bool reussi = calculatrice.TryParse(entree, out obtenu);

            // Auditer
            Assert.True(reussi);
            Assert.Equal(attendu, obtenu);
        }


        [Fact]
        public void Test_gestion_de_fonction()
        {
            // Arranger
            string entree = "sqrt(4)";
            decimal attendu = 2;

            // Agir
            decimal obtenu;
            bool reussi = calculatrice.TryParse(entree, out obtenu);

            // Auditer
            Assert.True(reussi);
            Assert.Equal(attendu, obtenu);
        }
        [Fact]
        public void Test_diviser_par_zero_produit_erreur()
        {
            // Arranger
            string entree = "1/0";

            // Agir
            decimal obtenu;
            bool reussi = calculatrice.TryParse(entree, out obtenu);

            // Auditer
            Assert.False(reussi);
        }
    }
}