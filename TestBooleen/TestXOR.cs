using Xunit;

using Parseur.Interpreteur.Booleen;

namespace TestBooleen
{
    public class TestXOR
    {
        Booleen booleen = new Booleen();

        [Fact]
        public void Test_true_xor_true()
        {
            // Arranger
            string entree = "TRUE XOR TRUE";
            bool attendu = false;
            bool obtenu;

            // Agir
            bool reussi = booleen.TryParse(entree, out obtenu);

            // Auditer
            Assert.True(reussi);
            Assert.Equal(attendu, obtenu);
        }

        [Fact]
        public void Test_true_xor_false()
        {
            // Arranger
            string entree = "TRUE XOR FALSE";
            bool attendu = true;
            bool obtenu;

            // Agir
            bool reussi = booleen.TryParse(entree, out obtenu);

            // Auditer
            Assert.True(reussi);
            Assert.Equal(attendu, obtenu);
        }

        [Fact]
        public void Test_false_xor_true()
        {
            // Arranger
            string entree = "FALSE XOR TRUE";
            bool attendu = true;
            bool obtenu;

            // Agir
            bool reussi = booleen.TryParse(entree, out obtenu);

            // Auditer
            Assert.True(reussi);
            Assert.Equal(attendu, obtenu);
        }

        [Fact]
        public void Test_false_xor_false()
        {
            // Arranger
            string entree = "FALSE XOR FALSE";
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