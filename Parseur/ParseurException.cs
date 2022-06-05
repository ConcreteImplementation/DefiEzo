
namespace Parseur
{
    public class ParseurException : Exception
    {
        public int Debut { get; set; }
        public int Fin { get; set; }

        public ParseurException(int debut, int fin)
            : base($"Erreur parseur entre {debut} et {fin}")
        {
            Debut = debut;
            Fin = fin;
        }

        public ParseurException(string message, int debut, int fin)
            : base(message)
        {
            Debut = debut;
            Fin = fin;
        }
    }
}
