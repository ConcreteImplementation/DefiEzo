namespace Parseur
{
    public interface IParseur<T>
    {
        //T Resoudre(string entree);
        bool TryParse(string entree, out T resultat);
        IErreurParseur Erreur { get; }
    }
}