using Xunit;

using Parseur.Interpreteur.Booleen;

namespace TestBooleen
{
    public class TestNOR
    {
        Booleen booleen = new Booleen();

        [Fact]
        public void Test_true_nor_true()
        {
            // Arranger
            string entree = "TRUE NOR TRUE";
            bool attendu = false;
            bool obtenu;

            // Agir
            bool reussi = booleen.TryParse(entree, out obtenu);

            // Auditer
            Assert.True(reussi);
            Assert.Equal(attendu, obtenu);
        }

        [Fact]
        public void Test_true_nor_false()
        {
            // Arranger
            string entree = "TRUE NOR FALSE";
            bool attendu = false;
            bool obtenu;

            // Agir
            bool reussi = booleen.TryParse(entree, out obtenu);

            // Auditer
            Assert.True(reussi);
            Assert.Equal(attendu, obtenu);
        }

        [Fact]
        public void Test_false_nor_true()
        {
            // Arranger
            string entree = "FALSE NOR TRUE";
            bool attendu = false;
            bool obtenu;

            // Agir
            bool reussi = booleen.TryParse(entree, out obtenu);

            // Auditer
            Assert.True(reussi);
            Assert.Equal(attendu, obtenu);
        }

        [Fact]
        public void Test_false_nor_false()
        {
            // Arranger
            string entree = "FALSE NOR FALSE";
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