namespace Parseur
{
    public interface ParseurInterpreteur<T>
    {
        //T Resoudre(string entree);
        bool TryParse(string entree, out T resultat);
        IErreurParseur Erreur { get; }
    }
}