
namespace Parseur
{
    public class ExceptionParseur : Exception
    {
        public int Debut { get; }
        public int Fin { get; }
        
        public ExceptionParseur(int debut, int fin)
            : base($"Erreur parseur entre {debut} et {fin}")
        {
            Debut = debut;
            Fin = fin;
        }
    }
}
