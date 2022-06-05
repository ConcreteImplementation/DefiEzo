using Xunit;

using Parseur.Interpreteur.Booleen;

namespace TestBooleen
{
    public class TestOR
    {
        Booleen booleen = new Booleen();

        [Fact]
        public void Test_true_or_true()
        {
            // Arranger
            string entree = "TRUE OR TRUE";
            bool attendu = true;
            bool obtenu;

            // Agir
            bool reussi = booleen.TryParse(entree, out obtenu);

            // Auditer
            Assert.True(reussi);
            Assert.Equal(attendu, obtenu);
        }

        [Fact]
        public void Test_true_or_false()
        {
            // Arranger
            string entree = "TRUE OR FALSE";
            bool attendu = true;
            bool obtenu;

            // Agir
            bool reussi = booleen.TryParse(entree, out obtenu);

            // Auditer
            Assert.True(reussi);
            Assert.Equal(attendu, obtenu);
        }

        [Fact]
        public void Test_false_or_true()
        {
            // Arranger
            string entree = "FALSE OR TRUE";
            bool attendu = true;
            bool obtenu;

            // Agir
            bool reussi = booleen.TryParse(entree, out obtenu);

            // Auditer
            Assert.True(reussi);
            Assert.Equal(attendu, obtenu);
        }

        [Fact]
        public void Test_false_or_false()
        {
            // Arranger
            string entree = "FALSE OR FALSE";
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