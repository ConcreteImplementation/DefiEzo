
using Parseur.Brainfuck;

namespace CalculatriceProgramme
{
    public class ChainesBrainFuck
    {
        private static BrainFuck brainFuck = new BrainFuck();
        private static string chaine;


        
        private static string titre // Calculatrice !
            => "++++[++++>---<]>.-[-->+++<]>--.+++++++++++.---------.-[--->+<]>-.---------.-----------.--[--->+<]>-.--.---------.------.++.--[--->+<]>-.+.";
        
        private static string instructions // Appuyez sur [CTRL+C] pour quitter.
            => "----[---->+<]>++.-[++++>---<]>..+++++.++++.--[->+++<]>.[--->+<]>+++.++[---->+<]>+.---[->++++<]>-.++.---.[-->+++++<]>+++.--[->+++<]>+.[--------->+<]>.>-[--->+<]>-.--.------.-[->++++<]>-.+[-->+++<]>+.-----[-->+++<]>.[--->+<]>+.[-->+++++++<]>.-.++++++.---.[-->+++++<]>+++.----[->++++<]>+.++++.------------.+++++++++++..+++[->+++<]>.+++++++++++++.++[++>---<]>.";
        
        private static string resultat // Résultat: 
            => "-[--->+<]>---.----[->+++<]>-.-[-->+<]>-.++.---------.++++++++.+[->+++<]>++.--[--->+<]>-.[-->+<]>.[-->+<]>+++.";
        private static string erreur // Erreur* 
            => "++++[++++>---<]>++.-[++++>---<]>-..-------------.[--->+<]>--.---.[++>---<]>-.";

        public static void AfficherTitre() => Afficher(titre);
        public static void AfficherInstruction() => Afficher(instructions);
        public static void AfficherErreur() => Afficher(erreur);
        private static void Afficher(string message)
        {
            brainFuck.TryParse(message, out chaine);
            Console.WriteLine(chaine);
        }
        public static void AfficherResultat(decimal entree)
        {
            brainFuck.TryParse(resultat, out chaine);
            Console.WriteLine(chaine + entree);
        }
    }
}
