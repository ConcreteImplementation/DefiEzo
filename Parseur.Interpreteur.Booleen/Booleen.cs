

namespace Parseur.Interpreteur.Booleen
{
    public class Booleen : IParseur<bool>
    {
        public IErreurParseur Erreur => throw new NotImplementedException();

        public bool TryParse(string entree, out bool resultat)
        {
            throw new NotImplementedException();
        }
    }
}
