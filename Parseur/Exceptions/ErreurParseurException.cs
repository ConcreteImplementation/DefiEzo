
namespace Parseur
{
    public class ErreurParseurException : Exception
    {
        public int Debut { get; }
        public int Fin { get; }
        
        public ErreurParseurException(int debut, int fin)
            : base($"Erreur parseur entre {debut} et {fin}")
        {
            Debut = debut;
            Fin = fin;
        }
    }
}
