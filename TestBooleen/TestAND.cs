using Xunit;

using Parseur.Interpreteur.Booleen;

namespace TestBooleen
{
    public class TestAND
    {
        Booleen booleen = new Booleen();

        [Fact]
        public void Test_true_and_true()
        {
            // Arranger
            string entree = "TRUE AND TRUE";
            bool attendu = true;
            bool obtenu;

            // Agir
            bool reussi = booleen.TryParse(entree, out obtenu);

            // Auditer
            Assert.True(reussi);
            Assert.Equal(attendu, obtenu);
        }

        [Fact]
        public void Test_true_and_false()
        {
            // Arranger
            string entree = "TRUE AND FALSE";
            bool attendu = false;
            bool obtenu;

            // Agir
            bool reussi = booleen.TryParse(entree, out obtenu);

            // Auditer
            Assert.True(reussi);
            Assert.Equal(attendu, obtenu);
        }

        [Fact]
        public void Test_false_and_true()
        {
            // Arranger
            string entree = "FALSE AND TRUE";
            bool attendu = false;
            bool obtenu;

            // Agir
            bool reussi = booleen.TryParse(entree, out obtenu);

            // Auditer
            Assert.True(reussi);
            Assert.Equal(attendu, obtenu);
        }

        [Fact]
        public void Test_false_and_false()
        {
            // Arranger
            string entree = "FALSE AND FALSE";
            bool attendu = false;
            bool obtenu;

            // Agir
            bool reussi = booleen.TryParse(entree, out obtenu);

            // Auditer
            Assert.True(reussi);
            Assert.Equal(attendu, obtenu);
        }
    }
}