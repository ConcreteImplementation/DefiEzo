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
            bool attendu = true; ;
            bool obtenu;

            // Agir
            bool reussi = booleen.TryParse(entree, out obtenu);

            // Auditer
            Assert.True(reussi);
            Assert.Equal(attendu, obtenu);
        }
    }
}