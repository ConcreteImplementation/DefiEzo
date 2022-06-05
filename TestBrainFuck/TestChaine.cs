using Xunit;

using Parseur.Brainfuck;


/*
 * Générateur:
 * https://copy.sh/brainfuck/text.html
 * 
 */

namespace TestBrainFuck
{
    public class TestChaine
    {
        BrainFuck brainfuck = new BrainFuck();

        [Fact]
        public void Test_retourne_HelloWorld()
        {
            // Ararnger
            string entree = "-[------->+<]>-.-[->+++++<]>++.+++++++..+++.[->+++++<]>+.------------.--[->++++<]>-.--------.+++.------.--------.-[--->+<]>.";
            string attendu = "Hello, world!";
            string obtenu;
            
            // Agir
            bool reussi = brainfuck.TryParse(entree, out obtenu);

            // Auditer
            Assert.True(reussi);
            Assert.Equal(attendu, obtenu);
        }


        [Fact]
        public void Test_symbole_inconnu()
        {
            // Ararnger
            string entree = "-[-------Z+<]>-.-";
            string resultat;
            int debutAttendu = 9;
            int finAttendu = 10;

            // Agir
            bool reussi = brainfuck.TryParse(entree, out resultat);
            int debutObtenu = brainfuck.Debut;
            int finObtenu = brainfuck.Fin;

            // Auditer
            Assert.False(reussi);
            Assert.Equal(debutAttendu, debutObtenu);
            Assert.Equal(finAttendu, finObtenu);
        }


        [Fact]
        public void Test_erreur_crochet_ouverture()
        {
            // Ararnger
            string entree = "-------->+<]>-.--";
            string resultat;
            int debutAttendu = 11;
            int finAttendu = 12;

            // Agir
            bool reussi = brainfuck.TryParse(entree, out resultat);
            int debutObtenu = brainfuck.Debut;
            int finObtenu = brainfuck.Fin;

            // Auditer
            Assert.False(reussi);
            Assert.Equal(debutAttendu, debutObtenu);
            Assert.Equal(finAttendu, finObtenu);
        }

        [Fact]
        public void Test_erreur_crochet_ouverture2()
        {
            // Ararnger
            string entree = "-[------->+<]>-.-->+++++<]>++.++";
            string resultat;
            int debutAttendu = 25;
            int finAttendu = 26;

            // Agir
            bool reussi = brainfuck.TryParse(entree, out resultat);
            int debutObtenu = brainfuck.Debut;
            int finObtenu = brainfuck.Fin;

            // Auditer
            Assert.False(reussi);
            Assert.Equal(debutAttendu, debutObtenu);
            Assert.Equal(finAttendu, finObtenu);
        }
    }
}