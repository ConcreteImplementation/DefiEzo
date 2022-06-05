using Xunit;

using Parseur.Interpreteur.Booleen;

namespace TestBooleen
{
    public class TestNAND
    {
        Booleen booleen = new Booleen();

        [Fact]
        public void Test_true_nand_true()
        {
            // Arranger
            string entree = "TRUE NAND TRUE";
            bool attendu = false;
            bool obtenu;

            // Agir
            bool reussi = booleen.TryParse(entree, out obtenu);

            // Auditer
            Assert.True(reussi);
            Assert.Equal(attendu, obtenu);
        }

        [Fact]
        public void Test_true_nand_false()
        {
            // Arranger
            string entree = "TRUE NAND FALSE";
            bool attendu = true;
            bool obtenu;

            // Agir
            bool reussi = booleen.TryParse(entree, out obtenu);

            // Auditer
            Assert.True(reussi);
            Assert.Equal(attendu, obtenu);
        }

        [Fact]
        public void Test_false_nand_true()
        {
            // Arranger
            string entree = "FALSE NAND TRUE";
            bool attendu = true;
            bool obtenu;

            // Agir
            bool reussi = booleen.TryParse(entree, out obtenu);

            // Auditer
            Assert.True(reussi);
            Assert.Equal(attendu, obtenu);
        }

        [Fact]
        public void Test_false_nand_false()
        {
            // Arranger
            string entree = "FALSE NAND FALSE";
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