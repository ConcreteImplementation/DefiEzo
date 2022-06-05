namespace Parseur
{
    public interface IParseur<T>
    {
        bool TryParse(string entree, out T resultat);
        IErreurParseur Erreur { get; }
    }
}