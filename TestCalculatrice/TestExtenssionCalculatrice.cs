using Xunit;

using Parseur.Interpreteur.Calculatrice;

namespace TestCalculatrice
{
    public class TestExtenssionCalculatrice
    {

        Calculatrice calculatrice = new Calculatrice();


        [Fact]
        public void Test_accepte_chaine_vide()
        {
            // Arranger
            string entree = "";
            decimal attendu = 0;

            // Agir
            decimal obtenu;
            bool reussi = calculatrice.TryParse(entree, out obtenu);

            // Auditer
            Assert.True(reussi);
            Assert.Equal(attendu, obtenu);
        }

        [Fact]
        public void Test_trois_negatives()
        {
            // Arranger
            string entree = "-1---2";
            decimal attendu = -3;

            // Agir
            decimal obtenu;
            bool reussi = calculatrice.TryParse(entree, out obtenu);

            // Auditer
            Assert.True(reussi);
            Assert.Equal(attendu, obtenu);
        }

        [Fact]
        public void Test_negatives_exagerees()
        {
            // Arranger
            string entree = "--1-2---3-1--5";
            decimal attendu = 0;

            // Agir
            decimal obtenu;
            bool reussi = calculatrice.TryParse(entree, out obtenu);

            // Auditer
            Assert.True(reussi);
            Assert.Equal(attendu, obtenu);
        }


        [Fact]
        public void Test_parenthese_pour_unaire()
        {
            // Arranger
            string entree = "sqrt(5*5)";
            decimal attendu = 5;

            // Agir
            decimal obtenu;
            bool reussi = calculatrice.TryParse(entree, out obtenu);

            // Auditer
            Assert.True(reussi);
            Assert.Equal(attendu, obtenu);
        }

        [Fact]
        public void Test_parentheses_imbriquees()
        {
            // Arranger
            string entree = "sqrt(sqrt(5*5*5*5))";
            decimal attendu = 5;

            // Agir
            decimal obtenu;
            bool reussi = calculatrice.TryParse(entree, out obtenu);

            // Auditer
            Assert.True(reussi);
            Assert.Equal(attendu, obtenu);
        }

        [Fact]
        public void Test_negatif_precede_par_unaire()
        {
            // Arranger
            string entree = "sqrt(25) - 5";
            decimal attendu = 0;

            // Agir
            decimal obtenu;
            bool reussi = calculatrice.TryParse(entree, out obtenu);

            // Auditer
            Assert.True(reussi);
            Assert.Equal(attendu, obtenu);
        }

        [Fact]
        public void Test_negatives_deux_fois_de_suite()
        {
            // Arranger
            string entree = "-1--2";
            decimal attendu = 1;

            // Agir
            decimal obtenu = 0.0m;
            bool reussi = calculatrice.TryParse(entree, out obtenu);
            reussi = calculatrice.TryParse(entree, out obtenu);


            // Auditer
            Assert.True(reussi);
            Assert.Equal(attendu, obtenu);
        }

    }
}