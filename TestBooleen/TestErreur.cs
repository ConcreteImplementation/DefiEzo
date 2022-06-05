using Xunit;

using Parseur.Interpreteur.Booleen;

namespace TestBooleen
{
    public class TestErreur
    {
        Booleen booleen = new Booleen();

        [Fact]
        public void Test_lexeme_non_reconnu()
        {
            // Arranger
            string entree = "TRUE ERREUR TRUE";
            bool resultat;
            int debutAttendu = 5;
            int finAttendu = 11;

            // Agir
            bool reussi = booleen.TryParse(entree, out resultat);
            int debutObtenu = booleen.Debut;
            int finObtenu = booleen.Fin;

            // Auditer
            Assert.False(reussi);
            Assert.Equal(debutAttendu, debutObtenu);
            Assert.Equal(finAttendu, finObtenu);
        }

        [Fact]
        public void Test_toujoursVrai()
        {
            // Arranger
            string entree = "NOT TRUE XOR NOT FALSE";
            bool attendu = true;
            bool obtenu;

            // Agir
            bool reussi = booleen.TryParse(entree, out obtenu);

            // Auditer
            Assert.True(reussi);
            Assert.Equal(attendu, obtenu);
        }

    }
}