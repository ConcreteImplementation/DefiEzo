using Xunit;

using Parseur.Interpreteur.Calculatrice;

namespace TestCalculatrice
{
    public class TestErreurParseur
    {

        Calculatrice calculatrice = new Calculatrice();


        [Fact]
        public void Test_Erreur_division_par_zero()
        {
            // Arranger
            string entree = "1/0";
            int debutAttendu = 2;
            int finAttendu = 3;
            decimal resultat;

            // Agir
            bool reussi = calculatrice.TryParse(entree, out resultat);
            int debutObtenu = calculatrice.Debut;
            int finObtenu = calculatrice.Fin;

            // Auditer
            Assert.False(reussi);
            Assert.Equal(debutAttendu, debutObtenu);
            Assert.Equal(finAttendu, finObtenu);
        }

        [Fact]
        public void Test_Erreur_lexeme_inconnue()
        {
            // Arranger
            string entree = "1+ERREUR";
            int debutAttendu = 2;
            int finAttendu = 8;
            decimal resultat;

            // Agir
            bool reussi = calculatrice.TryParse(entree, out resultat);
            int debutObtenu = calculatrice.Debut;
            int finObtenu = calculatrice.Fin;

            // Auditer
            Assert.False(reussi);
            Assert.Equal(debutAttendu, debutObtenu);
            Assert.Equal(finAttendu, finObtenu);
        }

        [Fact]
        public void Test_Erreur_parenthese_incomplete()
        {
            // Arranger
            string entree = "sqrt(5*5";
            int debutAttendu = 4;
            int finAttendu = 8;
            decimal resultat;

            // Agir
            bool reussi = calculatrice.TryParse(entree, out resultat);
            int debutObtenu = calculatrice.Debut;
            int finObtenu = calculatrice.Fin;

            // Auditer
            Assert.False(reussi);
            Assert.Equal(debutAttendu, debutObtenu);
            Assert.Equal(finAttendu, finObtenu);
        }

        [Fact]
        public void Test_Erreur_division_par_zero_dans_parenthese()
        {
            // Arranger
            string entree = "1/(-1--1)";
            int debutAttendu = 2;
            int finAttendu = 9;
            decimal resultat;

            // Agir
            bool reussi = calculatrice.TryParse(entree, out resultat);
            int debutObtenu = calculatrice.Debut;
            int finObtenu = calculatrice.Fin;

            // Auditer
            Assert.False(reussi);
            Assert.Equal(debutAttendu, debutObtenu);
            Assert.Equal(finAttendu, finObtenu);
        }

        [Fact]
        public void Test_Erreur_lexeme_inconnue_dans_parenthese()
        {
            // Arranger
            string entree = "1/(ERREUR)";
            int debutAttendu = 3;
            int finAttendu = 9;
            decimal resultat;

            // Agir
            bool reussi = calculatrice.TryParse(entree, out resultat);
            int debutObtenu = calculatrice.Debut;
            int finObtenu = calculatrice.Fin;

            // Auditer
            Assert.False(reussi);
            Assert.Equal(debutAttendu, debutObtenu);
            Assert.Equal(finAttendu, finObtenu);
        }

        [Fact]
        public void Test_Erreur_parenthese_incomplete_dans_parenthese()
        {
            // Arranger
            string entree = "sqrt(sqrt(25)";
            int debutAttendu = 9;
            int finAttendu = 12;
            decimal resultat;

            // Agir
            bool reussi = calculatrice.TryParse(entree, out resultat);
            int debutObtenu = calculatrice.Debut;
            int finObtenu = calculatrice.Fin;

            // Auditer
            Assert.False(reussi);
            Assert.Equal(debutAttendu, debutObtenu);
            Assert.Equal(finAttendu, finObtenu);
        }
    }
}
