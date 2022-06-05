using Xunit;

using Parseur.Interpreteur.Booleen;

namespace TestBooleen
{
    public class TestNOT
    {
        Booleen booleen = new Booleen();

        [Fact]
        public void Test_not_true()
        {
            // Arranger
            string entree = "NOT TRUE";
            bool attendu = false;
            bool obtenu;

            // Agir
            bool reussi = booleen.TryParse(entree, out obtenu);

            // Auditer
            Assert.True(reussi);
            Assert.Equal(attendu, obtenu);
        }

        [Fact]
        public void Test_not_false()
        {
            // Arranger
            string entree = "NOT FALSE";
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