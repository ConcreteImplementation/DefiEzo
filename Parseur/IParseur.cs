namespace Parseur
{
    public interface IParseur<T>
    {
        T Resoudre(string entree);
    }
}