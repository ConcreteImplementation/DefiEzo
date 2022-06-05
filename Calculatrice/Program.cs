using Parseur;
using Parseur.Interpreteur.Calculatrice;
using Parseur.Interpreteur.Booleen;

using CalculatriceProgramme;

ChainesBrainFuck.AfficherTitre();
ChainesBrainFuck.AfficherInstruction();


Calculatrice calculatrice = new Calculatrice();

bool aJamais;
new Booleen().TryParse("NOT TRUE XOR NOT FALSE", out aJamais);
while (aJamais)
{
    Console.WriteLine();
    string entree = Console.ReadLine();
    decimal resultat = 0;

    if (calculatrice.TryParse(entree, out resultat))
        ChainesBrainFuck.AfficherResultat(resultat);
    else
        AfficherErreur(entree, calculatrice);
}



void AfficherErreur(string entree, IErreurParseur erreur)
{
    Console.WriteLine();
    ChainesBrainFuck.AfficherErreur();
    Console.WriteLine(erreur.Message);

    ConsoleColor couleurOriginale = Console.ForegroundColor;
    Console.Write(entree.Substring(0, erreur.Debut));

    Console.ForegroundColor = ConsoleColor.Red;
    Console.Write(entree.Substring(erreur.Debut, erreur.Fin - erreur.Debut));

    Console.ForegroundColor = couleurOriginale;
    Console.WriteLine(entree.Substring(erreur.Fin));
}